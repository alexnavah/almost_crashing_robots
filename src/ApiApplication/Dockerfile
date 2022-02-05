FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
#EXPOSE 80

COPY bin/Debug/netcoreapp3.1/publish .

ENTRYPOINT ["dotnet", "ApiApplication.dll"]
