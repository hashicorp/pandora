package schema

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/schema-playground/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

/*
Things to do here:

1. Build the Schema
2. Ensure when we output each field we also output how to map from the model to it (we can then infer the inverse)
3. Schema Fields needs to also account for Resource ID fields too
4. Output the Schema into the Typed DSL Steve/Matthew are working on
*/

type Builder struct {
	constants   map[string]resourcemanager.ConstantDetails
	models      map[string]resourcemanager.ModelDetails
	resourceIds map[string]resourcemanager.ResourceIdDefinition
}

func NewBuilder(constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails, resourceIds map[string]resourcemanager.ResourceIdDefinition) Builder {
	return Builder{
		constants:   constants,
		models:      models,
		resourceIds: resourceIds,
	}
}

func (b Builder) Build(input models.ResourceCandidate) (*models.SchemaDefinition, error) {
	// TODO: we should look to skip any resources containing discriminators initially, for example.

	createReadUpdateMethods := b.findCreateUpdateReadPayloads(input)
	if createReadUpdateMethods == nil {
		return nil, nil
	}
	// find each of the "common" top level fields, excluding `properties`
	topLevelFields, err := b.identifyTopLevelFields(*createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	schemaFields := make(map[string]models.FieldDefinition)
	for k, v := range topLevelFields.toSchema() {
		schemaFields[k] = v
	}

	fieldsWithinResourceId, err := b.identityTopLevelFieldsWithinResourceID(input.ResourceId)
	if err != nil {
		return nil, fmt.Errorf("identifying top level fields within Resource ID %q: %+v", input.ResourceId.Id, err)
	}
	for k, v := range *fieldsWithinResourceId {
		schemaFields[k] = v
	}

	fieldsWithinProperties, err := b.identifyFieldsWithinPropertiesBlock(*createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing fields within the `properties` block for the create/read/update methods: %+v", err)
	}
	for k, v := range *fieldsWithinProperties {
		schemaFields[k] = v
	}

	return &models.SchemaDefinition{
		Fields: schemaFields,
	}, nil
}

func (b Builder) identifyTopLevelFields(input operationPayloads) (*topLevelFields, error) {
	allFields := make(map[string]struct{}, 0)
	for _, model := range input.createReadUpdatePayloads() {
		for k := range model.Fields {
			allFields[k] = struct{}{}
		}
	}

	out := topLevelFields{}
	for k := range allFields {
		// TODO: ExtendedLocation, SystemData as Computed etc?
		if strings.EqualFold(k, "Identity") {
			field, ok := getField(input.createPayload, k)
			if !ok {
				continue
			}

			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			out.identity = &models.FieldDefinition{
				Definition: resourcemanager.ApiObjectDefinition{
					Type: field.ObjectDefinition.Type,
				},
				Required: field.Required,
				Optional: field.Optional,
				ForceNew: !canBeUpdated,
			}
		}

		if strings.EqualFold(k, "Location") {
			out.location = &models.FieldDefinition{
				Definition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.LocationApiObjectDefinitionType,
				},
				Required: true,
				ForceNew: true,
			}
		}

		if strings.EqualFold(k, "Tags") {
			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			out.tags = &models.FieldDefinition{
				Definition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.TagsApiObjectDefinitionType,
				},
				Optional: true,
				ForceNew: !canBeUpdated,
			}
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &out, nil
}

func (b Builder) identityTopLevelFieldsWithinResourceID(input resourcemanager.ResourceIdDefinition) (*map[string]models.FieldDefinition, error) {
	out := make(map[string]models.FieldDefinition, 0)

	if len(input.Segments) > 2 {
		parentSegments := input.Segments[0 : len(input.Segments)-2]
		if segmentsContainResource(parentSegments) {
			// find the parent Resource ID and use that
			parentResourceIdName := ""
			for name, id := range b.resourceIds {
				if segmentsMatch(id.Segments, parentSegments) {
					parentResourceIdName = name
					break
				}
			}
			if parentResourceIdName != "" {
				parentResourceSchemaField := convertToSnakeCase(parentResourceIdName)
				out[parentResourceSchemaField] = models.FieldDefinition{
					Definition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: &parentResourceIdName,
					},
					// since this is included in the Resource ID it's implicitly Required/ForceNew
					Required: true,
					ForceNew: true,
				}
			}

			// TODO: perhaps add the components here instead, aside from Subscription/Tenant ID etc?
		}
	}

	return &out, nil
}

