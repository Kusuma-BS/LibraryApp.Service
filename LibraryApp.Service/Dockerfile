#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibraryApp.Service/LibraryApp.Service.csproj", "LibraryApp.Service/"]
RUN dotnet restore "LibraryApp.Service/LibraryApp.Service.csproj"
COPY . .
WORKDIR "/src/LibraryApp.Service"
RUN dotnet build "LibraryApp.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryApp.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApp.Service.dll"]