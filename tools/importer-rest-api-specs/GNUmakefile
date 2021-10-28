default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	./importer-rest-api-specs
	dotnet format --fix-whitespace --fix-style --fix-analyzers --verbosity quiet ../../data/Pandora.sln

import-with-api: build
	./importer-rest-api-specs --data-api=http://localhost:5000
	dotnet format --fix-whitespace --fix-style --fix-analyzers --verbosity quiet ../../data/Pandora.sln

test: build
	go test -v ./...

tools:
	@echo "==> installing required tooling..."
	dotnet tool install -g dotnet-format

.PHONY: build fmt import import-with-api test tools
