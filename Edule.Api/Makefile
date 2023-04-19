.PHONY: build clean

build: 
	dotnet build Edule.Api.sln -v quiet --no-incremental

clean:
	dotnet clean Edule.Api.sln -v minimal

COMPOSE ?= $(shell which docker-compose)
up:
ifeq ($(OS),Windows_NT)
	powershell -c "wsl docker-compose -f API-docker-compose.yml up --build"
else
ifdef $(COMPOSE)
	docker-compose -f docker-compose.yml up -d --build
else
	docker compose -f docker-compose.yml up -d --build	
endif
endif

db-up: build
ifeq ($(OS),Windows_NT)
	dotnet ef database update --project .\Edule.Api\Edule.Api.csproj --startup-project .\Edule.Api\Edule.Api.csproj
else
	dotnet ef database update --project ./Edule.Api/Edule.Api.csproj --startup-project ./Edule.Api/Edule.Api.csproj
endif

db-down: build
ifeq ($(OS),Windows_NT)
	dotnet ef database update 0 --project .\src\CustomerPortal.Billing.Balance.Infra.Data\CustomerPortal.Billing.Balance.Infra.Data.csproj --startup-project .\src\CustomerPortal.Billing.Balance.Api\CustomerPortal.Billing.Balance.API.csproj
else
	dotnet ef database update 0 --project ./src/CustomerPortal.Billing.Balance.Infra.Data/CustomerPortal.Billing.Balance.Infra.Data.csproj --startup-project ./src/CustomerPortal.Billing.Balance.Api/CustomerPortal.Billing.Balance.API.csproj
endif

MIGRATION_NAME := InitialStructure
add-migration: build
ifeq ($(OS),Windows_NT)
	dotnet ef migrations add $(MIGRATION_NAME) --project .\Edule.Api\Edule.Api.csproj --startup-project .\src\CustomerPortal.Billing.Balance.Api\CustomerPortal.Billing.Balance.API.csproj
else
	dotnet ef migrations add $(MIGRATION_NAME) --project ./src/CustomerPortal.Billing.Balance.Infra.Data/CustomerPortal.Billing.Balance.Infra.Data.csproj --startup-project ./src/CustomerPortal.Billing.Balance.Api/CustomerPortal.Billing.Balance.API.csproj
endif

undo-migration: build
ifeq ($(OS),Windows_NT)
	dotnet ef migrations remove --project .\src\CustomerPortal.Billing.Balance.Infra.Data\CustomerPortal.Billing.Balance.Infra.Data.csproj --startup-project .\src\CustomerPortal.Billing.Balance.Api\CustomerPortal.Billing.Balance.API.csproj
else
	dotnet ef migrations remove --project ./src/CustomerPortal.Billing.Balance.Infra.Data/CustomerPortal.Billing.Balance.Infra.Data.csproj --startup-project ./src/CustomerPortal.Billing.Balance.Api/CustomerPortal.Billing.Balance.API.csproj
endif		

down:
ifeq ($(OS),Windows_NT)
	powershell -c "wsl docker system prune"
else
	docker system prune
endif

down-2:
ifeq ($(OS),Windows_NT)
	powershell -c "wsl docker-compose -f API-docker-compose.yml down"        
else
ifdef $(COMPOSE)
	docker-compose -f API-docker-compose.yml down
else
	docker compose -f API-docker-compose.yml down	
endif
endif
