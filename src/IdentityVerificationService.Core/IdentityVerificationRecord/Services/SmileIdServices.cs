using IdentityVerificationService.Configuration;
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityVerificationService.Services
{
    /// <summary>
    /// Service for interacting with the Smile ID API.
    /// </summary>
    public class SmileIdService
    {
        private readonly SmileIdConfig _config;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmileIdService"/> class.
        /// </summary>
        /// <param name="smileIdConfig">The Smile ID configuration settings.</param>
        /// <param name="httpClient">The HTTP client used for API calls.</param>
        public SmileIdService(SmileIdConfig smileIdConfig, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _config = smileIdConfig;
        }

        /// <summary>
        /// Generates the request signature for Smile ID API requests.
        /// </summary>
        /// <param name="timeStamp">The timestamp to be used in the signature.</param>
        /// <returns>A base64-encoded HMAC signature.</returns>
        public string GenerateSignature(string timeStamp)
        {
            string dataToSign = timeStamp + _config.PartnerId + "sid_request";
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_config.SecretKey)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Verifies the identity information using the Smile ID API.
        /// </summary>
        /// <param name="endpointUrl">The Smile ID API endpoint URL.</param>
        /// <param name="requestData">The request data payload.</param>
        /// <returns>The API response as a string.</returns>
        /// <exception cref="HttpRequestException">Thrown if the API call is unsuccessful.</exception>
        public async Task<string> VerifyIdentityAsync(string endpointUrl, object requestData)
        {
            string timeStamp = DateTime.UtcNow.ToString("o");
            string signature = GenerateSignature(timeStamp);

            var requestPayload = requestData.GetType()
                .GetProperties()
                .Where(p => p.GetValue(requestData) != null)
                .ToDictionary(
                    p => JsonNamingPolicy.CamelCase.ConvertName(p.Name),
                    p => p.GetValue(requestData)
                );

            requestPayload["signature"] = signature;
            requestPayload["timestamp"] = timeStamp;
            requestPayload["partner_id"] = _config.PartnerId;

            string jsonPayload = JsonSerializer.Serialize(requestPayload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpointUrl)
            {
                Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("smileid-partner-id", _config.PartnerId);
            requestMessage.Headers.Add("smileid-request-signature", signature);
            requestMessage.Headers.Add("smileid-timestamp", timeStamp);

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, {responseBody}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Verifies a BVN using the Smile ID API.
        /// </summary>
        /// <param name="bvnDto">The BVN verification data.</param>
        /// <returns>The API response as a string.</returns>
        public async Task<string> VerifyBvnAsync(BvnVerificationDto bvnDto)
        {
            string endpointUrl = $"{_config.BaseUrl}/v2/verify";

            var payload = new
            {
                id_number = bvnDto.id_number,
                id_type = "BVN",
                partner_params = new
                {
                    job_id = Guid.NewGuid().ToString(),
                    job_type = "7",
                    user_id = "bvn_test_user"
                },
                source_sdk = "rest_api",
                source_sdk_version = "1.0.0"
            };

            return await VerifyIdentityAsync(endpointUrl, payload);
        }
    }
}
