FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201

WORKDIR /app

RUN dotnet new console -n AsyncSamples

COPY "Directory.Build.props" .
COPY AsyncSamples ./AsyncSamples/

RUN dotnet build "./AsyncSamples/AsyncSamples.csproj" -o /out

WORKDIR /out
ENTRYPOINT ["dotnet", "AsyncSamples.dll"]