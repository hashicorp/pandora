// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: tests

func FindMappingsBetween(input resourcemanager.ModelToModelMappingDefinition, mappings []resourcemanager.FieldMappingDefinition) (*[]resourcemanager.FieldMappingDefinition, error) {
	output := make([]resourcemanager.FieldMappingDefinition, 0)

	for _, item := range mappings {
		switch item.Type {
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				if item.DirectAssignment.SchemaModelName == input.SchemaModelName && item.DirectAssignment.SdkModelName == input.SdkModelName {
					output = append(output, item)
				}
				continue
			}

		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				if item.ModelToModel.SchemaModelName == input.SchemaModelName && item.ModelToModel.SdkModelName == input.SdkModelName {
					output = append(output, item)
				}
				continue
			}

		default:
			{
				return nil, fmt.Errorf("internal-error: unimplemented mapping type %q", string(item.Type))
			}
		}
	}

	return &output, nil
}

func singleFieldNameFromFieldPath(fieldPath string) (*string, error) {
	if strings.ContainsAny(fieldPath, ".") {
		return nil, fmt.Errorf("TODO: implement support for nested field mappings (e.g. `Foo.Bar`)")
	}

	return &fieldPath, nil
}
