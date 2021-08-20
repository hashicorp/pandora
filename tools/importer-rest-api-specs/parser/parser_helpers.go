package parser

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func fieldIsRequired(required []string, key string) bool {
	isRequired := false
	for _, v := range required {
		// assume data inconsistencies
		if strings.EqualFold(v, key) {
			isRequired = true
		}
	}
	return isRequired
}

func inlinedModelName(parentModelName, fieldName string) string {
	// intentionally split out for consistency
	val := fmt.Sprintf("%s%s", strings.Title(parentModelName), strings.Title(fieldName))
	return cleanup.NormalizeName(val)
}

func normalizeType(input string) models.FieldDefinitionType {
	switch strings.ToLower(input) {
	case "array":
		return models.List

	case "boolean":
		return models.Boolean

	case "int", "integer":
		// NOTE: whilst there's some benefits to mirroring the API insofar as outputting
		// either int32/int64 - from Terraform's perspective we treat them the same so we
		// from a parsing/usability perspective they're similar enough that we can lean on
		// validation to limit this where necessary instead
		return models.Integer

	case "object":
		return models.Object

	case "number":
		// NOTE: whilst there's some benefits to mirroring the API insofar as outputting
		// either float32/float64 - from Terraform's perspective we treat them the same so we
		// from a parsing/usability perspective they're similar enough that we can lean on
		// validation to limit this where necessary instead
		return models.Float

	case "string":
		return models.String
	}

	panic(fmt.Sprintf("unsupported type conversion %q", input))
}

func parseConstantNameFromExtension(field spec.Extensions) (*string, error) {
	details, err := parseConstantExtensionFromExtension(field)
	if err != nil {
		return nil, err
	}

	if details == nil {
		return nil, nil
	}

	return &details.name, nil
}

type constantExtension struct {
	name          string
	modelAsString bool
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
