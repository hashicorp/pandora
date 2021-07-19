default: build

build:
	go build .

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

run: build
	./generator-terraform

tools:
	@echo "==> no tools required at this time."

.PHONY: build fmt run

