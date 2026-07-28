# Generator Agent Docs

The `generator-agent-docs` tool is responsible for reading the highly structured JSON API Definitions (used by `terraform-provider-azurerm`, `terraform-provider-azuread`, etc.) and converting them into a highly token-efficient Markdown format. 

## Purpose

Large Language Models (LLMs) and AI Agents consume structured text (like Markdown) significantly better than deeply nested JSON. This tool removes the verbose quoting and brace overhead of JSON while retaining critical context required for downstream provider development.

Specifically, the generated Markdown preserves schema metadata by appending tags to fields, such as:
*   `[Required]` / `[Optional]`
*   `[Sensitive]` (e.g., passwords or keys)
*   `[ReadOnly]` (computed fields)
*   `[ContainsDiscriminatedTypeValue: true]` (polymorphic base types)

## Intended Usage

This tool was designed with two primary consumption models in mind: **Local CLI Execution** (for debugging and manual generation) and **In-Memory Generation** (for MCP Servers).

### 1. Local Usage (CLI)

You can run the generator locally to inspect the output or commit the generated Markdown files to a repository.

```bash
# Build the tool
go build -o generator-agent-docs main.go

# Run the generator for all services in resource-manager
./generator-agent-docs resource-manager generate \
    --api-definitions-dir ../../api-definitions \
    --output-dir ../../agent-definitions

# You can also limit generation to specific services for faster debugging
./generator-agent-docs resource-manager generate \
    --api-definitions-dir ../../api-definitions \
    --output-dir ../../agent-definitions \
    --limit-to Compute \
    --limit-to Storage
```

### 2. Downstream MCP Server Integration (Go)

If you are building a Model Context Protocol (MCP) server or a Go-based agent, you can bypass the CLI and disk I/O entirely. The tool reads the JSON definitions directly using the `data-api-repository`, meaning you don't need the `data-api` server running.

You can import the generator logic to parse the models and hold the Markdown strings directly in memory on startup:

```go
import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-agent-docs/internal/generator"
)

func LoadAgentDocs() (map[string][]byte, error) {
	opts := generator.GenerateOptions{
		APIDefinitionsDirectory: "/path/to/api-definitions",
		SourceDataType:          models.ResourceManagerSourceDataType,
		Logger:                  hclog.Default(),
		
		// Optional: Only load specific services
		// ServiceNamesToLimitTo: []string{"Compute", "Storage"},
	}

	// This returns a map where the key is the file path 
	// (e.g. "resource-manager/Compute/2024-11-01/AvailabilitySets.md")
	// and the value is the Markdown content.
	results, err := generator.Generate(opts)
	if err != nil {
		return nil, err
	}

	return results, nil
}
```

This allows your MCP server to immediately serve the agent-optimized documentation without bloating the source control repository with thousands of Markdown files.
