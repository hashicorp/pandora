default: build

build:
	@echo "building..."
	@go build .

fmt:
	@echo "running gofmt on all discoverable go files..."
	@find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	@echo "Importing Resource Manager..."
	@if [ -z "$(SERVICES)" ]; then \
		./importer-rest-api-specs import; \
	else \
		./importer-rest-api-specs import -services=$(SERVICES); \
	fi

import-data-plane: build
	@echo "Importing Data Plane..."
	@if [ -z "$(SERVICES)" ]; then \
		./importer-rest-api-specs import-data-plane; \
	else \
		./importer-rest-api-specs import-data-plane -services=$(SERVICES); \
	fi

import-with-api: build
	@echo "Importing using api on http://localhost:8080"
	@./importer-rest-api-specs import --data-api=http://localhost:8080

validate: build
	@echo "Running Validation"
	@./importer-rest-api-specs validate

test: build
	go test -v ./... -timeout=90m

tools:
	@echo "==> no tools required..."

.PHONY: build fmt import import-with-api test tools
