default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	if [ -z "$(SERVICES)" ]; then \
		./importer-rest-api-specs import; \
	else \
		./importer-rest-api-specs import -services=$(SERVICES); \
	fi

import-with-api: build
	./importer-rest-api-specs import --data-api=http://localhost:8080

validate: build
	./importer-rest-api-specs validate

test: build
	go test -v ./... -timeout=90m

tools:
	@echo "==> no tools required..."

.PHONY: build fmt import import-with-api test tools
