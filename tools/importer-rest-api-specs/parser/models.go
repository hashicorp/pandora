package parser

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/constants"
	"log"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) parseModel(name string, input spec.Schema) (*parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// 1. find any constants used within this model
	nestedResult, err := d.findConstantsWithinModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding constants within model: %+v", err)
	}
	if err := result.append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from constants: %+v", err)
	}

	// 2. iterate over the fields and find all of the fields for this model
	fields, nestedResult, err := d.fieldsForModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding fields for model: %+v", err)
	}
	if err := result.append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from fields: %+v", err)
	}

	// if it's just got constants, we can skip it
	if len(*fields) == 0 {
		return &result, nil
	}

	// 3. finally build this model directly
	// Notably, we **DO NOT** load models used by this models here - this is handled once we
	// know all the models which we want to load - to avoid infinite loops
	model, err := d.modelDetailsFromObject(name, input, *fields)
	if err != nil {
		return nil, fmt.Errorf("populating model details for %q: %+v", name, err)
	}
	result.models[name] = *model

	return &result, nil
}

func (d *SwaggerDefinition) findConstantsWithinModel(fieldName string, input spec.Schema, known parseResult) (*parseResult, error) {
	// NOTE: both Models and Fields are passed in here
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	if len(input.Enum) > 0 {
		constant, err := constants.MapConstant(input.Type, fieldName, input.Enum, input.Extensions)
		if err != nil {
			return nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.constants[constant.Name] = constant.Details
	}

	// Check any object that this model inherits from
	if len(input.AllOf) > 0 {
		for _, parent := range input.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			// have we already obtained this model, if so skip it
			if _, alreadyParsedModel := result.models[*fragmentName]; alreadyParsedModel {
				continue
			}

			topLevelModel, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level model %q for constants: %+v", *fragmentName, err)
			}

			nestedResult, err := d.findConstantsWithinModel(*fragmentName, *topLevelModel, result)
			if err != nil {
				return nil, fmt.Errorf("finding constants within parent model %q: %+v", *fragmentName, err)
			}

			if err := result.append(*nestedResult); err != nil {
				return nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}
	}

	for propName, propVal := range input.Properties {
		if d.debugLog {
			log.Printf("[DEBUG] Processing Property %q..", propName)
		}
		// models can contain nested models - either can contain constants, so around we go..
		nestedResult, err := d.findConstantsWithinModel(propName, propVal, result)
		if err != nil {
			return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
		}
		if err := result.append(*nestedResult); err != nil {
			return nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		for propName, propVal := range input.AdditionalProperties.Schema.Properties {
			if d.debugLog {
				log.Printf("[DEBUG] Processing Additional Property %q..", propName)
			}
			// models can contain nested models - either can contain constants, so around we go..
			nestedConstants, err := d.findConstantsWithinModel(propName, propVal, result)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			if err := result.append(*nestedConstants); err != nil {
				return nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}
	}

	return &result, nil
}

func (d *SwaggerDefinition) detailsForField(modelName string, propertyName string, value spec.Schema, isRequired bool, known parseResult) (*models.FieldDetails, *parseResult, error) {
	if d.debugLog {
		log.Printf("Parsing details for field %q in %q..", propertyName, modelName)
	}

	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	field := models.FieldDetails{
		Required:  isRequired,
		ReadOnly:  value.ReadOnly, // TODO: generator should handle this in some manner?
		Sensitive: false,          // todo: this probably needs to be a predefined list, unless there's something we can parse
		JsonName:  propertyName,
	}

	// first get the object definition
	objectDefinition, nestedResult, err := d.parseObjectDefinition(modelName, propertyName, &value, result)
	if err != nil {
		return nil, nil, fmt.Errorf("parsing object definition: %+v", err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}

	if len(value.Properties) > 0 {
		// there's a nested model we need to pull out
		inlinedName := inlinedModelName(modelName, propertyName)
		nestedFields := make(map[string]models.FieldDetails, 0)
		for propName, propVal := range value.Properties {
			nestedFieldRequired := false
			for _, field := range value.Required {
				if strings.EqualFold(field, propName) {
					nestedFieldRequired = true
					break
				}
			}
			nestedField, nestedResult, err := d.detailsForField(inlinedName, propName, propVal, nestedFieldRequired, result)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing inlined model %q: %+v", inlinedName, err)
			}
			if err := result.append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
			nestedFields[propName] = *nestedField
		}
		inlinedModelDetails, err := d.modelDetailsFromObject(inlinedName, value, nestedFields)
		if err != nil {
			return nil, nil, fmt.Errorf("building model details for inlined model %q: %+v", inlinedName, err)
		}
		result.models[inlinedName] = *inlinedModelDetails
		// then swap out the reference
		objectDefinition.Type = models.ObjectDefinitionReference
		objectDefinition.ReferenceName = &inlinedName
	}

	// Custom Types are determined once all of the models/constants have been pulled out at the end
	// so just assign this for now
	field.ObjectDefinition = objectDefinition

	return &field, &result, err
}

func determineCustomFieldType(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) *models.CustomFieldType {
	for _, matcher := range customFieldMatchers {
		if matcher.isMatch(field, definition, known) {
			fieldType := matcher.customFieldType()
			return &fieldType
		}
	}

	return nil
}

func (d *SwaggerDefinition) fieldsForModel(modelName string, input spec.Schema, known parseResult) (*map[string]models.FieldDetails, *parseResult, error) {
	fields := make(map[string]models.FieldDetails, 0)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	requiredFields := make(map[string]struct{}, 0)
	for _, k := range input.Required {
		requiredFields[k] = struct{}{}
	}

	// models can inherit from other models, so let's get all of the parent fields here
	for i, parent := range input.AllOf {
		fragmentName := fragmentNameFromReference(parent.Ref)
		if fragmentName == nil {
			// sometimes this is bad data rather than a reference, so it should be skipped, example:
			//  > "allOf": [
			//  >   {
			//  >     "$ref": "#/definitions/AccessReviewDecisionIdentity"
			//  >   },
			//  >   {
			//  >     "type": "object",
			//  >     "description": "AccessReviewDecisionUserIdentity"
			//  >   }
			//  > ],

			// however sometimes these contain actual properties and should be parsed out:
			// > "allOf": [
			// >  {
			// >    "$ref": "#/definitions/DigitalTwinsEndpointResourceProperties"
			// >      },
			// >      {
			// >        "type": "object",
			// >        "properties": {
			// >          "TopicEndpoint": {
			// >            "description": "EventGrid Topic Endpoint",
			// >            "type": "string"
			// >          },
			// >          "accessKey1": {
			// >            "x-ms-secret": true,
			// >            "description": "EventGrid secondary accesskey. Will be obfuscated during read.",
			// >            "type": "string",
			// >          "x-nullable": true
			// >         },
			// >         "accessKey2": {
			// >           "x-ms-secret": true,
			// >           "description": "EventGrid secondary accesskey. Will be obfuscated during read.",
			// >           "type": "string",
			// >           "x-nullable": true
			// >         }
			// >       }
			// >     }
			// >   ]
			// > },

			if parent.Type.Contains("object") {
				innerModelName := modelName
				if parent.Title != "" {
					innerModelName = parent.Title
				}
				parsedParent, nestedResult, err := d.fieldsForModel(innerModelName, parent, known)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing fields within allOf model %q (index %d): %+v", innerModelName, i, err)
				}
				if nestedResult != nil {
					if err := result.append(*nestedResult); err != nil {
						return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
					}
				}
				if parsedParent != nil {
					for k, v := range *parsedParent {
						fields[k] = v
					}
				}
			}

			continue
		}

		topLevelObject, err := d.findTopLevelObject(*fragmentName)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing top level object %q: %+v", *fragmentName, err)
		}
		for _, k := range topLevelObject.Required {
			requiredFields[k] = struct{}{}
		}

		nestedFields, nestedResult, err := d.fieldsForModel(*fragmentName, *topLevelObject, result)
		if err != nil {
			return nil, nil, fmt.Errorf("finding fields for parent model %q: %+v", *fragmentName, err)
		}
		for k, v := range *nestedFields {
			isRequired := isFieldRequired(k, requiredFields)
			v.Required = isRequired
			fields[k] = v
		}
		if nestedResult != nil {
			result.append(*nestedResult)
		}
	}

	// then we get the simple thing of iterating over these fields
	for propName, propVal := range input.Properties {
		isRequired := isFieldRequired(propName, requiredFields)
		field, nestedResult, err := d.detailsForField(modelName, propName, propVal, isRequired, result)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping field %q for %q: %+v", propName, modelName, err)
		}
		if nestedResult != nil {
			if err := result.append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		// whilst we could look to normalize the name we're intentionally not doing so here
		fields[propName] = *field
	}

	return &fields, &result, nil
}

