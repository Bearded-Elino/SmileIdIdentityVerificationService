using System.Threading.Tasks;
using IdentityVerificationService.Models.TokenAuth;
using IdentityVerificationService.Web.Controllers;
using Shouldly;
using Xunit;

namespace IdentityVerificationService.Web.Tests.Controllers
{
    public class HomeController_Tests: IdentityVerificationServiceWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}