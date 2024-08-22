// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var workarounds = []workaround{
	workaroundODataBind{},
	workaroundRepeatingResourceIdSegments{},

	workaroundApplication{},
	workaroundConditionalAccessPolicy{},
}

type workaround interface {
	// Name returns the Service Name and associated Pull Request number
	Name() string

	// Process performs any necessary fixes to constants, models and/or resource IDs
	Process(string, parser.Models, parser.Constants, parser.ResourceIds) error
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
