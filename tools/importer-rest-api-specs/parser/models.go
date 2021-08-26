package parser

import (
	"fmt"
	"log"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) parseModel(name string, input spec.Schema) (*parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// 1. find any constants used within this model
	nestedResult, err := d.findConstantsWithinModel(input, result)
	if err != nil {
		return nil, fmt.Errorf("finding constants within model: %+v", err)
	}
	result.append(*nestedResult)

	// 2. iterate over the fields and find all of the fields for this model
	fields, nestedResult, err := d.fieldsForModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding fields for model: %+v", err)
	}
	result.append(*nestedResult)

	// if it's just got constants, we can skip it
	if len(*fields) == 0 {
		return &result, nil
	}

	// 3. finally build this model directly
	// Notably, we **DO NOT** load models used by this models here - this is handled once we
	// know all the models which we want to load - to avoid infinite loops
	model, err := d.modelDetailsFromObject(input, *fields)
	if err != nil {
		return nil, fmt.Errorf("populating model details for %q: %+v", name, err)
	}
	result.models[name] = *model

	return &result, nil
}

func (d *SwaggerDefinition) findConstantsWithinModel(input spec.Schema, known parseResult) (*parseResult, error) {
	// NOTE: both Models and Fields are passed in here
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	if fragmentName := fragmentNameFromReference(input.Ref); fragmentName != nil {
		topLevelObject, err := d.findTopLevelObject(*fragmentName)
		if err != nil {
			return nil, fmt.Errorf("finding top level object %q from reference: %+v", *fragmentName, err)
		}

		nestedResult, err := d.findConstantsWithinModel(*topLevelObject, result)
		if err != nil {
			return nil, fmt.Errorf("finding constants within reference %q: %+v", *fragmentName, err)
		}
		result.append(*nestedResult)
	}

	if len(input.Enum) > 0 {
		constant, err := mapConstant(input.Type, input.Enum, input.Extensions)
		if err != nil {
			return nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.constants[constant.name] = constant.details
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

			nestedResult, err := d.findConstantsWithinModel(*topLevelModel, result)
			if err != nil {
				return nil, fmt.Errorf("finding constants within parent model %q: %+v", *fragmentName, err)
			}

			result.append(*nestedResult)
		}
	}

	for propName, propVal := range input.Properties {
		if d.debugLog {
			log.Printf("[DEBUG] Processing Property %q..", propName)
		}
		// models can contain nested models - either can contain constants, so around we go..
		nestedResult, err := d.findConstantsWithinModel(propVal, result)
		if err != nil {
			return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
		}
		result.append(*nestedResult)
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		for propName, propVal := range input.AdditionalProperties.Schema.Properties {
			if d.debugLog {
				log.Printf("[DEBUG] Processing Additional Property %q..", propName)
			}
			// models can contain nested models - either can contain constants, so around we go..
			nestedConstants, err := d.findConstantsWithinModel(propVal, result)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			result.append(*nestedConstants)
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

	// add a placeholder for this model to avoid a circular reference
	resultWithPlaceholder := parseResult{}
	resultWithPlaceholder.append(result)

	needsPlaceholder := true
	if _, parsedModel := resultWithPlaceholder.models[modelName]; parsedModel {
		needsPlaceholder = false
	}
	if needsPlaceholder {
		resultWithPlaceholder.models[modelName] = models.ModelDetails{}
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
			result.append(*nestedResult)
			nestedFields[propName] = *nestedField
		}
		inlinedModelDetails, err := d.modelDetailsFromObject(value, nestedFields)
		if err != nil {
			return nil, nil, fmt.Errorf("building model details for inlined model %q: %+v", inlinedName, err)
		}
		result.models[inlinedName] = *inlinedModelDetails
	}

	// first get the object definition
	objectDefinition, nestedResult, err := d.parseObjectDefinition(modelName, &value, resultWithPlaceholder)
	if err != nil {
		return nil, nil, fmt.Errorf("parsing object definition: %+v", err)
	}
	if nestedResult != nil {
		if needsPlaceholder {
			// remove the placeholder from the result
			delete(nestedResult.models, modelName)
		}

		result.append(*nestedResult)
	}

	// then work out if this is actually a custom type, based on the information we have
	customFieldType := determineCustomFieldType(field, *objectDefinition, result)
	if customFieldType != nil {
		field.CustomFieldType = customFieldType
	} else {
		field.ObjectDefinition = objectDefinition
	}
	return &field, &result, err
}

func determineCustomFieldType(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) *models.CustomFieldType {
	customFieldMatchers := []customFieldMatcher{
		// NOTE: the ordering matters here
		locationMatcher{},
		tagsMatcher{},
	}

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
	for _, parent := range input.AllOf {
		fragmentName := fragmentNameFromReference(parent.Ref)
		if fragmentName == nil {
			return nil, nil, fmt.Errorf("parent %+v had no reference", parent)
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
			result.append(*nestedResult)
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

func (d *SwaggerDefinition) modelDetailsFromObject(input spec.Schema, fields map[string]models.FieldDetails) (*models.ModelDetails, error) {
	details := models.ModelDetails{
		Description: "",
		Fields:      fields,
	}

	// if this is a Parent
	if input.Discriminator != "" {
		details.TypeHintIn = &input.Discriminator
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
	}

	return &details, nil
}

func (d SwaggerDefinition) parseObjectDefinition(modelName string, input *spec.Schema, known parseResult) (*models.ObjectDefinition, *parseResult, error) {
	// find the object and any models and constants etc we can find
	// however _don't_ look for discriminator implementations - since that should be done when we're completely done
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	// if it's an enum then parse that out
	if len(input.Enum) > 0 {
		constant, err := mapConstant(input.Type, input.Enum, input.Extensions)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.constants[constant.name] = constant.details

		definition := models.ObjectDefinition{
			Type:          models.ObjectDefinitionReference,
			ReferenceName: &constant.name,
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

	// if it's a simple type, there'll be no other objects
	if nativeType := d.parseNativeType(input); nativeType != nil {
		return nativeType, &result, nil
	}

	// if it's a reference to a model, return that
	if objectName := fragmentNameFromReference(input.Ref); objectName != nil {
		// first find the top level object
		topLevelObject, err := d.findTopLevelObject(*objectName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level model %q: %+v", *objectName, err)
		}

		// then call ourselves to work out what to do with it
		return d.parseObjectDefinition(*objectName, topLevelObject, result)
	}

	// if it's an inlined model, pull it out and return that
	if len(input.Properties) > 0 {
		nestedResult, err := d.parseModel(modelName, *input)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing object from inlined model %q: %+v", modelName, err)
		}
		if nestedResult == nil {
			return nil, nil, fmt.Errorf("parsing object from inlined response model %q: no model returned", modelName)
		}
		result.append(*nestedResult)

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

	if input.Type.Contains("object") && input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		// it'll be a Dictionary, so pull out the nested item and return that
		nestedItem, nestedResult, err := d.parseObjectDefinition(input.AdditionalProperties.Schema.Title, input.AdditionalProperties.Schema, result)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: no nested item returned")
		}
		result.append(*nestedResult)
		return &models.ObjectDefinition{
			Type:       models.ObjectDefinitionDictionary,
			NestedItem: nestedItem,
		}, &result, nil
	}

	if input.Type.Contains("array") && input.Items.Schema != nil {
		nestedItem, nestedResult, err := d.parseObjectDefinition(input.Items.Schema.Title, input.Items.Schema, result)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: no nested item returned")
		}

		result.append(*nestedResult)
		return &models.ObjectDefinition{
			Type:       models.ObjectDefinitionList,
			NestedItem: nestedItem,
		}, &result, nil
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

	if input.Type.Contains("string") {
		if strings.EqualFold(input.Format, "date-time") {
			// TODO: handle there being a custom format - for now we assume these are all using RFC3339
			return &models.ObjectDefinition{
				Type: models.ObjectDefinitionDateTime,
			}
		}

		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionString,
		}
	}

	return nil
}

func isFieldRequired(name string, required map[string]struct{}) bool {
	for k, _ := range required {
		// assume data inconsistencies
		if strings.EqualFold(k, name) {
			return true
		}
	}

	return false
}
