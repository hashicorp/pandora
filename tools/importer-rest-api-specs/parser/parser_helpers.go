package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

	"github.com/go-openapi/spec"
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

	case "int", "integer", "number":
		// NOTE: whilst there's some benefits to mirroring the API insofar as outputting
		// either int32/int64 - from Terraform's perspective we treat them the same so we
		// from a parsing/usability perspective they're similar enough that we can lean on
		// validation to limit this where necessary instead
		return models.Integer

	case "object":
		return models.Object

	case "string":
		return models.String
	}

	panic(fmt.Sprintf("unsupported type conversion %q", input))
}

func parseConstantNameFromField(field spec.Schema) (*string, error) {
	// Constants should always have `x-ms-enum`
	enumDetailsRaw, ok := field.Extensions["x-ms-enum"]
	if !ok {
		return nil, nil
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
	}
	if enumName == nil {
		return nil, fmt.Errorf("enum details are missing a `name`")
	}
	return enumName, nil
}
