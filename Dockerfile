FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev

WORKDIR /app

COPY MonWeatherSolution.sln ./
COPY src/ ./src/

RUN dotnet restore

RUN dotnet tool install --global dotnet-ef --version 8.0.0 \
    && echo 'export PATH="$PATH:/root/.dotnet/tools"' >> /root/.bashrc \
    && export PATH="$PATH:/root/.dotnet/tools"

CMD ["dotnet", "run", "--urls", "http://0.0.0.0:5000", "--project", "src/MonWeather.Web/MonWeather.Web.csproj"]
