// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package constants

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"reflect"
	"regexp"
	"strconv"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
)

type constantExtension struct {
	// name defines the Name that should be used for this Constant
	name string

	// valuesToDisplayNames defines any display name overrides that should be used for this Constant
	// NOTE: whilst the API Definitions may define a value with no display name - this map contains
	// only values with a name defined.
	valuesToDisplayNames *map[interface{}]string
}

type ParsedConstant struct {
	Name    string
	Details models.SDKConstant
}

func MapConstant(typeVal spec.StringOrArray, fieldName string, modelName *string, values []interface{}, extensions spec.Extensions) (*ParsedConstant, error) {
	if len(values) == 0 {
		return nil, fmt.Errorf("Enum in %q has no values", fieldName)
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
				constantName = constantPrefix + strings.Title(fieldName)
				logging.Debugf("Field %q renamed to %q", fieldName, constantName)
			}

		} else {
			return nil, fmt.Errorf("parsing x-ms-enum: %+v", err)
		}
	}
	if constExtension != nil {
		constantName = constExtension.name
	}

	constantType := models.StringSDKConstantType
	if typeVal.Contains("integer") {
		constantType = models.IntegerSDKConstantType
	} else if typeVal.Contains("number") {
		constantType = models.FloatSDKConstantType
	}

	keysAndValues := make(map[string]string)
	for i, raw := range values {
		if constantType == models.StringSDKConstantType {
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

		if constantType == models.IntegerSDKConstantType {
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
				overrideName, hasOverride := (*constExtension.valuesToDisplayNames)[value]
				if hasOverride {
					key = overrideName
				}
			}

			val := fmt.Sprintf("%d", int64(value))
			normalizedName := normalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		if constantType == models.FloatSDKConstantType {
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

		return nil, fmt.Errorf("unsupported constant type %q", string(constantType))
	}

	// allows us to parse out the actual types above then force a string here if needed
	if constExtension == nil {
		constantType = models.StringSDKConstantType
	}

	return &ParsedConstant{
		Name: constantName,
		Details: models.SDKConstant{
			Values: keysAndValues,
			Type:   constantType,
		},
	}, nil
}

func parseConstantExtensionFromExtension(field spec.Extensions) (*constantExtension, error) {
	// Constants should always have `x-ms-enum`
	enumDetailsRaw, ok := field["x-ms-enum"]
	if !ok {
		return nil, fmt.Errorf("constant is missing x-ms-enum")
	}

	enumDetails, ok := enumDetailsRaw.(map[string]interface{})
	if !ok {
		return nil, fmt.Errorf("enum details weren't a map[string]interface{}")
	}

	var enumName *string
	var valuesToDisplayNames *map[interface{}]string
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
				valuesToDisplayNames = &displayNameOverrides
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

func keyValueForInteger(value int64) string {
	s := fmt.Sprintf("%d", value)
	vals := map[int32]string{
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	out := ""
	for _, c := range s {
		v, ok := vals[c]
		if !ok {
			panic(fmt.Sprintf("missing mapping for %q", string(c)))
		}
		out += v
	}

	return out
}

func keyValueForFloat(value float64) string {
	stringified := stringValueForFloat(value)
	return stringifyNumberInput(stringified)
}

func stringValueForFloat(value float64) string {
	return strconv.FormatFloat(value, 'f', -1, 64)
}

func normalizeConstantKey(input string) string {
	output := input
	output = stringifyNumberInput(output)
	if !strings.Contains(output, "Point") {
		output = renameMultiplesOfZero(output)
	}

	output = strings.ReplaceAll(output, "*", "Any")
	// TODO: add more if we find them

	output = cleanup.NormalizeName(output)
	return output
}

func stringifyNumberInput(input string) string {
	vals := map[int32]string{
		'.': "Point",
		'+': "Positive",
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	output := ""
	for _, c := range input {
		v, ok := vals[c]
		if !ok {
			output += string(c)
			continue
		}
		output += v
	}
	return output
}

func renameMultiplesOfZero(input string) string {
	if strings.HasPrefix(input, "Zero") && !strings.HasSuffix(input, "Zero") {
		return input
	}

	re := regexp.MustCompile("(?:Zero)")
	zeros := re.FindAllStringIndex(input, -1)
	z := len(zeros)

	if z < 2 {
		return input
	}

	vals := map[int]string{
		2: "Hundred",
		3: "Thousand",
		4: "Thousand",
		5: "HundredThousand",
		6: "Million",
	}

	if v, ok := vals[z]; ok {
		switch z {
		case 4:
			return strings.Replace(input, strings.Repeat("Zero", z), "Zero"+v, 1)
		default:
			return strings.Replace(input, strings.Repeat("Zero", z), v, 1)
		}
	}

	return input
}
