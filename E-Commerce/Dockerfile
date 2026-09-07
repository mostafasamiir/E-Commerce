#Build stage

FROM  mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY *.csproj .  
#ay haga .csproj hy3mlha copy ll src file  , m3mltsh hna copy . .  3shan bttghyr 2olyl f ygbha mn el cache 3ltol w nsr3 el build

RUN dotnet restore 

COPY . .  
# b3ml copy l kol haga f el file elly feh el dockerfile dlw2te ll src file

RUN dotnet publish  -c Release -o output
   
   
#Final stage

FROM mcr.microsoft.com/dotnet/aspnet:10.0 
WORKDIR /app
# b3ml copy l kol haga mn el build stage ll final stage 3shan a3ml run ll app (kol haga kant 3nde f src/output)
COPY --from=build /src/output . 

ENTRYPOINT ["dotnet", "E-Commerce.dll"]
