#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ADataCenter.Web/ADataCenter.Web.csproj", "ADataCenter.Web/"]
COPY ["ADataCenter.Domain/ADataCenter.Domain.csproj", "ADataCenter.Domain/"]
COPY ["ADataCenter.Data/ADataCenter.Data.csproj", "ADataCenter.Data/"]
RUN dotnet restore "ADataCenter.Web/ADataCenter.Web.csproj"
COPY . .
WORKDIR "/src/ADataCenter.Web"
RUN dotnet build "ADataCenter.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ADataCenter.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ADataCenter.Web.dll"]
