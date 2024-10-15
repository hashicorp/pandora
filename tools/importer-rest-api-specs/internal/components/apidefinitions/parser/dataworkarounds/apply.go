// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

// Apply goes through and determines if any workarounds are required for the Service/API Version
// and applies those - which allows for patching API Definitions to workaround issues; for example a correctness
// issue (a field is defined as an Integer rather than a String), or adding/removing Fields/Models/Constants etc.
//
// These workarounds are intended as a short-term workaround only - so we'll want to ensure there's an accompanying
// pull request to fix the issues in question - else we'll end up diverging overtime/this could become problematic.
func Apply(serviceName string, input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	logging.Debugf("Applying Data Workarounds to the API Version %q..", input.APIVersion)
	output := input
	for _, fix := range workarounds {
		if !fix.IsApplicable(serviceName, output) {
			logging.Tracef("Data Workaround %q is not applicable - skipping..", fix.Name())
			continue
		}

		logging.Tracef("Applying Data Workaround %q..", fix.Name())
		updated, err := fix.Process(output)
		if err != nil {
			return nil, fmt.Errorf("applying Swagger Data Workaround %q to Service %q / API Version %q: %+v", fix.Name(), serviceName, input.APIVersion, err)
		}
		output = *updated
		logging.Tracef("Applying Data Workaround %q - Completed", fix.Name())
	}
	logging.Debugf("Applying Data Workarounds to the API Version %q - Completed", input.APIVersion)
	return &output, nil
}
