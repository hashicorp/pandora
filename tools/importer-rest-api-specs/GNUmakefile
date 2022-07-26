default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	./importer-rest-api-specs import
	# note we're intentionally only using whitespace here since the others try
	# to fix design issues, which are actually issues in the API Data
	dotnet format whitespace --verbosity quiet ../../data/Pandora.sln

import-with-api: build
	./importer-rest-api-specs import --data-api=http://localhost:5000
	# note we're intentionally only using whitespace here since the others try
	# to fix design issues, which are actually issues in the API Data
	dotnet format whitespace --verbosity quiet ../../data/Pandora.sln

test: build
	go test -v ./...

tools:
	@echo "==> installing required tooling..."
	dotnet tool install -g dotnet-format

.PHONY: build fmt import import-with-api test tools
