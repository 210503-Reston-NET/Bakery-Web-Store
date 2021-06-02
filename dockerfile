# base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# baby of mkdir and cd
WORKDIR /app


COPY *.sln ./
COPY SBL/*.csproj SBL/
COPY SDL/*.csproj SDL/
COPY SModel/*.csproj SModel/
COPY BakeryTest/*.csproj BakeryTest/
COPY BakeryWebUI/*.csproj BakeryWebUI/


RUN cd BakeryWebUI && dotnet restore

COPY . ./

RUN dotnet publish BakeryWebUI -c Release -o publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app

COPY --from=build /app/publish ./

CMD ["dotnet", "BakeryWebUI.dll"]