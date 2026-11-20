# GNUmakefile for Pandora

ACTIONLINT_VERSION := v1.7.7

.PHONY: tools update-go-version validate-workflows test-workflow-act

tools:
	@echo "==> Installing workflow tooling (actionlint@$(ACTIONLINT_VERSION), shellcheck, zizmor)..."
	go install github.com/rhysd/actionlint/cmd/actionlint@$(ACTIONLINT_VERSION)
	@if ! command -v shellcheck >/dev/null 2>&1; then \
		if command -v brew >/dev/null 2>&1; then \
			brew install shellcheck; \
		else \
			echo "Note: install shellcheck (e.g. 'brew install shellcheck' or 'apt-get install shellcheck') for full local linting."; \
		fi; \
	fi
	@if ! command -v zizmor >/dev/null 2>&1; then \
		if command -v brew >/dev/null 2>&1; then \
			brew install zizmor; \
		elif command -v pipx >/dev/null 2>&1; then \
			pipx install zizmor; \
		else \
			echo "Note: install zizmor (e.g. 'brew install zizmor' or 'pipx install zizmor') for workflow security linting."; \
		fi; \
	fi

update-go-version:
	@if [ -z "$(VERSION)" ]; then \
		echo "Error: VERSION is required."; \
		echo "Usage: make update-go-version VERSION=1.25.9"; \
		exit 1; \
	fi
	@./scripts/update-go-version.sh $(VERSION)

validate-workflows:
	@echo "==> Running workflow validation..."
	@if command -v actionlint >/dev/null 2>&1; then \
		actionlint; \
	else \
		echo "actionlint not found. Run 'make tools' to install actionlint@$(ACTIONLINT_VERSION)."; \
		exit 1; \
	fi
	@if command -v shellcheck >/dev/null 2>&1; then \
		shellcheck -S error scripts/*.sh; \
	else \
		echo "shellcheck not found. Install it (e.g. 'brew install shellcheck') to lint scripts/*.sh."; \
		exit 1; \
	fi
	@if command -v zizmor >/dev/null 2>&1; then \
		zizmor .github/workflows/; \
	else \
		echo "Note: optional 'zizmor' not installed; skipping zizmor check."; \
	fi
	@./scripts/test-workflows.sh

# Optional local runner emulation via nektos/act (ubuntu-latest jobs only).
# Usage: make test-workflow-act WORKFLOW=.github/workflows/pr-validate-workflows.yaml [JOB=validate] [EVENT=pull_request] [ACT_ARGS="--dryrun"]
test-workflow-act:
	@if [ -z "$(WORKFLOW)" ]; then \
		echo "Error: WORKFLOW is required."; \
		echo "Usage: make test-workflow-act WORKFLOW=.github/workflows/pr-validate-workflows.yaml [JOB=validate] [EVENT=pull_request] [ACT_ARGS='--dryrun']"; \
		echo "Note: custom-linux-xl, Protected Environments, and OIDC jobs cannot be emulated locally by act."; \
		exit 1; \
	fi
	@command -v act >/dev/null 2>&1 || { echo "Error: 'act' not found. Install via 'brew install act'."; exit 1; }
	@docker info >/dev/null 2>&1 || { echo "Error: Docker daemon is not running."; exit 1; }
	@ARCH_FLAG=""; \
	if [ "$$(uname -m)" = "arm64" ]; then ARCH_FLAG="--container-architecture linux/amd64"; fi; \
	JOB_FLAG=""; \
	if [ -n "$(JOB)" ]; then JOB_FLAG="-j $(JOB)"; fi; \
	EVENT_NAME="$(or $(EVENT),pull_request)"; \
	act "$$EVENT_NAME" -W "$(WORKFLOW)" $$JOB_FLAG $$ARCH_FLAG -P ubuntu-latest=catthehacker/ubuntu:act-latest $(ACT_ARGS)
