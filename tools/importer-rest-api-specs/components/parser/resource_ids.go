// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (d *SwaggerDefinition) ParseResourceIds() (*resourceids.ParseResult, error) {
	parser := resourceids.NewParser(d.swaggerSpecExpanded)

	resourceIds, err := parser.Parse()
	if err != nil {
		return nil, fmt.Errorf("finding Resource IDs: %+v", err)
	}

	return resourceIds, nil
}

func (d *SwaggerDefinition) filterResourceIdsToResourceProvider(input resourceids.ParseResult, resourceProvider string) (*resourceids.ParseResult, error) {
	output := resourceids.ParseResult{
		OperationIdsToParsedResourceIds: input.OperationIdsToParsedResourceIds,
		NamesToResourceIDs:              map[string]sdkModels.ResourceID{},
		Constants:                       input.Constants,
	}

	for name := range input.NamesToResourceIDs {
		value := input.NamesToResourceIDs[name]

		logging.Tracef("Processing ID %q (%q)", name, helpers.DisplayValueForResourceID(value))
		usesADifferentResourceProvider, err := resourceIdUsesAResourceProviderOtherThan(pointer.To(value), pointer.To(resourceProvider))
		if err != nil {
			return nil, err
		}

		if !*usesADifferentResourceProvider {
			output.NamesToResourceIDs[name] = value
		}
	}

	return &output, nil
}
