# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо всю структуру проєкту від кореня
COPY ../ ./

# Відновлюємо пакети для statement-service
RUN dotnet restore statement-service/statement-service.csproj

# Публікуємо statement-service
RUN dotnet publish statement-service/statement-service.csproj -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV DB_HOST=postgres
ENV DB_PORT=5432
ENV DB_NAME=service-system-of-LDUBGD_db
ENV DB_USER=postgres
ENV DB_PASS=postgres
ENV ASPNETCORE_URLS=http://+:5255

EXPOSE 5255

ENTRYPOINT ["dotnet", "statement-service.dll"]
