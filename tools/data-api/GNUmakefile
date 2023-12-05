default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

run: build
	./data-api serve

test: build
	go test -v ./...

.PHONY: build fmt run
