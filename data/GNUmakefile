default: build

build:
	dotnet build ./Pandora.sln

fmt:
	dotnet format --fix-whitespace --fix-style --fix-analyzers --verbosity quiet

run: build
	dotnet Pandora.Api/bin/Debug/net5.0/Pandora.Api.dll

test: build
	dotnet test Pandora.sln

tools:
	@echo "==> installing required tooling..."
	dotnet tool install -g dotnet-format

.PHONY: build fmt run test tools

