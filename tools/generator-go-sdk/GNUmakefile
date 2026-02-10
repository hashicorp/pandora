default: build

build: tools
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

run: build
	@./generator-go-sdk resource-manager generate

test: build
	go test -v ./...

tools:
	go install golang.org/x/tools/cmd/goimports@latest

.PHONY: build fmt run test tools

