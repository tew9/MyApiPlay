FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR p1/
COPY . .
RUN dotnet build
RUN dotnet publish --configuration Release -o out PizzaBox.Client/PizzaBox.Client.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR dist/
COPY --from=build p1/out/ ./
CMD ["dotnet", "PizzaBox.Client.dll"]