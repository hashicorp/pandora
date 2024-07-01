default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	if [ -z "$(SERVICES)" ]; then \
		./importer-msgraph-metadata import; \
	else \
		./importer-msgraph-metadata import -services=$(SERVICES); \
	fi

lint:
	golangci-lint run ./...

test: build
	go test -v ./...

tools:
	@echo "==> no tools are required at this time."

.PHONY: build fmt import import-with-api test tools
