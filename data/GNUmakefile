default: build

build:
	dotnet build ./Pandora.sln

fmt:
	# note we're intentionally only using whitespace here since the others try
	# to fix design issues, which are actually issues in the API Data
	dotnet format whitespace --verbosity quiet Pandora.sln

run: build
	dotnet Pandora.Api/bin/Debug/net7.0/Pandora.Api.dll

test: build
	dotnet test Pandora.sln

tools:
	@echo "==> installing required tooling..."
	dotnet tool install -g dotnet-format

.PHONY: build fmt run test tools

