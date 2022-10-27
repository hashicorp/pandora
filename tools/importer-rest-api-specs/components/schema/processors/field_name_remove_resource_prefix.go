package processors

import "strings"

var _ FieldNameProcessor = fieldNameRemoveResourcePrefix{}

type fieldNameRemoveResourcePrefix struct{}

func (fieldNameRemoveResourcePrefix) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if strings.HasPrefix(fieldName, metadata.TerraformDetails.ResourceName) {
		updatedName := strings.Replace(fieldName, metadata.TerraformDetails.ResourceName, "", 1)
		return &updatedName, nil
	}
	return nil, nil
}
