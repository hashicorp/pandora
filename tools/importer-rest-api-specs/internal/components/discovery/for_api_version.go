// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"fmt"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

// discoverDataSetForAPIVersion parses a set of filePaths and identifies the files which contain API Definitions for the API Version.
func discoverDataSetForAPIVersion(apiVersion string, filePaths []string) (*models.AvailableDataSetForAPIVersion, error) {
	// handle this being Stable/Preview etc
	// e.g. /2020-02-01/ to ensure we don't unintentionally also bring in Preview API versions
	apiVersionDirectory := fmt.Sprintf("%c%s%c", filepath.Separator, apiVersion, filepath.Separator)

	// first find the files applicable to this API Version
	filePathsForThisAPIVersion := make([]string, 0)
	for _, filePath := range filePaths {
		if strings.Contains(filePath, apiVersionDirectory) {
			// We need to ignore Examples at this point to handle both TypeSpec and Swagger examples
			// TypeSpec examples live within `./{service}/{namespace}/examples/{apiVersion}/{fileName}`
			// Swagger examples live within `./{service}/resource-manager/(stable|preview)/{apiVersion}/examples/{fileName}`
			// So just handling the directory name here is fine
			shouldIgnore := false
			for _, item := range strings.Split(filePath, fmt.Sprintf("%c", filepath.Separator)) {
				if strings.EqualFold(item, "data-plane") {
					logging.Tracef("File contains `data-plane`, skipping..")
					shouldIgnore = true
					break
				}
				if strings.EqualFold(item, "examples") {
					logging.Trace("File contains examples, skipping..")
					shouldIgnore = true
					break
				}
			}
			if shouldIgnore {
				continue
			}

			filePathsForThisAPIVersion = append(filePathsForThisAPIVersion, filePath)
		}
	}
	if len(filePathsForThisAPIVersion) == 0 {
		return nil, fmt.Errorf("couldn't find any files for the API Version %q. Paths %+v", apiVersionDirectory, filePaths)
	}

	// now that we know which files are available, let's go through and bucket them
	filePathsContainingAPIDefinitions := make([]string, 0)
	for _, filePath := range filePathsForThisAPIVersion {
		logging.Tracef("Processing %q..", filePath)
		// However since there's multiple different directory structures, we only need to pull out the files within the directory for this API Version
		// so let's split the string
		components := strings.Split(filePath, apiVersionDirectory)
		if len(components) == 1 {
			// if this is just the top-level directory it's not going to be much use
			logging.Tracef("Skipping %q since it looks like the top-level directory..", filePath)
			continue
		}

		relativeFilePath := components[1]
		components = strings.Split(relativeFilePath, fmt.Sprintf("%c", filepath.Separator))
		if !strings.HasSuffix(strings.ToLower(relativeFilePath), ".json") {
			// non-JSON files aren't interesting at this time
			logging.Trace("File doesn't contain JSON - skipping..")
			continue
		}

		filePathsContainingAPIDefinitions = append(filePathsContainingAPIDefinitions, filePath)
	}

	sort.Strings(filePathsContainingAPIDefinitions)

	containsStableAPIVersion := isStableAPIVersion(apiVersion)
	return &models.AvailableDataSetForAPIVersion{
		APIVersion:                        apiVersion,
		ContainsStableAPIVersion:          containsStableAPIVersion,
		FilePathsContainingAPIDefinitions: filePathsContainingAPIDefinitions,
	}, nil
}

func isStableAPIVersion(input string) bool {
	val := strings.ToLower(input)
	if strings.Contains(val, "-alpha") {
		return false
	}
	if strings.Contains(val, "-beta") {
		return false
	}
	if strings.Contains(val, "-privatepreview") {
		return false
	}
	if strings.Contains(val, "-preview") {
		return false
	}
	if strings.Contains(val, "-publicpreview") {
		return false
	}

	logging.Tracef("API Version %q appears to be a Stable API Version", input)
	return true
}
