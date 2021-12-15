# Tool: wrapper-go-sdk-generator

## What is this tool?

This tool provides a convenience wrapper around the Data API and Go SDK Generator such that these can more easily be run in automation without external tooling (such as Docker).

The primary reason for this tool is to ensure that this can be run consistently across platforms, whilst a Bash script could suffice - we can provide more advanced validation with a small Go app.

To run this, use `./scripts/automation-generate-go-sdk`, which will ensure the dependencies are installed.