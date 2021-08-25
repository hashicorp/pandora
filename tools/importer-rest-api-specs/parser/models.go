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
	fields, nestedResult, err := d.fieldsForModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding fields for model: %+v", err)
	}
	result.append(*nestedResult)

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

func (d *SwaggerDefinition) findConstantsWithinModel(input spec.Schema) (*parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// Some models are just Enums
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

func (d *SwaggerDefinition) fieldsForModel(name string, input spec.Schema, known parseResult) (*map[string]models.FieldDetails, *parseResult, error) {
	fields := make(map[string]models.FieldDetails, 0)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	return &fields, &result, nil
}

func (d *SwaggerDefinition) modelDetailsFromObject(name string, input spec.Schema, fields map[string]models.FieldDetails) (*models.ModelDetails, error) {
	return &models.ModelDetails{
		Description: "",
		Fields:      fields,
		// TODO: others
	}, nil
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
