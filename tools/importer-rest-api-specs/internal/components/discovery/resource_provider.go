// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func determineResourceProviderForService(workingDirectory string, filePaths []string) (*string, error) {
	var resourceProvider *string

	for _, path := range filePaths {
		relative := strings.TrimPrefix(path, workingDirectory)
		relative = strings.TrimPrefix(relative, fmt.Sprintf("%c", filepath.Separator))
		components := strings.Split(relative, fmt.Sprintf("%c", filepath.Separator))
		if len(components) == 1 || components[0] != "resource-manager" {
			continue
		}
		// Resource Providers are TYPICALLY `Microsoft.XXX` however can be third-party namespaces and so
		// provided it contains a dot within `./resource-manager/` it's reasonable.
		potentialResourceProvider := components[1]
		if !strings.Contains(potentialResourceProvider, ".") {
			logging.Tracef("Didn't find a Resource Provider in the path %q", path)
			continue
		}
		if resourceProvider == nil {
			resourceProvider = pointer.To(potentialResourceProvider)
			continue
		}

		if *resourceProvider != potentialResourceProvider {
			return nil, fmt.Errorf("found multiple Resource Providers - %q and %q - the config needs to define which is the default", *resourceProvider, potentialResourceProvider)
		}
	}

	if resourceProvider == nil {
		return nil, fmt.Errorf("unable to determine the Resource Provider from the paths %+v", filePaths)
	}
	return resourceProvider, nil
}
