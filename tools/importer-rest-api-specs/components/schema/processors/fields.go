package processors

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type FieldNameProcessor interface {
	ProcessField(fieldName string, metadata FieldMetadata) (*string, error)
}

type FieldMetadata struct {
	TerraformDetails resourcemanager.TerraformResourceDetails
	Model            resourcemanager.ModelDetails
	Constants        map[string]resourcemanager.ConstantDetails
}

//var NamingRules = []FieldNameProcessor{
//	// Exists should be first rule in the list since that checks whether the field even exists in the model
//	fieldNameExists{},
//	fieldNameRemoveIsPrefix{},
//	fieldNamePluralToSingular{},
//	fieldNameRemoveResourcePrefix{},
//	fieldNameRenameBoolean{},
//	fieldNameRenameMislabelledResourceID{},
//	fieldNameMaxToMaximum{},
//	//TODO perhaps this should be applied somewhere else since it should apply to all possible fields in a schema
//	// currently this would only apply to fields that exist in the Properties model, but we may not want to apply
//	// all of the processors above to fields that are taken from the resource ID
//	fieldNameSchemaOverrideRename{},
//}

var NamingRules = map[string]FieldNameProcessor{
	// Exists should be first rule in the list since that checks whether the field even exists in the model
	"Exists":                fieldNameExists{},
	"RemoveIsPrefix":        fieldNameRemoveIsPrefix{},
	"PluralToSingular":      fieldNamePluralToSingular{},
	"RemoveResourcePrefix":  fieldNameRemoveResourcePrefix{},
	"RenameBoolean":         fieldNameRenameBoolean{},
	"MislabelledResourceID": fieldNameRenameMislabelledResourceID{},
	"MaxToMinimum":          fieldNameMaxToMaximum{},
	"SchemaOverrides":       fieldNameSchemaOverrideRename{},
}

//TODO: Below is a list common scenarios which might require a processor
//TODO: if it's a List[Reference] and the model contains a single field `Id` then flatten this into `_ids`.
//TODO: if the field is named `id` within a block rename it to `{block}_id`
//TODO: fields containing discriminators - for now we should skip the resource/raise an error if there's a discriminator involved
//TODO: when the field `properties` is a reference to a model, move fields from the 'properties' model up into the parent model
//TODO: handling the top level field `sku`
//TODO: if there's multiple fields with the same prefix, should we put these into a block?
//TODO: maybe done? if the model contains a single model, eliminate the wrapper model
//TODO: When a model hierarchy results in _just_ a list of primitives, flatten that back up to a field of list type e.g. Search Service NetworkRuleset > Properties > IpRules > List<string> (https://github.com/Azure/azure-rest-api-specs/blob/e21f2da8dacad060a3612dc8ae0fe6de48b15986/specification/search/resource-manager/Microsoft.Search/stable/2020-08-01/search.json#L1361)
