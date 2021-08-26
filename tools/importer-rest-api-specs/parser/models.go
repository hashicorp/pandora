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
	nestedResult, err := d.findConstantsWithinModel(input)
	if err != nil {
		return nil, fmt.Errorf("finding constants within model: %+v", err)
	}
	result.append(*nestedResult)

	// 2. iterate over the fields and find all of the fields for this model
	fields, additionalProperties, nestedResult, err := d.fieldsForModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding fields for model: %+v", err)
	}
	result.append(*nestedResult)

	// if it's just got constants, we can skip it
	if len(*fields) == 0 && additionalProperties == nil {
		return &result, nil
	}

	// 3. finally build this model directly
	// Notably, we **DO NOT** load models used by this models here - this is handled once we
	// know all the models which we want to load - to avoid infinite loops
	model, err := d.modelDetailsFromObject(input, *fields, additionalProperties)
	if err != nil {
		return nil, fmt.Errorf("populating model details for %q: %+v", name, err)
	}
	result.models[name] = *model

	return &result, nil
}

func (d *SwaggerDefinition) findConstantsWithinModel(input spec.Schema) (*parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// Check any object that this model inherits from
	if len(input.AllOf) > 0 {
		for _, parent := range input.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			topLevelModel, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level model %q for constants: %+v", *fragmentName, err)
			}

			nestedResult, err := d.findConstantsWithinModel(*topLevelModel)
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
		nestedResult, err := d.findConstantsWithinModel(propVal)
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
			nestedConstants, err := d.findConstantsWithinModel(propVal)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			result.append(*nestedConstants)
		}
	}

	return &result, nil
}

type fieldDetails struct {
	// Details is the Field itself
	Details models.FieldDetails

	// SwaggerReference is a reference to the Raw Swagger Schema which is
	// referenced in either the ConstantReference or ModelReference within
	// the Details field above
	SwaggerReference *spec.Schema
}

func (d *SwaggerDefinition) fieldsForModel(modelName string, input spec.Schema, known parseResult) (*map[string]models.FieldDetails, *fieldDetails, *parseResult, error) {
	fields := make(map[string]models.FieldDetails, 0)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)
	var additionalDetails *fieldDetails

	// models can inherit from other models, so let's get all of the parent fields here
	for _, parent := range input.AllOf {
		fragmentName := fragmentNameFromReference(parent.Ref)
		if fragmentName == nil {
			return nil, nil, nil, fmt.Errorf("parent %+v had no reference", parent)
		}

		topLevelObject, err := d.findTopLevelObject(*fragmentName)
		if err != nil {
			return nil, nil, nil, fmt.Errorf("parsing top level object %q: %+v", *fragmentName, err)
		}

		nestedFields, nestedAdditionalProps, nestedResult, err := d.fieldsForModel(*fragmentName, *topLevelObject, result)
		if err != nil {
			return nil, nil, nil, fmt.Errorf("finding fields for parent model %q: %+v", *fragmentName, err)
		}
		for k, v := range *nestedFields {
			fields[k] = v
		}
		if nestedAdditionalProps != nil {
			if additionalDetails != nil {
				return nil, nil, nil, fmt.Errorf("multiple additionalProperties inherited for %q", modelName)
			}

			additionalDetails = nestedAdditionalProps
		}
		if nestedResult != nil {
			result.append(*nestedResult)
		}
	}

	// then we get the simple thing of iterating over these fields
	for propName, propVal := range input.Properties {
		isRequired := isFieldRequired(propName, input.Required)
		field, nestedResult, err := d.detailsForField(modelName, propName, propVal, isRequired, result)
		if err != nil {
			return nil, nil, nil, fmt.Errorf("mapping field %q for %q: %+v", propName, modelName, err)
		}
		if nestedResult != nil {
			result.append(*nestedResult)
		}

		// whilst we could look to normalize the name we're intentionally not doing so here
		fields[propName] = field.Details
	}

	// TODO: if we have a parent type pull that out but *DO NOT* retrieve children here

	return &fields, additionalDetails, &result, nil
}

