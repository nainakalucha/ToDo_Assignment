#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Adform_ToDo.Api/Adform_ToDo.Api.csproj", "Adform_ToDo.Api/"]
COPY ["Adform_ToDo.Common/Adform_ToDo.Common.csproj", "Adform_ToDo.Common/"]
COPY ["Adform_ToDo.DAL/Adform_ToDo.DAL.csproj", "Adform_ToDo.DAL/"]
COPY ["Adform_ToDo.BLL/Adform_ToDo.BLL.csproj", "Adform_ToDo.BLL/"]
RUN dotnet restore "Adform_ToDo.Api/Adform_ToDo.Api.csproj"
COPY . .
WORKDIR "/src/Adform_ToDo.Api"
RUN dotnet build "Adform_ToDo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adform_ToDo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adform_ToDo.Api.dll"]