func segmentsMatch(first []resourcemanager.ResourceIdSegment, second []resourcemanager.ResourceIdSegment) bool {
	if len(first) != len(second) {
		return false
	}

	for i, firstVal := range first {
		secondVal := second[i]
		if firstVal.Type != secondVal.Type {
			return false
		}

		if firstVal.Type == resourcemanager.StaticSegment || firstVal.Type == resourcemanager.ResourceProviderSegment {
			if firstVal.FixedValue == nil || secondVal.FixedValue == nil {
				return false
			}

			if *firstVal.FixedValue != *secondVal.FixedValue {
				return false
			}
		}

		if firstVal.Type == resourcemanager.ConstantSegment {
			if firstVal.ConstantReference == nil || secondVal.ConstantReference == nil {
				return false
			}

			if *firstVal.ConstantReference != *secondVal.ConstantReference {
				return false
			}
		}
	}

	return true
}

func segmentsContainResource(input []resourcemanager.ResourceIdSegment) bool {
	penultimateSegmentIsStatic := false
	lastSegmentIsUserSpecifiable := false
	if len(input) >= 4 {
		penultimateSegment := input[len(input)-2]
		lastSegment := input[len(input)-1]

		penultimateSegmentIsStatic = penultimateSegment.Type == resourcemanager.StaticSegment
		lastSegmentIsUserSpecifiable = lastSegment.Type == resourcemanager.UserSpecifiedSegment
	}
	return penultimateSegmentIsStatic && lastSegmentIsUserSpecifiable
}

func (b Builder) identifyFieldsWithinPropertiesBlock(input operationPayloads) (*map[string]models.FieldDefinition, error) {
	allFields := make(map[string]struct{}, 0)
	for _, model := range input.createReadUpdatePayloadsProperties(b.models) {
		for k, v := range model.Fields {
			if fieldShouldBeIgnored(k, v, b.constants) {
				continue
			}

			allFields[k] = struct{}{}
		}
	}

	// find the model for the `properties` field within the read response
	readPropertiesModel := input.getPropertiesModelWithinModel(input.readPayload, b.models)
	createPropertiesModel := input.getPropertiesModelWithinModel(input.createPayload, b.models)
	var updatePropertiesModel *resourcemanager.ModelDetails
	if input.updatePayload != nil {
		updatePropertiesModel = input.getPropertiesModelWithinModel(*input.updatePayload, b.models)
	}

	out := make(map[string]models.FieldDefinition, 0)
	if readPropertiesModel != nil {
		for k := range allFields {
			var readField *resourcemanager.FieldDetails
			hasRead := false
			if readPropertiesModel != nil {
				readField, hasRead = getField(*readPropertiesModel, k)
			}

			var createField *resourcemanager.FieldDetails
			hasCreate := false
			if createPropertiesModel != nil {
				createField, hasCreate = getField(*createPropertiesModel, k)
			}

			var updateField *resourcemanager.FieldDetails
			hasUpdate := false
			if updatePropertiesModel != nil {
				updateField, hasUpdate = getField(*updatePropertiesModel, k)
			}

			// based on this information
			isComputed := false
			isForceNew := false
			isRequired := false
			isOptional := false
			isWriteOnly := false

			if !hasCreate && !hasUpdate && hasRead {
				isComputed = true
			}
			if hasCreate || hasUpdate {
				if !hasRead {
					isWriteOnly = true
					isForceNew = hasUpdate && !updateField.ForceNew
				} else if hasCreate {
					isRequired = createField.Required
					isOptional = createField.Optional
					isForceNew = hasUpdate
				} else if hasUpdate {
					isRequired = updateField.Required
					isOptional = updateField.Optional
					isForceNew = updateField.ForceNew
				}
			}

			typedModelName := ""

			if hasRead {
				typedModelName = b.determineNameForSchemaField(*readPropertiesModel, k)
			} else if hasCreate {
				typedModelName = b.determineNameForSchemaField(*createPropertiesModel, k)
			} else if hasUpdate {
				typedModelName = b.determineNameForSchemaField(*updatePropertiesModel, k)
			}

			schemaFieldName := convertToSnakeCase(typedModelName)
			log.Printf("[DEBUG] Properties Field %q would be output as %q / %q", k, typedModelName, schemaFieldName)

			definition := models.FieldDefinition{
				Required:   isRequired,
				ForceNew:   isForceNew,
				Optional:   isOptional,
				Computed:   isComputed,
				WriteOnly:  isWriteOnly,
				Validation: nil,
				// TODO: also need to add the mappings
			}

			if hasRead {
				definition.Definition = readField.ObjectDefinition
			} else if hasCreate {
				definition.Definition = createField.ObjectDefinition
			} else if hasUpdate {
				definition.Definition = updateField.ObjectDefinition
			}

			out[schemaFieldName] = definition
		}
	}

	return &out, nil
}

