package parser

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

type constantExtension struct {
	name          string
	modelAsString bool
}

type parsedConstant struct {
	name    string
	details models.ConstantDetails
}

func mapConstant(typeVal spec.StringOrArray, values []interface{}, extensions spec.Extensions) (*parsedConstant, error) {
	// the name needs to come from the `x-ms-enum` extension
	constExtension, err := parseConstantExtensionFromExtension(extensions)
	if err != nil {
		return nil, fmt.Errorf("parsing `x-ms-enum` extension: %+v", err)
	}

	constantType := models.StringConstant
	if typeVal.Contains("integer") {
		constantType = models.IntegerConstant
	} else if typeVal.Contains("number") {
		constantType = models.FloatConstant
	}

	keysAndValues := make(map[string]string)
	for i, raw := range values {
		if constantType == models.StringConstant {
			value, ok := raw.(string)
			if !ok {
				return nil, fmt.Errorf("expected a string but got %+v for the %d value for %q", raw, i, constExtension.name)
			}
			// Some numbers are modelled as strings
			if numVal, err := strconv.ParseFloat(value, 64); err == nil {
				if strings.Contains(value, ".") {
					normalizedName := cleanup.NormalizeConstantKey(value)
					keysAndValues[normalizedName] = value
					continue
				} else {
					key := keyValueForInteger(int64(numVal))
					val := fmt.Sprintf("%d", int64(numVal))
					normalizedName := cleanup.NormalizeConstantKey(key)
					keysAndValues[normalizedName] = val
					continue
				}
			}
			normalizedName := cleanup.NormalizeConstantKey(value)
			keysAndValues[normalizedName] = value
			continue
		}

		if constantType == models.IntegerConstant {
			// this gets parsed out as a float64 even though it's an Integer :upside_down_smile:
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an integer but got %+v for the %d value for %q", raw, i, constExtension.name)
			}

			key := keyValueForInteger(int64(value))
			val := fmt.Sprintf("%d", int64(value))
			normalizedName := cleanup.NormalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		if constantType == models.FloatConstant {
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an float but got %+v for the %d value for %q", raw, i, constExtension.name)
			}

			key := keyValueForFloat(value)
			val := stringValueForFloat(value)
			normalizedName := cleanup.NormalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		return nil, fmt.Errorf("unsupported constant type %q", string(constantType))
	}

	// allows us to parse out the actual types above then force a string here if needed
	if constExtension.modelAsString {
		constantType = models.StringConstant
	}

	return &parsedConstant{
		name: constExtension.name,
		details: models.ConstantDetails{
			Values:    keysAndValues,
			FieldType: constantType,
		},
	}, nil
}

func parseConstantExtensionFromExtension(field spec.Extensions) (*constantExtension, error) {
	// Constants should always have `x-ms-enum`
	enumDetailsRaw, ok := field["x-ms-enum"]
	if !ok {
		return nil, nil
	}

	enumDetails, ok := enumDetailsRaw.(map[string]interface{})
	if !ok {
		return nil, fmt.Errorf("enum details weren't a map[string]interface{}")
	}

	var enumName *string
	modelAsString := true // assuming this can be omitted
	for k, v := range enumDetails {
		// presume inconsistencies in the data
		if strings.EqualFold(k, "name") {
			normalizedEnumName := cleanup.NormalizeName(v.(string))
			enumName = &normalizedEnumName
		}

		if strings.EqualFold(k, "modelAsString") {
			val, ok := v.(bool)
			if !ok {
				return nil, fmt.Errorf("expected a bool for `modelAsString` but got %+v", v)
			}
			modelAsString = val
		}
	}
	if enumName == nil {
		return nil, fmt.Errorf("enum details are missing a `name`")
	}

	return &constantExtension{
		name:          *enumName,
		modelAsString: modelAsString,
	}, nil
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
	return cleanup.StringifyNumberInput(stringified)
}

func stringValueForFloat(value float64) string {
	return strconv.FormatFloat(value, 'f', -1, 64)
}
