// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func (p *Pipeline) parseDataForService(service services.Service) (*sdkModels.Service, error) {
	// TODO: this isn't fully usable until the Parser package is refactored - so enable this after
	data, err := discovery.DiscoverForService(service, p.opts.RestAPISpecsDirectory)
	if err != nil {
		return nil, fmt.Errorf("discovering for Service %q: %+v", service.Name, err)
	}
	logging.Tracef("Resource Provider is %q", *data.ResourceProvider)

	for version, versionData := range data.DataSetsForAPIVersions {
		logging.Debugf("API Version %q had %d and %d", version, len(versionData.FilePathsContainingAPIDefinitions), len(versionData.FilePathsContainingSupplementaryData))
	}
	return nil, fmt.Errorf("TODO")
}
