FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/B12Test.Web.Host/B12Test.Web.Host.csproj", "src/B12Test.Web.Host/"]
COPY ["src/B12Test.Web.Core/B12Test.Web.Core.csproj", "src/B12Test.Web.Core/"]
COPY ["src/B12Test.Application/B12Test.Application.csproj", "src/B12Test.Application/"]
COPY ["src/B12Test.Core/B12Test.Core.csproj", "src/B12Test.Core/"]
COPY ["src/B12Test.EntityFrameworkCore/B12Test.EntityFrameworkCore.csproj", "src/B12Test.EntityFrameworkCore/"]
WORKDIR "/src/src/B12Test.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/B12Test.Web.Host", "src/B12Test.Web.Host"]
COPY ["src/B12Test.Web.Core", "src/B12Test.Web.Core"]
COPY ["src/B12Test.Application", "src/B12Test.Application"]
COPY ["src/B12Test.Core", "src/B12Test.Core"]
COPY ["src/B12Test.EntityFrameworkCore", "src/B12Test.EntityFrameworkCore"]
WORKDIR "/src/src/B12Test.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "B12Test.Web.Host.dll"]
