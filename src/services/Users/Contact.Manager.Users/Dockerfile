# to running this image, execute the code below from solutions path
# docker build . -t lyracampos/contact-manager-users -f Users/Contact.Manager.Users/Dockerfile
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore "ContactManager.sln"

COPY . .
WORKDIR /src/Users/Contact.Manager.Users
RUN dotnet publish --no-restore -c Release -o /app

FROM build as publish

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contact.Manager.Users.dll"]