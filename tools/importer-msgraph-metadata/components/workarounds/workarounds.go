// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var workarounds = []workaround{
	workaroundApplication{},
}

type workaround interface {
	// IsApplicable determines whether this workaround is applicable for this AzureApiDefinition
	IsApplicable(string, string, *parser.Model) bool

	// Name returns the Service Name and associated Pull Request number
	Name() string

	// Process takes the apiDefinition and applies the Workaround to this AzureApiDefinition
	Process(*parser.Model) error
}

func ApplyWorkarounds(apiVersion string, models parser.Models) error {
	logging.Tracef("Processing Data Workarounds..")
	for modelName, model := range models {
		for _, fix := range workarounds {
			if fix.IsApplicable(apiVersion, modelName, model) {
				logging.Tracef("Applying Data Workaround %q to Model %q", fix.Name(), modelName)
				if err := fix.Process(model); err != nil {
					return fmt.Errorf("applying Data Workaround %q to Model %q: %v", fix.Name(), modelName, err)
				}
			}
		}
	}

	return nil
}