func (b Builder) findCreateUpdateReadPayloads(input models.ResourceCandidate) *operationPayloads {
	out := operationPayloads{}

	// For Create/Update operations we're concerned with the Request object
	if input.CreateMethod != nil && input.CreateMethod.Method.RequestObject != nil {
		if input.CreateMethod.Method.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			return nil
		}

		model, isModel := b.models[*input.CreateMethod.Method.RequestObject.ReferenceName]
		if !isModel {
			// not applicable if it's only a string response etc
			return nil
		}

		out.createPayload = model
	}
	if input.UpdateMethod != nil && input.UpdateMethod.Method.RequestObject != nil {
		if input.UpdateMethod.Method.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			return nil
		}

		model, isModel := b.models[*input.UpdateMethod.Method.RequestObject.ReferenceName]
		if !isModel {
			// not applicable if it's only a string response etc
			return nil
		}

		out.updatePayload = &model
	}

	// whereas for Get operations we're concerned with the Response object
	if input.GetMethod != nil && input.GetMethod.Method.ResponseObject != nil {
		if input.GetMethod.Method.ResponseObject.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			return nil
		}

		model, isModel := b.models[*input.GetMethod.Method.ResponseObject.ReferenceName]
		if !isModel {
			// not applicable if it's only a string response etc
			return nil
		}

		out.readPayload = model
	}
	// NOTE: intentionally not including Delete since the payload shouldn't be applicable to users
	return &out
}

// determineNameForSchemaField takes the name of the field in the model, with the model as context, to be able
// to determine which name should be used for this model, following conventions, before snake_casing it.
//
// this also accounts for flattening particular objects, for example when a field references a model with
// a single field named `Id`, we'll flatten the parent field to `name_id`.
func (b Builder) determineNameForSchemaField(input resourcemanager.ModelDetails, fieldName string) string {
	field, ok := getField(input, fieldName)
	if !ok {
		// TODO: tbh we should probably error but I guess we can safe-check this for now..
		return fieldName
	}

	// remove the `is_` prefix (e.g. `is_active` -> `active`)
	if strings.HasPrefix(strings.ToLower(fieldName), "is") {
		trimmed := fieldName[2:]
		return trimmed
	}

	// flip `enable_X` / `disable_X` prefix
	if strings.HasPrefix(strings.ToLower(fieldName), "enable") {
		trimmed := fieldName[6:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}
	if strings.HasPrefix(strings.ToLower(fieldName), "disable") {
		trimmed := fieldName[7:]
		return fmt.Sprintf("%sDisabled", trimmed)
	}

	// change `allowed_X` prefix -> `X_enabled`
	if strings.HasPrefix(strings.ToLower(fieldName), "allowed") {
		trimmed := fieldName[7:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}
	// change `allow_X` prefix -> `X_enabled`
	if strings.HasPrefix(strings.ToLower(fieldName), "allow") {
		trimmed := fieldName[5:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}

	// if it's a Reference and the model contains a single field `Id` then flatten this into an `_id` field.
	if field.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
		model, ok := b.models[*field.ObjectDefinition.ReferenceName]
		if ok {
			if len(model.Fields) == 1 {
				if _, ok := getField(model, "Id"); ok {
					return fmt.Sprintf("%sId", fieldName)
				}
			}
		}
	}

	// TODO: if it's a List[Reference] and the model contains a single field `Id` then flatten this into `_ids`.
	// TODO: handling booleans `SomeBool` -> `SomeBoolEnabled` etc.
	// TODO: Singularizing plural names when it's a List (e.g. `planets` -> `planet`)
	// TODO: handle `is_XXX` -> `XXX`
	// TODO: if the field contains the same prefix as the resource, remove the prefix (e.g. `/msixPackages/` and `package_family_name`)
	// TODO: if there's multiple fields with the same prefix, should we put these into a block?
	// TODO: fields containing discriminators
	// TODO: if the model contains a single model, eliminate the wrapper model
	// TODO: if the field is named `id` within a block rename it to `{block}_id`

	return fieldName
}
