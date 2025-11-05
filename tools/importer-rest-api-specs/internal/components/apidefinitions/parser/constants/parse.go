// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package constants

import (
	"fmt"
	"reflect"
	"strconv"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/go-openapi/spec"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

type ParsedConstant struct {
	Name    string
	Details sdkModels.SDKConstant
}

func Parse(typeVal openapi3.Types, fieldName string, modelName *string, values []interface{}, extensions spec.Extensions) (*ParsedConstant, error) {
	if len(values) == 0 {
		return nil, fmt.Errorf("the Enum in %q has no values", fieldName)
	}

	constantName := fieldName

	// the name needs to come from the `x-ms-enum` extension
	constExtension, err := parseConstantExtensionFromExtension(extensions)
	if err != nil {
		if featureflags.AllowConstantsWithoutXMSEnum {
			logging.Debugf("Field %q had an invalid `x-ms-enum`: %+v", fieldName, err)
			// this attempts to construct a unique name for a constant out of the model name and field name
			// to prevent duplicate definitions of constants, specifically constants called `type`
			// of which there are several in data factory (#3725)
			if strings.EqualFold(fieldName, "type") && modelName != nil {
				constantPrefix := strings.TrimSuffix(*modelName, "Type")
				constantName = constantPrefix + cleanup.Title(fieldName)
				logging.Debugf("Field %q renamed to %q", fieldName, constantName)
			}

		} else {
			return nil, fmt.Errorf("parsing x-ms-enum: %+v", err)
		}
	}
	if constExtension != nil {
		constantName = constExtension.name
	}

	constantType := sdkModels.StringSDKConstantType
	if typeVal.Is("integer") {
		constantType = sdkModels.IntegerSDKConstantType
	} else if typeVal.Is("number") {
		constantType = sdkModels.FloatSDKConstantType
	}

	keysAndValues, err := parseKeysAndValues(values, constantType, constExtension)
	if err != nil {
		return nil, fmt.Errorf("parsing keys/values: %+v", err)
	}

	// allows us to parse out the actual types above then force a string here if needed
	if constExtension == nil {
		constantType = sdkModels.StringSDKConstantType
	}

	return &ParsedConstant{
		Name: cleanup.Title(constantName),
		Details: sdkModels.SDKConstant{
			Values: keysAndValues,
			Type:   constantType,
		},
	}, nil
}

func parseKeysAndValues(input []interface{}, constantType sdkModels.SDKConstantType, constExtension *constantExtension) (map[string]string, error) {
	keysAndValues := make(map[string]string)
	for i, raw := range input {
		if constantType == sdkModels.StringSDKConstantType {
			value, ok := raw.(string)
			if !ok {
				return nil, fmt.Errorf("expected a string but got %+v for the %d value for %q", raw, i, constExtension.name)
			}
			// Some numbers are modelled as strings
			if numVal, err := strconv.ParseFloat(value, 64); err == nil {
				if strings.Contains(value, ".") {
					normalizedName := normalizeConstantKey(value)
					keysAndValues[normalizedName] = value
					continue
				}

				key := keyValueForInteger(int64(numVal))
				val := fmt.Sprintf("%d", int64(numVal))
				normalizedName := normalizeConstantKey(key)
				keysAndValues[normalizedName] = val
				continue
			}
			normalizedName := normalizeConstantKey(value)
			keysAndValues[normalizedName] = value
			continue
		}

		if constantType == sdkModels.IntegerSDKConstantType {
			// This gets parsed out as a float64 even though it's an Integer :upside_down_smile:
			value, ok := raw.(float64)
			if !ok {
				// Except sometimes it's actually a string. That's numberwang.
				v, ok := raw.(string)
				if !ok {
					typeName := reflect.TypeOf(raw).Name()
					return nil, fmt.Errorf("expected a float64/string but got type %q value %+v for at index %d for %q", typeName, raw, i, constExtension.name)
				}

				val, err := strconv.Atoi(v)
				if err != nil {
					return nil, fmt.Errorf("converting string value %q to an integer: %+v", v, err)
				}

				value = float64(val)
			}

			key := keyValueForInteger(int64(value))
			// if an override name is defined for this Constant then we should use it
			if constExtension != nil && constExtension.valuesToDisplayNames != nil {
				overrideName, hasOverride := constExtension.valuesToDisplayNames[value]
				if hasOverride {
					key = overrideName
				}
			}

			val := fmt.Sprintf("%d", int64(value))
			normalizedName := normalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		if constantType == sdkModels.FloatSDKConstantType {
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an float but got %+v for the %d value for %q", raw, i, constExtension.name)
			}

			key := keyValueForFloat(value)
			val := stringValueForFloat(value)
			normalizedName := normalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		return nil, fmt.Errorf("unsupported constant type %q", constantType)
	}

	return keysAndValues, nil
}
