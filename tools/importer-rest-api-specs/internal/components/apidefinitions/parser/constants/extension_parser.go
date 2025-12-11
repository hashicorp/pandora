// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package constants

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

type constantExtension struct {
	// name defines the Name that should be used for this Constant
	name string

	// valuesToDisplayNames defines any display name overrides that should be used for this Constant
	// NOTE: whilst the API Definitions may define a value with no display name - this map contains
	// only values with a name defined.
	valuesToDisplayNames map[interface{}]string
}

func parseConstantExtensionFromExtension(input spec.Extensions) (*constantExtension, error) {
	// Constants should always have `x-ms-enum`
	enumDetailsRaw, ok := input["x-ms-enum"]
	if !ok {
		return nil, fmt.Errorf("constant is missing x-ms-enum")
	}

	enumDetails, ok := enumDetailsRaw.(map[string]interface{})
	if !ok {
		return nil, fmt.Errorf("enum details weren't a map[string]interface{}")
	}

	var enumName *string
	var valuesToDisplayNames map[interface{}]string
	for k, v := range enumDetails {
		// presume inconsistencies in the data
		if strings.EqualFold(k, "name") {
			normalizedEnumName := cleanup.NormalizeName(v.(string))
			enumName = &normalizedEnumName
		}

		if strings.EqualFold(k, "values") {
			items := v.([]interface{})
			displayNameOverrides := make(map[interface{}]string)
			for _, itemRaw := range items {
				item := itemRaw.(map[string]interface{})
				name, ok := item["name"].(string)
				if !ok || name == "" {
					// there isn't a custom name defined for this, so we should ignore it
					continue
				}
				value, ok := item["value"].(interface{})
				if !ok {
					continue
				}
				// NOTE: whilst `x-ms-enum` includes a `description` field we don't support that today
				// support for that is tracked in https://github.com/hashicorp/pandora/issues/231

				displayNameOverrides[value] = name
			}
			if len(displayNameOverrides) > 0 {
				valuesToDisplayNames = displayNameOverrides
			}
		}

		// NOTE: the Swagger Extension defines `modelAsString` which is used to define whether
		// this should be output as a fixed set of values (e.g. a constant) or an extendable
		// list of strings (e.g. a set of possible string values with other values possible)
		// however we're not concerned with the difference - so we ignore this.
	}
	if enumName == nil {
		return nil, fmt.Errorf("enum details are missing a `name`")
	}

	output := constantExtension{
		name: *enumName,
	}
	if valuesToDisplayNames != nil {
		output.valuesToDisplayNames = valuesToDisplayNames
	}
	return &output, nil
}
