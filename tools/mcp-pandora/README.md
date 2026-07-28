# Pandora MCP Server (`mcp-pandora`)

The Pandora MCP (Model Context Protocol) server provides local AI agents with extremely fast, in-memory access to the Azure Internal Representation (IR). 

By connecting your agent to this server, it gains deep contextual awareness of Azure API schemas and can seamlessly assist in developing the `terraform-provider-azurerm` and `terraform-provider-azuread` codebases.

## Features & Tools

The server runs persistently over `stdio` and exposes the following tools:

1.  **`list_available_resources`**: Returns a list of all ARM resource types (e.g., `Microsoft.Compute/VirtualMachines`) available in the IR. Can optionally be filtered by service.
2.  **`get_resource_markdown`**: Returns an AI-optimized Markdown representation of a specific resource API. It gracefully defaults to the latest API version if one is not specified.
3.  **`find_resource_by_property`**: Instantly searches the entire IR to find which resource(s) and API version(s) contain a specific property name.
4.  **`get_api_version_comparison`**: Takes two API versions for a given resource and generates a unified `diff -u` readout, helping the agent navigate forward-moving breaking schema changes.
5.  **`propose_terraform_schema`**: A powerful development tool that algorithmically converts the raw Azure IR into a Go `map[string]*schema.Schema` skeleton. It automatically maps data types, nested blocks, and common property flags (`Computed`, `Sensitive`, etc.), providing a boilerplate head-start for writing new Terraform resources.

## Assumptions & Dependencies

- **Go Version**: Requires Go 1.25.5 or later.
- **Git**: Requires `git` to be installed on the host machine if you are not running the server from within the Pandora repository. The server uses `git sparse-checkout` to lazily fetch the API definitions.
- **Transport**: The server communicates exclusively over `stdio` via JSON-RPC, which is the standard implementation for local MCP agents.

## Usage & Configuration

The server binary is fully portable. You can install it directly without cloning the Pandora monorepo:

```bash
go install github.com/hashicorp/pandora/tools/mcp-pandora@latest
```

### Startup Flags

The server accepts the following flags to control how it discovers the Azure API Definitions:

*   `-dir`: Explicit path to a local `api-definitions` directory.
*   `-ref`: A GitHub branch, tag, or commit hash to fetch from (defaults to `main`).
*   `-force-update`: Wipes the local cache and forces a fresh git fetch from the specified `-ref`.

**Resolution Order**:
1. It uses `-dir` if provided.
2. It looks for `../../api-definitions` locally (useful for developers working inside the Pandora codebase).
3. If neither are found, it uses `git sparse-checkout` to clone the definitions from `github.com/hashicorp/pandora` into your OS-specific cache directory (e.g., `~/.cache/mcp-pandora/main/api-definitions`), making subsequent startups instantaneous.

### Example: Claude Desktop Configuration

Add this to your `claude_desktop_config.json` file. Because of the smart fallback logic, you don't even need to configure the `cwd` if you aren't working locally!

```json
{
  "mcpServers": {
    "pandora": {
      "command": "mcp-pandora",
      "args": ["-ref", "main"]
    }
  }
}
```

### Example: Cursor Configuration

In Cursor's **Features > MCP** settings pane, add a new server:
*   **Type**: `command`
*   **Name**: `pandora`
*   **Command**: `mcp-pandora -ref main`

### Example: Antigravity Configuration

For Antigravity, you can wire up the server by ensuring the binary is in your `PATH` and registering the MCP server through the standard plugin configuration, supplying `-ref main` to ensure it lazily fetches the schemas.
