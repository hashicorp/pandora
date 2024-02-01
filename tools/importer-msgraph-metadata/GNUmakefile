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

import-all-clean: build
	rm -r ../../data/Pandora.Definitions.MicrosoftGraph.*/[A-Z]*/
	./importer-msgraph-metadata import

test: build
	go test -v ./...

tools:
	@echo "==> no tools are required at this time."

.PHONY: build fmt import import-with-api test tools
