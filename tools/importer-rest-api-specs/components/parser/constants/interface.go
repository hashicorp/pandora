package constants

import (
	"fmt"
	"reflect"
	"regexp"
	"strconv"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"

	"github.com/hashicorp/go-hclog"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type constantExtension struct {
	name string
}

type ParsedConstant struct {
	Name    string
	Details models.ConstantDetails
}

func MapConstant(typeVal spec.StringOrArray, fieldName string, values []interface{}, extensions spec.Extensions, logger hclog.Logger) (*ParsedConstant, error) {
	if len(values) == 0 {
		return nil, fmt.Errorf("Enum in %q has no values", fieldName)
	}

	constantName := fieldName

	// the name needs to come from the `x-ms-enum` extension
	constExtension, err := parseConstantExtensionFromExtension(extensions)
	if err != nil {
		if featureflags.AllowConstantsWithoutXMSEnum {
			logger.Debug(fmt.Sprintf("Field %q had an invalid `x-ms-enum`: %+v", fieldName, err))
		} else {
			return nil, fmt.Errorf("parsing x-ms-enum: %+v", err)
		}
	}
	if constExtension != nil {
		constantName = constExtension.name
	}

	constantType := resourcemanager.StringConstant
	if typeVal.Contains("integer") {
		constantType = resourcemanager.IntegerConstant
	} else if typeVal.Contains("number") {
		constantType = resourcemanager.FloatConstant
	}

	keysAndValues := make(map[string]string)
	for i, raw := range values {
		if constantType == resourcemanager.StringConstant {
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

		if constantType == resourcemanager.IntegerConstant {
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
			val := fmt.Sprintf("%d", int64(value))
			normalizedName := normalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		if constantType == resourcemanager.FloatConstant {
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
		constantType = resourcemanager.StringConstant
	}

	return &ParsedConstant{
		Name: constantName,
		Details: models.ConstantDetails{
			Values:    keysAndValues,
			FieldType: constantType,
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
	for k, v := range enumDetails {
		// presume inconsistencies in the data
		if strings.EqualFold(k, "name") {
			normalizedEnumName := cleanup.NormalizeName(v.(string))
			enumName = &normalizedEnumName
		}

		// NOTE: the Swagger Extension defines `modelAsString` which is used to define whether
		// this should be output as a fixed set of values (e.g. a constant) or an extendable
		// list of strings (e.g. a set of possible string values with other values possible)
		// however we're not concerned with the difference - so we ignore this.
	}
	if enumName == nil {
		return nil, fmt.Errorf("enum details are missing a `name`")
	}

	return &constantExtension{
		name: *enumName,
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
