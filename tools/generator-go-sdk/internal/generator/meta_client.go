// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
)

func (s *ServiceGenerator) metaClient(data VersionInput, versionDirectory string, logger hclog.Logger) error {
	if len(data.Resources) == 0 {
		return nil
	}

	var templater templaterForVersion
	if data.UseNewBaseLayer {
		templater = metaClientTemplater{
			serviceName: data.ServiceName,
			apiVersion:  data.VersionName,
			resources:   data.Resources,
			source:      data.Source,
		}
	} else {
		templater = metaClientAutorestTemplater{
			serviceName: data.ServiceName,
			apiVersion:  data.VersionName,
			resources:   data.Resources,
			source:      data.Source,
		}
	}

	if err := s.writeToPathForVersion(versionDirectory, "client.go", templater, logger); err != nil {
		return fmt.Errorf("templating meta client for API Version %q / Service %q: %+v", data.VersionName, data.ServiceName, err)
	}

	return nil
}
