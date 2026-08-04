// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import "strings"

var _ fileWorkaround = workaroundInsights45213{}

// workaroundInsights45213 works around an issue where Microsoft's TypeSpec migration for the Insights
// service (2021-05-01-preview) produced a new openapi.json alongside legacy hand-written swagger files.
// Both define operations under the same swagger tag (DiagnosticSettings) with conflicting pagination
// metadata (nextLinkName: "nextLink" vs null), causing a hard parse error.
//
// This workaround removes the legacy files when the TypeSpec-generated openapi.json is present.
//
// Upstream issue: https://github.com/Azure/azure-rest-api-specs/issues/45213
type workaroundInsights45213 struct{}

func (workaroundInsights45213) IsApplicable(serviceName string, apiVersion string) bool {
	return serviceName == "Insights" && apiVersion == "2021-05-01-preview"
}

func (workaroundInsights45213) Name() string {
	return "Insights / 45213"
}

func (workaroundInsights45213) Process(filePaths []string) []string {
	// Only apply if the TypeSpec-generated openapi.json is present
	hasOpenAPIJson := false
	for _, path := range filePaths {
		if strings.HasSuffix(path, "/openapi.json") {
			hasOpenAPIJson = true
			break
		}
	}
	if !hasOpenAPIJson {
		return filePaths
	}

	// Remove the legacy hand-written files whose operations are superseded by openapi.json
	legacyFiles := []string{
		"diagnosticsSettings_API.json",
		"diagnosticsSettingsCategories_API.json",
	}

	output := make([]string, 0, len(filePaths))
	for _, path := range filePaths {
		shouldSkip := false
		for _, legacy := range legacyFiles {
			if strings.HasSuffix(path, "/"+legacy) {
				shouldSkip = true
				break
			}
		}
		if !shouldSkip {
			output = append(output, path)
		}
	}
	return output
}
