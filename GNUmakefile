# GNUmakefile for Pandora

.PHONY: update-go-version

update-go-version:
	@if [ -z "$(VERSION)" ]; then \
		echo "Error: VERSION is required."; \
		echo "Usage: make update-go-version VERSION=1.25.9"; \
		exit 1; \
	fi
	@./scripts/update-go-version.sh $(VERSION)