func (d *SwaggerDefinition) detailsForField(modelName string, propertyName string, value spec.Schema, isRequired bool, known parseResult) (*fieldDetails, *parseResult, error) {
	if d.debugLog {
		log.Printf("Parsing details for field %q in %q..", propertyName, modelName)
	}

	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)
	field := fieldDetails{
		Details: models.FieldDetails{
			Required:          isRequired,
			ReadOnly:          value.ReadOnly, // TODO: generator should handle this in some manner?
			ConstantReference: nil,
			ModelReference:    nil,
			Sensitive:         false, // todo: this probably needs to be a predefined list, unless there's something we can parse
			JsonName:          propertyName,
			Type:              models.Unknown, // intentional to highlight any missing types
		},
		SwaggerReference: nil,
	}

	// if it's a reference to a top-level type then we want to determine _what_ it is (Const/Model)
	// and then let this get pulled out elsewhere
	// Field is a reference:
	// - type: object
	// - model reference / const reference: $ref
	if fragmentName := fragmentNameFromReference(value.Ref); fragmentName != nil {
		field.Details.Type = models.Object

		// either it's already known as a constant, or we'll parse it out below
		_, isConstant := result.constants[*fragmentName]
		if !isConstant {
			model, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, nil, fmt.Errorf("finding top level object %q: %+v", *fragmentName, err)
			}
			//field.SwaggerReference = model
			isConstant = len(model.Enum) > 0
		}

		if isConstant {
			field.Details.ConstantReference = fragmentName
		} else {
			field.Details.ModelReference = fragmentName
		}

		return &field, &result, nil
	}

	// Field is an inlined model or a inherited model:
	// - type: object
	// - model reference: pull out the model of the additionalProperties
	if len(value.Properties) > 0 || len(value.AllOf) > 0 {
		inlinedModel := inlinedModelName(modelName, propertyName)
		field.Details.Type = models.Object
		field.Details.ModelReference = &inlinedModel
		field.SwaggerReference = &value
		return &field, &result, nil
	}

	// Filed is a plain dictionary
	// - type: dictionary
	// - dict value type: <one of all possible types>
	// - model reference (only when dict value is not primary type): pull out the model of the additionalProperties.
	if len(value.Properties) == 0 && value.AdditionalProperties != nil && value.AdditionalProperties.Schema != nil {
		field.Details.Type = models.Dictionary

		nestedDetails, nestedResult, err := d.detailsForField(modelName, propertyName, *value.AdditionalProperties.Schema, isRequired, result)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping additionalProperties value for %s.%s: %+v", modelName, propertyName, err)
		}
		if nestedResult != nil {
			result.append(*nestedResult)
		}

		field = *nestedDetails
		field.Details.DictValueType = &nestedDetails.Details.Type
		field.Details.Type = models.Dictionary

		// Especially handling for "tags"
		if strings.EqualFold(propertyName, "tags") && *field.Details.DictValueType == models.String {
			field.Details.Type = models.Tags
			field.Details.DictValueType = nil
		}

		return &field, &result, nil
	}

	// Field is an inlined enum:
	// - type: object
	// - constant reference: pull out the inlined enum
	if len(value.Enum) > 0 {
		// if it's inlined pull it out that way
		constant, err := mapConstant(value.Type, value.Enum, value.Extensions)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant from field %q in model %q: %+v", propertyName, modelName, err)
		}
		result.constants[constant.name] = constant.details
		field.Details.Type = models.Object
		field.Details.ConstantReference = &constant.name
		return &field, &result, nil
	}

	// At this point, Field is either a primary type or an array, both of them should have the "type" specified.
	if len(value.Type) > 0 {
		fieldType, err := normalizeType(value.Type[0])
		if err != nil {
			return nil, nil, fmt.Errorf("determining type from %q: %+v", value.Type[0], err)
		}
		field.Details.Type = *fieldType

		// Handle array
		if field.Details.Type == models.List {
			if value.Items == nil {
				return nil, nil, fmt.Errorf("field %q in model %q is an array with no `items`", propertyName, modelName)
			}
			if value.Items.Schema == nil {
				return nil, nil, fmt.Errorf("field %q in model %q is an array with no `items.Schema`", propertyName, modelName)
			}

			nestedDetails, nestedResult, err := d.detailsForField(modelName, propertyName, *value.Items.Schema, isRequired, result)
			if err != nil {
				return nil, nil, fmt.Errorf("mapping array element of field %s.%s: %+v", modelName, propertyName, err)
			}
			if nestedResult != nil {
				result.append(*nestedResult)
			}

			field = *nestedDetails
			field.Details.Type = models.List
			field.Details.ListElementType = &nestedDetails.Details.Type
			field.Details.ListElementMin = value.MinItems
			field.Details.ListElementMax = value.MaxItems
			field.Details.ListElementUnique = &value.UniqueItems

			return &field, &result, nil
		}

		if field.Details.Type == models.String {
			if strings.EqualFold(field.Details.JsonName, "location") {
				field.Details.Type = models.Location
				return &field, &result, nil
			}

			if strings.EqualFold(value.Format, "date-time") {
				field.Details.Type = models.DateTime
				// TODO: handle there being a custom format - for now we assume these are all using RFC3339
				return &field, &result, nil
			}
		}
	}

	if field.Details.Type == models.Unknown {
		return nil, nil, fmt.Errorf("the schema for the field %q in the model %q is invalid", propertyName, modelName)
	}

	return &field, &result, nil
}

func (d *SwaggerDefinition) modelDetailsFromObject(input spec.Schema, fields map[string]models.FieldDetails, additionalProperties *fieldDetails) (*models.ModelDetails, error) {
	details := models.ModelDetails{
		Description: "",
		Fields:      fields,
	}
	if additionalProperties != nil {
		details.AdditionalProperties = &additionalProperties.Details
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

func isFieldRequired(name string, required []string) bool {
	for _, v := range required {
		// assume data inconsistencies
		if strings.EqualFold(v, name) {
			return true
		}
	}

	return false
}
func normalizeType(input string) (*models.FieldDefinitionType, error) {
	out := models.Unknown
	switch strings.ToLower(input) {
	case "array":
		out = models.List
		break

	case "boolean":
		out = models.Boolean
		break

	case "int", "integer":
		// NOTE: whilst there's some benefits to mirroring the API insofar as outputting
		// either int32/int64 - from Terraform's perspective we treat them the same so we
		// from a parsing/usability perspective they're similar enough that we can lean on
		// validation to limit this where necessary instead
		out = models.Integer
		break

	case "object":
		out = models.Object
		break

	case "number":
		// NOTE: whilst there's some benefits to mirroring the API insofar as outputting
		// either float32/float64 - from Terraform's perspective we treat them the same so we
		// from a parsing/usability perspective they're similar enough that we can lean on
		// validation to limit this where necessary instead
		out = models.Float
		break

	case "string":
		out = models.String
		break
	}

	if out != models.Unknown {
		return &out, nil
	}

	return nil, fmt.Errorf("unsupported type conversion %q", input)
}
