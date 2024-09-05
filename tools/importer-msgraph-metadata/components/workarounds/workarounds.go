// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var workarounds = []dataWorkaround{
	workaroundODataBind{},
	workaroundRepeatingResourceIdSegments{},

	workaroundApplication{},
	workaroundConditionalAccessPolicy{},
}

var serviceWorkarounds = []serviceWorkaround{
	workaroundSynchronizationSecrets{},
}

type workaround interface {
	// Name returns the Service Name and associated Pull Request number
	Name() string
}

type dataWorkaround interface {
	workaround

	// Process performs any necessary fixes to constants, models and/or resource IDs
	Process(string, parser.Models, parser.Constants, parser.ResourceIds) error
}

type serviceWorkaround interface {
	workaround

	// Process performs any necessary fixes to resources
	Process(string, string, parser.Resources, parser.ResourceIds) error
}

// ApplyWorkarounds invokes the specified workarounds for models, constants and resource
func ApplyWorkarounds(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	logging.Tracef("Processing Data Workarounds..")
	for _, fix := range workarounds {
		logging.Tracef("Applying Data Workaround %q", fix.Name())
		if err := fix.Process(apiVersion, models, constants, resourceIds); err != nil {
			return fmt.Errorf("applying Data Workaround %q: %v", fix.Name(), err)
		}
	}

	return nil
}

// ApplyWorkaroundsForService invokes the specified workarounds for a given service
func ApplyWorkaroundsForService(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	logging.Tracef("Processing Service Workarounds for %s..", serviceName)
	for _, fix := range serviceWorkarounds {
		logging.Tracef("Applying Service Workaround %q", fix.Name())
		if err := fix.Process(apiVersion, serviceName, resources, resourceIds); err != nil {
			return fmt.Errorf("applying Service Workaround %q: %v", fix.Name(), err)
		}
	}

	return nil
}
