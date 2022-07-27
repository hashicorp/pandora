# Tool: wrapper-automation

## What is this tool?

This tool provides a convenience wrapper around the Data API and either the Go SDK Generator or Terraform Generator - such that these can more easily be run in automation without external tooling (such as Docker).

The primary reason for this tool is to ensure that this can be run consistently across platforms, whilst a Bash script could suffice - we can provide more advanced validation with a small Go app.

Several wrappers are available for this tool, which will install the dependencies needed to run this tool in automation:

* `./scripts/automation-generate-go-sdk.sh` - for generating a Go SDK using the Data within the Data API.
* `./scripts/automation-generate-terraform.sh` - for generating Terraform Data Sources & Resources using the Data within the Data API.
