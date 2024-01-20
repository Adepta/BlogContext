FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Blog_Project/Blog_Project.csproj", "Blog_Project/"]
COPY ["DataLibrary/DataLibrary.csproj", "DataLibrary/"]
RUN dotnet restore "Blog_Project/Blog_Project.csproj"
COPY . .
WORKDIR "/src/Blog_Project"
RUN dotnet build "Blog_Project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog_Project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog_Project.dll"]
