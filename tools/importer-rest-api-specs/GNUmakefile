default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	PANDORA_GENERATE_EVERYTHING=false OAIGEN_DEDUPE=false ./importer-rest-api-specs
	dotnet format --fix-whitespace --fix-style --fix-analyzers --verbosity quiet ../../data/Pandora.sln

import-all: build
	PANDORA_GENERATE_EVERYTHING=true OAIGEN_DEDUPE=false ./importer-rest-api-specs
	dotnet format --fix-whitespace --fix-style --fix-analyzers --verbosity quiet ../../data/Pandora.sln

test: build
	PANDORA_GENERATE_EVERYTHING=false OAIGEN_DEDUPE=false go test -v ./...

tools:
	@echo "==> installing required tooling..."
	dotnet tool install -g dotnet-format

.PHONY: build fmt import import-all test tools
