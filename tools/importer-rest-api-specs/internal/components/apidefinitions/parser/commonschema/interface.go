package commonschema

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type Matcher interface {
	// IsMatch returns whether the SDKField implements a CommonSchema ObjectDefinition
	// meaning that the ObjectDefinition used by this SDKField should be replaced by the SDKObjectDefinition
	// defined in ReplacementObjectDefinition.
	IsMatch(field sdkModels.SDKField, resource sdkModels.APIResource) bool

	// ReplacementObjectDefinition returns the replacement SDKObjectDefinition which should be used
	// in place of the parsed SDKObjectDefinition for this SDKField.
	ReplacementObjectDefinition() sdkModels.SDKObjectDefinition
}