func (d *SwaggerDefinition) findTopLevelObject(name string) (*spec.Schema, error) {
	for modelName, model := range d.swaggerSpecRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	for modelName, model := range d.swaggerSpecExtendedRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	return nil, fmt.Errorf("the top level object %q was not found", name)
}

func (d *SwaggerDefinition) modelDetailsFromObject(modelName string, input spec.Schema, fields map[string]models.FieldDetails) (*models.ModelDetails, error) {
	details := models.ModelDetails{
		Description: "",
		Fields:      fields,
	}

	// if this is a Parent
	if input.Discriminator != "" {
		details.TypeHintIn = &input.Discriminator

		// check that there's at least one implementation of this type - otherwise this this isn't a discriminated type
		// but bad data we should ignore
		implementations := d.findModelNamesWhichImplement(modelName)
		hasAtLeastOneImplementation := len(implementations) > 0
		if !hasAtLeastOneImplementation {
			details.TypeHintIn = nil
		}
	}

	// this would be an Implementation
	if v, ok := input.Extensions.GetString("x-ms-discriminator-value"); ok {
		details.TypeHintValue = &v

		// so we need to find the parent details
		for _, parentRaw := range input.AllOf {
			fragmentName := fragmentNameFromReference(parentRaw.Ref)
			if fragmentName == nil {
				continue
			}

			parent, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level object %q: %+v", *fragmentName, err)
			}

			if parent.Discriminator == "" {
				continue
			}

			details.ParentTypeName = fragmentName
			details.TypeHintIn = &parent.Discriminator
		}

		// however if there's a Discriminator value defined but no parent type - this is bad data - so we should ignore it
		if details.ParentTypeName == nil || details.TypeHintIn == nil {
			details.TypeHintValue = nil
		}
	}

	return &details, nil
}

