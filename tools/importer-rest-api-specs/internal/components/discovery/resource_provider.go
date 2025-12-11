// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"fmt"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func determineDefaultResourceProviderForService(workingDirectory, serviceName string, filePaths []string) (*string, error) {
	usedResourceProviders := make(map[string]struct{})

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
		usedResourceProviders[potentialResourceProvider] = struct{}{}
	}

	if len(usedResourceProviders) > 1 {
		// if we've got multiple Resource Providers and one matches the Service Name, that's the default
		var defaultResourceProvider *string
		for key := range usedResourceProviders {
			// if this ends in `.{ServiceName}` it's _presumably_ the default
			if strings.HasSuffix(strings.ToLower(key), fmt.Sprintf(".%s", strings.ToLower(serviceName))) {
				defaultResourceProvider = pointer.To(key)
				break
			}
		}
		if defaultResourceProvider == nil {
			keys := make([]string, 0)
			for key := range usedResourceProviders {
				keys = append(keys, key)
			}
			sort.Strings(keys)
			return nil, fmt.Errorf("multiple Resource Providers were found for the Service %q and none looked like the default - possible values were %+v - please specify the default resource provider in the configuration file", serviceName, keys)
		}

		return defaultResourceProvider, nil
	}
	if len(usedResourceProviders) == 0 {
		return nil, fmt.Errorf("unable to determine the Resource Provider from the paths %+v", filePaths)
	}
	// otherwise there's only one, so just return that

	var defaultResourceProvider *string
	for key := range usedResourceProviders {
		defaultResourceProvider = pointer.To(key)
	}
	return defaultResourceProvider, nil
}
