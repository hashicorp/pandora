default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

test:
	go test -v ./...

.PHONY: build fmt test
