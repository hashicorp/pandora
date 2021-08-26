package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type customFieldMatcher interface {
	customFieldType() models.CustomFieldType

	isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool
}
