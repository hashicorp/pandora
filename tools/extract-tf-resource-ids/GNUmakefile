default: build

fmt:
	find . -name '*.go' | grep -v vendor | xargs gofmt -s -w

run:
	go run main.go

tools:
	@echo "==> no tools required at this time."

.PHONY: fmt run tools

