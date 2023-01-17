FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Adrien.Bassail.FaceDetection.Console/Adrien.Bassail.FaceDetection.Console.csproj", "Adrien.Bassail.FaceDetection.Console/"]
RUN dotnet restore "Adrien.Bassail.FaceDetection.Console/Adrien.Bassail.FaceDetection.Console.csproj"
COPY . .
WORKDIR "/src/Adrien.Bassail.FaceDetection.Console"
RUN dotnet build "Adrien.Bassail.FaceDetection.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adrien.Bassail.FaceDetection.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adrien.Bassail.FaceDetection.Console.dll"]
