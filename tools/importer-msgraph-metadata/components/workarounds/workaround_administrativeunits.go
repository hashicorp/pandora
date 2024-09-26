// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
)

var _ serviceWorkaround = workaroundAdministrativeUnits{}

// workaroundAdministrativeUnits removes nonexistent `AdministrativeUnit` resources from the `Directory` service in
// the beta API, as these resources exist in the `administrativeUnits` service for this API version.
type workaroundAdministrativeUnits struct{}

func (workaroundAdministrativeUnits) Name() string {
	return "Administrative Units / remove nonexistent resources"
}

func (workaroundAdministrativeUnits) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	if apiVersion != versions.ApiVersionBeta {
		return nil
	}

	if serviceName != "directory" {
		return nil
	}

	resourcesToDelete := make([]string, 0)
	for resourceName := range resources {
		if strings.HasPrefix(resourceName, "DirectoryAdministrativeUnit") {
			resourcesToDelete = append(resourcesToDelete, resourceName)
		}
	}

	for _, resourceName := range resourcesToDelete {
		delete(resources, resourceName)
	}

	return nil
}
