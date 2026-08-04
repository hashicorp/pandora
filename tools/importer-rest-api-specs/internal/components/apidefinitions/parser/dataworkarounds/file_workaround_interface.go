// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"

// fileWorkaround defines a workaround that filters the list of file paths containing API definitions
// before parsing begins. This is necessary when conflicting swagger files cause hard errors during
// parsing that cannot be fixed by post-parse data workarounds.
type fileWorkaround interface {
	// IsApplicable determines whether this workaround is applicable for this Service / API Version
	IsApplicable(serviceName string, apiVersion string) bool

	// Name returns the Service Name and associated Pull Request number associated with this workaround
	Name() string

	// Process filters the list of file paths, returning only those that should be parsed
	Process(filePaths []string) []string
}

// ApplyFileWorkarounds goes through and determines if any file-level workarounds are required for the
// Service/API Version and applies those - filtering out problematic swagger files before parsing begins.
func ApplyFileWorkarounds(serviceName string, apiVersion string, filePaths []string) []string {
	logging.Debugf("Applying File Workarounds for %q / %q..", serviceName, apiVersion)
	output := filePaths
	for _, fix := range fileWorkarounds {
		if !fix.IsApplicable(serviceName, apiVersion) {
			continue
		}

		logging.Tracef("Applying File Workaround %q..", fix.Name())
		output = fix.Process(output)
		logging.Tracef("Applying File Workaround %q - Completed", fix.Name())
	}
	logging.Debugf("Applying File Workarounds for %q / %q - Completed", serviceName, apiVersion)
	return output
}
