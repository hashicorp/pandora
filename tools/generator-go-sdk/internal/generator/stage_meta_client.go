// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

func (s *Generator) metaClient(data VersionGeneratorData) error {
	if len(data.resources) == 0 {
		return nil
	}

	var templater templaterForVersion
	if data.useNewBaseLayer {
		templater = metaClientTemplater{
			apiVersionDirectoryName: data.versionDirectoryName,
			apiVersionPackageName:   data.versionPackageName,
			baseClientPackage:       data.baseClientPackage,
			resources:               data.resources,
			serviceName:             data.servicePackageName,
			source:                  data.source,
			sourceType:              data.sourceType,
		}
	} else {
		templater = metaClientAutorestTemplater{
			apiVersionDirectoryName: data.versionDirectoryName,
			apiVersionPackageName:   data.versionPackageName,
			resources:               data.resources,
			serviceName:             data.servicePackageName,
			source:                  data.source,
			sourceType:              data.sourceType,
		}
	}

	if err := s.writeToPathForVersion(data.versionOutputPath, "client.go", templater); err != nil {
		return fmt.Errorf("templating meta client for API Version %q / Service %q: %+v", data.versionPackageName, data.servicePackageName, err)
	}

	return nil
}
