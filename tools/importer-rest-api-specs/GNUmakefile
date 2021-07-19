default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

import: build
	PANDORA_GENERATE_EVERYTHING=false OAIGEN_DEDUPE=false ./importer-rest-api-specs

import-all: build
	PANDORA_GENERATE_EVERYTHING=true OAIGEN_DEDUPE=false ./importer-rest-api-specs

tools:
	@echo "==> no tools required at this time."

.PHONY: build fmt import import-all
