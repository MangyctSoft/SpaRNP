#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["SpaRNP.Analysis.API/SpaRNP.Analysis.API.csproj", "SpaRNP.Analysis.API/"]
COPY ["SpaRNP.Context/SpaRNP.Context.csproj", "SpaRNP.Context/"]
COPY ["SpaRNP.Models/SpaRNP.Models.csproj", "SpaRNP.Models/"]
RUN dotnet restore "SpaRNP.Analysis.API/SpaRNP.Analysis.API.csproj"
COPY . .
WORKDIR "/src/SpaRNP.Analysis.API"
RUN dotnet build "SpaRNP.Analysis.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaRNP.Analysis.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaRNP.Analysis.API.dll"]