package processors

import (
	"strings"
)

var _ FieldNameProcessor = fieldNameRemoveResourcePrefix{}

type fieldNameRemoveResourcePrefix struct{}

func (fieldNameRemoveResourcePrefix) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if strings.HasPrefix(fieldName, metadata.TerraformDetails.ResourceName) {
		updatedName := strings.Replace(fieldName, metadata.TerraformDetails.ResourceName, "", 1)

		// However if the name is now just `Uri` then this field should be renamed to `ServiceUri`
		// Whilst we COULD call this `DataPlaneUri` it's not guaranteed to be a Data Plane
		// therefore Service likely makes more sense as a prefix.
		if strings.EqualFold(updatedName, "Uri") {
			updatedName = "ServiceUri"
		}

		return &updatedName, nil
	}
	return nil, nil
}