func (d SwaggerDefinition) parseObjectDefinition(modelName, propertyName string, input *spec.Schema, known parseResult) (*models.ObjectDefinition, *parseResult, error) {
	// find the object and any models and constants etc we can find
	// however _don't_ look for discriminator implementations - since that should be done when we're completely done
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	// if it's an enum then parse that out
	if len(input.Enum) > 0 {
		constant, err := constants.MapConstant(input.Type, propertyName, input.Enum, input.Extensions)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.constants[constant.Name] = constant.Details

		definition := models.ObjectDefinition{
			Type:          models.ObjectDefinitionReference,
			ReferenceName: &constant.Name,
		}
		if input.MaxItems != nil {
			v := int(*input.MaxItems)
			definition.Maximum = &v
		}
		if input.MinItems != nil {
			v := int(*input.MinItems)
			definition.Minimum = &v
		}
		v := input.UniqueItems
		definition.UniqueItems = &v

		return &definition, &result, nil
	}

	// if it's a reference to a model, return that
	if objectName := fragmentNameFromReference(input.Ref); objectName != nil {
		// first find the top level object
		topLevelObject, err := d.findTopLevelObject(*objectName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level model %q: %+v", *objectName, err)
		}

		knownIncludingPlaceholder := parseResult{
			constants: map[string]models.ConstantDetails{},
			models:    map[string]models.ModelDetails{},
		}

		if err := knownIncludingPlaceholder.append(result); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		if *objectName != "" {
			knownIncludingPlaceholder.models[*objectName] = models.ModelDetails{
				// add a placeholder to avoid circular references
			}
		}

		// then call ourselves to work out what to do with it
		objectDefinition, nestedResult, err := d.parseObjectDefinition(*objectName, propertyName, topLevelObject, knownIncludingPlaceholder)
		if err != nil {
			return nil, nil, err
		}
		if nestedResult != nil && *objectName != "" {
			delete(nestedResult.models, *objectName)
		}
		return objectDefinition, nestedResult, nil
	}

	// if it's an inlined model, pull it out and return that
	// note: some models can just be references to other models
	if len(input.Properties) > 0 || len(input.AllOf) > 0 {
		// special-case: if the model has no properties and inherits from one model
		// then just return that object instead, there's no point creating the wrapper type
		if len(input.Properties) == 0 && len(input.AllOf) == 1 {
			inheritedModel := input.AllOf[0]
			return d.parseObjectDefinition(inheritedModel.Title, propertyName, &inheritedModel, result)
		}

		// check for / avoid circular references
		if _, ok := result.models[modelName]; !ok {
			nestedResult, err := d.parseModel(modelName, *input)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing object from inlined model %q: %+v", modelName, err)
			}
			if nestedResult == nil {
				return nil, nil, fmt.Errorf("parsing object from inlined response model %q: no model returned", modelName)
			}
			if err := result.append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		definition := models.ObjectDefinition{
			Type:          models.ObjectDefinitionReference,
			ReferenceName: &modelName,
		}
		if input.MaxItems != nil {
			v := int(*input.MaxItems)
			definition.Maximum = &v
		}
		if input.MinItems != nil {
			v := int(*input.MinItems)
			definition.Minimum = &v
		}
		v := input.UniqueItems
		definition.UniqueItems = &v
		return &definition, &result, nil
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		// it'll be a Dictionary, so pull out the nested item and return that
		// however we need a name for this model
		innerModelName := fmt.Sprintf("%sProperties", propertyName)
		if input.AdditionalProperties.Schema.Title != "" {
			innerModelName = input.AdditionalProperties.Schema.Title
		}

		nestedItem, nestedResult, err := d.parseObjectDefinition(innerModelName, propertyName, input.AdditionalProperties.Schema, result)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: no nested item returned")
		}
		if err := result.append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		return &models.ObjectDefinition{
			Type:       models.ObjectDefinitionDictionary,
			NestedItem: nestedItem,
		}, &result, nil
	}

	if input.Type.Contains("array") && input.Items.Schema != nil {
		inlinedName := input.Items.Schema.Title
		if inlinedName == "" {
			// generate one based on the info we have
			inlinedName = fmt.Sprintf("%s%sInlined", cleanup.NormalizeName(modelName), cleanup.NormalizeName(propertyName))
		}

		nestedItem, nestedResult, err := d.parseObjectDefinition(inlinedName, propertyName, input.Items.Schema, result)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: no nested item returned")
		}

		if input.MaxItems != nil {
			v := int(*input.MaxItems)
			nestedItem.Maximum = &v
		}
		if input.MinItems != nil {
			v := int(*input.MinItems)
			nestedItem.Minimum = &v
		}
		v := input.UniqueItems
		nestedItem.UniqueItems = &v

		if err := result.append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		return &models.ObjectDefinition{
			Type:       models.ObjectDefinitionList,
			NestedItem: nestedItem,
		}, &result, nil
	}

	// if it's a simple type, there'll be no other objects
	if nativeType := d.parseNativeType(input); nativeType != nil {
		return nativeType, &result, nil
	}

	return nil, nil, fmt.Errorf("unimplemented object definition")
}

