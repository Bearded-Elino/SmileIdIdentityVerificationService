FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/IdentityVerificationService.Web.Host/IdentityVerificationService.Web.Host.csproj", "src/IdentityVerificationService.Web.Host/"]
COPY ["src/IdentityVerificationService.Web.Core/IdentityVerificationService.Web.Core.csproj", "src/IdentityVerificationService.Web.Core/"]
COPY ["src/IdentityVerificationService.Application/IdentityVerificationService.Application.csproj", "src/IdentityVerificationService.Application/"]
COPY ["src/IdentityVerificationService.Core/IdentityVerificationService.Core.csproj", "src/IdentityVerificationService.Core/"]
COPY ["src/IdentityVerificationService.EntityFrameworkCore/IdentityVerificationService.EntityFrameworkCore.csproj", "src/IdentityVerificationService.EntityFrameworkCore/"]
WORKDIR "/src/src/IdentityVerificationService.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/IdentityVerificationService.Web.Host", "src/IdentityVerificationService.Web.Host"]
COPY ["src/IdentityVerificationService.Web.Core", "src/IdentityVerificationService.Web.Core"]
COPY ["src/IdentityVerificationService.Application", "src/IdentityVerificationService.Application"]
COPY ["src/IdentityVerificationService.Core", "src/IdentityVerificationService.Core"]
COPY ["src/IdentityVerificationService.EntityFrameworkCore", "src/IdentityVerificationService.EntityFrameworkCore"]
WORKDIR "/src/src/IdentityVerificationService.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "IdentityVerificationService.Web.Host.dll"]
