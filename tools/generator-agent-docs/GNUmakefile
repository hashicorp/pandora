default: build

build: tools
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

run: build
	@./generator-agent-docs resource-manager generate

test: build
	go test -v ./...

tools:
	go install golang.org/x/tools/cmd/goimports@v0.30.0

.PHONY: build fmt run test tools