func (d SwaggerDefinition) parseNativeType(input *spec.Schema) *models.ObjectDefinition {
	if input == nil {
		return nil
	}

	if input.Type.Contains("bool") || input.Type.Contains("boolean") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionBoolean,
		}
	}

	if input.Type.Contains("file") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionRawFile,
		}
	}

	if input.Type.Contains("integer") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionInteger,
		}
	}

	if input.Type.Contains("number") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionFloat,
		}
	}

	// TODO: Objects with Format of File are actually RawFiles..
	// "type": "object",
	// "format": "file"
	if input.Type.Contains("object") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionRawObject,
		}
	}

	// NOTE: whilst a DateTime _should_ always be Type: String with a Format of DateTime - bad data means
	// that this could have no Type value but a Format value, so we have to check this separately.
	if strings.EqualFold(input.Format, "date-time") {
		// TODO: handle there being a custom format - for now we assume these are all using RFC3339
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionDateTime,
		}
	}

	if input.Type.Contains("string") {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionString,
		}
	}

	// whilst all fields _should_ have a Type field, it's not guaranteed that they do
	// NOTE: this is _intentionally_ not part of the Object comparison above
	if len(input.Type) == 0 {
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionRawObject,
		}
	}

	return nil
}

func isFieldRequired(name string, required map[string]struct{}) bool {
	for k := range required {
		// assume data inconsistencies
		if strings.EqualFold(k, name) {
			return true
		}
	}

	return false
}
