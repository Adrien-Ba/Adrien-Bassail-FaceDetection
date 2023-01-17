FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Adrien.Bassail.FaceDetection.WebApi/Adrien.Bassail.FaceDetection.WebApi.csproj", "Adrien.Bassail.FaceDetection.WebApi/"]
RUN dotnet restore "Adrien.Bassail.FaceDetection.WebApi/Adrien.Bassail.FaceDetection.WebApi.csproj"
COPY . .
WORKDIR "/src/Adrien.Bassail.FaceDetection.WebApi"
RUN dotnet build "Adrien.Bassail.FaceDetection.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adrien.Bassail.FaceDetection.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adrien.Bassail.FaceDetection.WebApi.dll"]
