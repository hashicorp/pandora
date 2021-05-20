package parser

import (
	"fmt"
	"log"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type parsedOperation struct {
	constants map[string]models.ConstantDetails
	models    map[string]models.ModelDetails
}

func (d *SwaggerDefinition) parseOperations(input map[string]models.OperationDetails) (*parsedOperation, error) {
	parsedConstants := make(map[string]models.ConstantDetails)
	parsedModels := make(map[string]models.ModelDetails)

	topLevelModelNames := d.findTopLevelModelNames(input)
	for _, modelName := range topLevelModelNames {
		if d.debugLog {
			log.Printf("[DEBUG] Parsing Top-Level Model %q..", modelName)
		}
		parsedModel, err := d.parseItemsFromModel(modelName)
		if err != nil {
			return nil, fmt.Errorf("parsing items from top-level model %q: %+v", modelName, err)
		}

		for k, v := range parsedModel.constants {
			var existing *models.ConstantDetails
			if e, ok := parsedConstants[k]; ok {
				existing = &e
			}

			constant := mergeConstants(v, existing)
			parsedConstants[k] = constant
		}

		for k, v := range parsedModel.models {
			parsedModels[k] = v
		}

		parsedModels[modelName] = models.ModelDetails{
			Description: "",
			Fields:      parsedModel.fields,
		}
	}

	return &parsedOperation{
		constants: parsedConstants,
		models:    parsedModels,
	}, nil
}

type result struct {
	constants map[string]models.ConstantDetails
	fields    map[string]models.FieldDefinition
	models    map[string]models.ModelDetails
}

func (r *result) append(other result) {
	for k, v := range other.constants {
		var existing *models.ConstantDetails
		if e, ok := r.constants[k]; ok {
			existing = &e
		}

		constant := mergeConstants(v, existing)
		r.constants[k] = constant
	}
	for k, v := range other.fields {
		r.fields[k] = v
	}
	for k, v := range other.models {
		r.models[k] = v
	}
}

func (d *SwaggerDefinition) findTopLevelModelNames(operations map[string]models.OperationDetails) []string {
	// first distinct them
	distinct := make(map[string]struct{})
	for _, operation := range operations {
		if operation.RequestObjectName != nil {
			distinct[*operation.RequestObjectName] = struct{}{}
		}
		if operation.ResponseObjectName != nil {
			distinct[*operation.ResponseObjectName] = struct{}{}
		}
	}

	// then sort because why not
	output := make([]string, 0)
	for k := range distinct {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}

func (d *SwaggerDefinition) parseItemsFromModel(modelName string) (*result, error) {
	// this should be a top level model so let's find it, then pass it to the recursive funtime
	model, err := d.findTopLevelModel(modelName)
	if err != nil {
		return nil, err
	}

	// @tombuildsstuff: this shouldn't be a reference..?
	return d.parseModel(modelName, *model)
}

func (d *SwaggerDefinition) parseModel(name string, input spec.Schema) (*result, error) {
	// Why isn't this a for loop, I hear you ask. Well.
	//   1. Models can inherit from other models (AllOf)
	//   2. Models can contain nested models (recursively)
	//   3. models nested within models can contain enums
	// .. so we get to do recursive fun-time
	constants, err := d.constantsForModel(input)
	if err != nil {
		return nil, fmt.Errorf("determining constants for model: %+v", err)
	}

	constants, fields, err := d.fieldsForModel(name, input, input.Required, *constants)
	if err != nil {
		return nil, fmt.Errorf("determining fields for model: %+v", err)
	}

	constants, parsedModels, err := d.modelsForModel(name, input, *constants, *fields)
	if err != nil {
		return nil, fmt.Errorf("determining models for model: %+v", err)
	}

	return &result{
		constants: *constants,
		fields:    *fields,
		models:    *parsedModels,
	}, nil
}

func (d *SwaggerDefinition) constantsForModel(input spec.Schema) (*map[string]models.ConstantDetails, error) {
	output := make(map[string]models.ConstantDetails, 0)

	if len(input.AllOf) > 0 {
		for _, parent := range input.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			topLevelModel, err := d.findTopLevelModel(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level model %q for constants: %+v", *fragmentName, err)
			}

			constantsWithinModel, err := d.constantsForModel(*topLevelModel)
			if err != nil {
				return nil, fmt.Errorf("finding constants within parent model %q: %+v", *fragmentName, err)
			}

			for k, v := range *constantsWithinModel {
				output[k] = v
			}
		}
	}

	for propName, propVal := range input.Properties {
		if d.debugLog {
			log.Printf("[DEBUG] Processing Property %q..", propName)
		}
		if propVal.Enum != nil {
			constant, err := mapConstant(propVal)
			if err != nil {
				return nil, fmt.Errorf("parsing constant from %q: %+v", propName, err)
			}
			output[constant.name] = constant.details
		}

		// models can contain nested models - either can contain constants, so around we go..
		if len(propVal.Properties) > 0 {
			nestedConstants, err := d.constantsForModel(propVal)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			for k, v := range *nestedConstants {
				output[k] = v
			}
		}
	}

	// Some models are just Enums
	if len(input.Enum) > 0 {
		constant, err := mapConstant(input)
		if err != nil {
			return nil, fmt.Errorf("parsing constant: %+v", err)
		}
		output[constant.name] = constant.details
	}

	return &output, nil
}

func (d *SwaggerDefinition) fieldsForModel(modelName string, input spec.Schema, requiredKeys []string, constants map[string]models.ConstantDetails) (*map[string]models.ConstantDetails, *map[string]models.FieldDefinition, error) {
	allConstants := make(map[string]models.ConstantDetails)
	for k, v := range constants {
		allConstants[k] = v
	}

	fields := make(map[string]models.FieldDefinition)

	// This model might just be an Enum list
	if input.Type != nil && input.Type[0] == "string" && len(input.Enum) > 0 {
		constant := models.ConstantDetails{
			Values:    map[string]string{},
			FieldType: models.String,
		}
		for _, v := range input.Enum {
			constant.Values[v.(string)] = v.(string)
		}
		allConstants[modelName] = constant
	}

	// models can inherit from other models, so we first need to pull those fields
	for _, parent := range input.AllOf {
		// these _should_ all be references, if they're not raise an error
		fragmentName := fragmentNameFromReference(parent.Ref)
		if fragmentName != nil {
			//return nil, nil, fmt.Errorf("missing fragment name for %+v", parent)
			// these _should_ all be top-level references..
			model, err := d.findTopLevelModel(*fragmentName)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving model for inherited type %q: %+v", *fragmentName, err)
			}

			inheritedConstants, inheritedFields, err := d.fieldsForModel(*fragmentName, *model, input.Required, constants)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving fields for inherited type %q: %+v", *fragmentName, err)
			}
			for k, v := range *inheritedConstants {
				allConstants[k] = v
			}
			for k, v := range *inheritedFields {
				fields[k] = v
			}
		}
	}

	// then we get the simple thing of iterating over these fields
	for propName, propVal := range input.Properties {
		isRequired := fieldIsRequired(requiredKeys, propName)
		consts, field, err := mapField(modelName, propName, propVal, isRequired, constants)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping field %q: %+v", modelName, err)
		}

		for k, v := range *consts {
			allConstants[k] = v
		}

		// whilst we could look to normalize the name we're intentionally not doing so here
		fields[propName] = *field
	}

	return &allConstants, &fields, nil
}

func (d *SwaggerDefinition) modelsForModel(name string, input spec.Schema, constants map[string]models.ConstantDetails, fields map[string]models.FieldDefinition) (*map[string]models.ConstantDetails, *map[string]models.ModelDetails, error) {
	allConstants := make(map[string]models.ConstantDetails, 0)
	for k, v := range constants {
		allConstants[k] = v
	}

	allModels := make(map[string]models.ModelDetails, 0)
	constantsWithinModel, modelsWithinModel, err := d.findModelsForModel(name, input, constants, map[string]models.ModelDetails{})
	if err != nil {
		return nil, nil, err
	}
	for k, v := range *constantsWithinModel {
		allConstants[k] = v
	}
	for k, v := range *modelsWithinModel {
		allModels[k] = v
	}

	for fieldName, field := range fields {
		if field.ModelReference == nil {
			continue
		}

		nestedModelName := *field.ModelReference
		_, hasModel := allModels[nestedModelName]
		if hasModel {
			continue
		}

		topLevelModel, err := d.findTopLevelModel(nestedModelName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level model %q for field %q in %q: %+v", nestedModelName, fieldName, name, err)
		}

		constantsHiddenInFields, modelsHiddenInFields, err := d.findModelsForModel(nestedModelName, *topLevelModel, constants, allModels)
		if err != nil {
			return nil, nil, fmt.Errorf("retrieving models within %q: %+v", nestedModelName, err)
		}

		for k, v := range *constantsHiddenInFields {
			allConstants[k] = v
		}
		for k, v := range *modelsHiddenInFields {
			allModels[k] = v
		}
	}

	return &allConstants, &allModels, nil
}

func (d *SwaggerDefinition) findModelsForModel(name string, input spec.Schema, constants map[string]models.ConstantDetails, knownModels map[string]models.ModelDetails) (*map[string]models.ConstantDetails, *map[string]models.ModelDetails, error) {
	allConstants := make(map[string]models.ConstantDetails)
	for k, v := range constants {
		allConstants[k] = v
	}
	foundModels := make(map[string]models.ModelDetails)

	// handles recursive models
	for k := range knownModels {
		if strings.EqualFold(k, name) {
			return &allConstants, &foundModels, nil
		}
	}

	var allModels = func() map[string]models.ModelDetails {
		all := make(map[string]models.ModelDetails)
		for k, v := range knownModels {
			all[k] = v
		}
		for k, v := range foundModels {
			all[k] = v
		}
		return all
	}

	// add this model
	consts, fields, err := d.fieldsForModel(name, input, input.Required, constants)
	if err != nil {
		return nil, nil, fmt.Errorf("finding fields for %q: %+v", name, err)
	}
	for constName, constVal := range *consts {
		allConstants[constName] = constVal
	}
	if len(*fields) > 0 {
		foundModels[name] = models.ModelDetails{
			Description: "",
			Fields:      *fields,
		}
	}

	// then iterate over the others
	for propName, propVal := range input.Properties {
		// inlined constants are pulled out elsewhere
		if len(propVal.Enum) > 0 {
			continue
		}

		// if it's a reference to another property
		fragmentName := fragmentNameFromReference(propVal.Ref)
		if fragmentName == nil {
			if propVal.AdditionalProperties != nil && propVal.AdditionalProperties.Schema != nil {
				fragmentName = fragmentNameFromReference(propVal.AdditionalProperties.Schema.Ref)
			}
		}
		if fragmentName != nil {
			// referenced constants are pulled out elsewhere
			if isConstant(constants, *fragmentName) {
				continue
			}

			// circular references
			if name == *fragmentName {
				continue
			}

			// have we already loaded this model?
			allKnownModels := allModels()
			if _, alreadyLoaded := allKnownModels[*fragmentName]; alreadyLoaded {
				continue
			}

			// this should be a top level model, so go find it
			topLevelModel, err := d.findTopLevelModel(*fragmentName)
			if err != nil {
				return nil, nil, fmt.Errorf("finding model %q: %+v", *fragmentName, err)
			}

			// then add any models nested within this one
			modelsKnownSoFar := allModels()
			nestedConstants, nestedModels, err := d.findModelsForModel(*fragmentName, *topLevelModel, constants, modelsKnownSoFar)
			if err != nil {
				return nil, nil, fmt.Errorf("finding models for %q: %+v", *fragmentName, err)
			}
			for constName, constVal := range *nestedConstants {
				allConstants[constName] = constVal
			}
			for modelName, modelVal := range *nestedModels {
				foundModels[modelName] = modelVal
			}
			continue
		}

		// when this model is defined inline
		if len(propVal.Properties) > 0 {
			// otherwise it should be an inlined block which can go through the recursive funtime
			// however we have to make sure those names are unique
			uniqueName := inlinedModelName(name, propName)
			modelsKnownSoFar := allModels()
			nestedConstants, nestedModels, err := d.findModelsForModel(uniqueName, propVal, constants, modelsKnownSoFar)
			if err != nil {
				return nil, nil, fmt.Errorf("finding models for %q: %+v", propName, err)
			}

			for constName, constVal := range *nestedConstants {
				allConstants[constName] = constVal
			}
			for modelName, modelVal := range *nestedModels {
				foundModels[modelName] = modelVal
			}

			// update the model name for this field
			field := (*fields)[propName]
			field.ModelReference = &uniqueName
			(*fields)[propName] = field
			continue
		}
	}

	foundModels[name] = models.ModelDetails{
		Description: "",
		Fields:      *fields,
	}

	return &allConstants, &foundModels, nil
}

func (d *SwaggerDefinition) findTopLevelModel(name string) (*spec.Schema, error) {
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

	return nil, fmt.Errorf("model %q was not found", name)
}

type parsedConstant struct {
	name    string
	details models.ConstantDetails
}

func mapConstant(input spec.Schema) (*parsedConstant, error) {
	if input.Ref.String() != "" {
		// @tombuildsstuff: I've not seen any examples of this, I don't think?
		return nil, fmt.Errorf("constant references are not supported")
	}

	// the name needs to come from the `x-ms-enum` extension
	name, err := parseConstantNameFromField(input)
	if err != nil {
		return nil, err
	}
	if name == nil {
		return nil, fmt.Errorf("reference was missing for constant: %+v", input)
	}

	keysAndValues := make(map[string]string)
	for i, raw := range input.Enum {
		if input.Type.Contains("string") {
			value, ok := raw.(string)
			if !ok {
				return nil, fmt.Errorf("expected a string but got %+v for the %d value for %q", raw, i, *name)
			}

			normalizedName := cleanup.NormalizeName(value)
			keysAndValues[normalizedName] = value
		}

		if input.Type.Contains("integer") {
			// this gets parsed out as a float64 even though it's an Integer :upside_down_smile:
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an integer but got %+v for the %d value for %q", raw, i, *name)
			}

			// TODO: support as non-string types in time..

			val := fmt.Sprintf("%.0f", value)
			keysAndValues[val] = val
		}

		// TODO: also floats apparently, presumably booleans too?
	}

	return &parsedConstant{
		name: *name,
		details: models.ConstantDetails{
			Values:    keysAndValues,
			FieldType: models.String, // TODO: support for other types
		},
	}, nil
}

func mapField(parentModelName, jsonName string, value spec.Schema, isRequired bool, constants map[string]models.ConstantDetails) (*map[string]models.ConstantDetails, *models.FieldDefinition, error) {
	allConstants := make(map[string]models.ConstantDetails)
	for k, v := range constants {
		allConstants[k] = v
	}

	field := models.FieldDefinition{
		Required:          isRequired,
		ReadOnly:          value.ReadOnly, // TODO: generator should handle this in some manner?
		ConstantReference: nil,
		ModelReference:    nil,
		Sensitive:         false, // todo: this probably needs to be a predefined list, unless there's something we can parse
		JsonName:          jsonName,
		Type:              models.Unknown, // intentional to highlight any missing types
	}

	var referenceType *string
	fragmentName := fragmentNameFromReference(value.Ref)
	if fragmentName != nil {
		field.Type = models.Object
		referenceType = fragmentName
	}

	// models can be nested within properties
	if len(value.Properties) > 0 {
		inlinedModel := inlinedModelName(parentModelName, jsonName)
		field.Type = models.Object
		field.ModelReference = &inlinedModel
	}

	// models can also be nested within properties
	if len(value.Enum) > 0 && len(value.Type) > 0 && value.Type[0] != "string" {
		inlinedModel := inlinedModelName(parentModelName, jsonName)
		field.Type = models.Object
		field.ConstantReference = &inlinedModel
	}

	if len(value.Type) > 0 {
		field.Type = normalizeType(value.Type[0])

		// TODO: Discriminators, which are likely explicitly out of scope at this point

		if field.Type == models.List {
			if value.Items == nil {
				return nil, nil, fmt.Errorf("field %q is an array with no `items`", jsonName)
			}
			if value.Items.Schema == nil {
				return nil, nil, fmt.Errorf("field %q is an array with no `items.Schema`", jsonName)
			}

			// This is either an Array of a built-in type:
			/*
				Example:
				"requiredZoneNames": {
				  "type": "array",
				  "items": {
					"type": "string"
				  },
				  "readOnly": true,
				  "description": "The list of required DNS zone names of the private link resource."
				}
			*/
			if len(value.Items.Schema.Type) > 0 {
				nestedElementType := normalizeType(value.Items.Schema.Type[0])
				field.ListElementType = &nestedElementType
			} else {
				// or it's an Array of Items (e.g. a Constant/Model) which should have a Fragment/Ref
				/*
					Example:
					"privateEndpointConnections": {
					  "description": "The list of private endpoint connections that are set up for this resource.",
					  "type": "array",
					  "readOnly": true,
					  "items": {
						"$ref": "#/definitions/PrivateEndpointConnectionReference"
					  }
					},
				*/
				fragment := fragmentNameFromReference(value.Items.Schema.Ref)
				if fragment != nil {
					o := models.Object
					field.ModelReference = fragment
					field.ListElementType = &o
					referenceType = fragment
				}

				if len(value.Items.Schema.Properties) > 0 {
					inlinedModel := inlinedModelName(parentModelName, jsonName)
					field.Type = models.Object
					field.ModelReference = &inlinedModel
				}
			}
		}

		// Maps of Things
		if field.Type == models.Object {
			if value.AdditionalProperties != nil {
				if schema := value.AdditionalProperties.Schema; schema != nil {
					if len(schema.Type) > 0 {
						// map[string]string = Tags
						if schema.Type.Contains("string") {
							if strings.EqualFold(jsonName, "tags") {
								field.Type = models.Tags
							} else {
								// it's some arbitrary list
								field.Type = normalizeType(schema.Type[0])
							}
						}
					} else {
						// check if there's a fragment
						fragmentName = fragmentNameFromReference(schema.Ref)
						if fragmentName != nil {
							field.Type = "dictionary"
							referenceType = fragmentName
						}
					}
				}
			}
		}

		if field.Type == models.String {
			if strings.EqualFold(value.Format, "date-time") {
				field.Type = models.DateTime
				// TODO: handle there being a custom format - for now we assume these are all using RFC3339
			}

			constantName, err := parseConstantNameFromField(value)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing constant %q: %+v", jsonName, err)
			}
			if constantName != nil {
				field.Type = models.Object
				field.ConstantReference = constantName

				if len(value.Enum) > 0 {
					constant, err := mapConstant(value)
					if err != nil {
						return nil, nil, fmt.Errorf("parsing constant from %q: %+v", *constantName, err)
					}
					allConstants[*constantName] = constant.details
				}
			}
		}
	}

	// Handle cases where there are _only_ additionalProperties?
	if value.AdditionalProperties != nil && value.AdditionalProperties.Schema != nil {
		if len(value.AdditionalProperties.Schema.Type) > 0 && field.Type != models.Tags {
			field.Type = normalizeType(value.AdditionalProperties.Schema.Type[0])

			if field.Type == models.List {
				if value.AdditionalProperties.Schema.Items == nil {
					return nil, nil, fmt.Errorf("field %q is an array with no `items`", jsonName)
				}
				if value.AdditionalProperties.Schema.Items.Schema == nil {
					return nil, nil, fmt.Errorf("field %q is an array with no `items.Schema`", jsonName)
				}

				// This is either an Array of a built-in type:
				/*
					Example:
					"requiredZoneNames": {
					  "type": "array",
					  "items": {
						"type": "string"
					  },
					  "readOnly": true,
					  "description": "The list of required DNS zone names of the private link resource."
					}
				*/
				if len(value.AdditionalProperties.Schema.Items.Schema.Type) > 0 {
					nestedElementType := normalizeType(value.AdditionalProperties.Schema.Items.Schema.Type[0])
					field.ListElementType = &nestedElementType
				} else {
					// or it's an Array of Items (e.g. a Constant/Model) which should have a Fragment/Ref
					/*
						Example:
						"privateEndpointConnections": {
						  "description": "The list of private endpoint connections that are set up for this resource.",
						  "type": "array",
						  "readOnly": true,
						  "items": {
							"$ref": "#/definitions/PrivateEndpointConnectionReference"
						  }
						},
					*/
					fragment := fragmentNameFromReference(value.AdditionalProperties.Schema.Items.Schema.Ref)
					if fragment != nil {
						o := models.Object
						field.ModelReference = fragment
						field.ListElementType = &o
						referenceType = fragment
					}

					if len(value.AdditionalProperties.Schema.Items.Schema.Properties) > 0 {
						inlinedModel := inlinedModelName(parentModelName, jsonName)
						field.Type = models.Object
						field.ModelReference = &inlinedModel
					}
				}
			}

			if field.Type == models.String {
				if strings.EqualFold(value.Format, "date-time") {
					field.Type = models.DateTime
					// TODO: handle there being a custom format - for now we assume these are all using RFC3339
				}

				constantName, err := parseConstantNameFromField(value)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing constant %q: %+v", jsonName, err)
				}
				if constantName != nil {
					field.Type = models.Object
					field.ConstantReference = constantName

					if len(value.Enum) > 0 {
						constant, err := mapConstant(value)
						if err != nil {
							return nil, nil, fmt.Errorf("parsing constant from %q: %+v", *constantName, err)
						}
						allConstants[*constantName] = constant.details
					}
				}
			}
		}
	}

	// Some properties only specify AllOf, with no additional data, so...
	if len(value.Type) == 0 && value.AdditionalProperties == nil && len(value.AllOf) > 0 {
		field.Type = models.Object
		fragmentName = fragmentNameFromReference(value.AllOf[0].Ref) // TODO - can AllOf > 1?
		field.ModelReference = fragmentName
	}

	if referenceType != nil {
		if isConstant(constants, *referenceType) {
			field.ConstantReference = referenceType
		} else {
			field.ModelReference = referenceType
		}
	}

	// sanity checking
	if field.Type == models.Unknown {
		// Apparently it's possible for these to be omitted
		// we should raise these with MS to fix, but should we output `object` or omit the field for the moment?
		// > "ArtifactProperties": {
		// >   "type": "object",
		// >   "additionalProperties": false,
		// >   "description": "The artifact properties definition.",
		// >   "properties": {
		// >     "createdTime": {
		// >       "type": "string",
		// >       "format": "date-time",
		// >       "description": "The artifact creation time."
		// >     },
		// >     "changedTime": {
		// >       "type": "string",
		// >         "format": "date-time",
		// >         "description": "The artifact changed time."
		// >       },
		// >       "metadata": {}
		// >     }
		// >   },

		return nil, nil, fmt.Errorf("field %q is missing a type", jsonName)
	}

	// kinda presumptuous, but probably fine.
	if strings.EqualFold(field.JsonName, "location") && field.Type == models.String {
		field.Type = models.Location
	}

	return &allConstants, &field, nil
}

func isConstant(constants map[string]models.ConstantDetails, name string) bool {
	isConstant := false
	// it must be either a constant or a model, but there'll be less constants to check
	for constName := range constants {
		if strings.EqualFold(constName, name) {
			isConstant = true
			break
		}
	}
	return isConstant
}

func mergeConstants(new models.ConstantDetails, existing *models.ConstantDetails) models.ConstantDetails {
	vals := make(map[string]string)
	fieldType := models.String // safe default
	if existing != nil {
		vals = existing.Values
		fieldType = existing.FieldType
	}
	for key, value := range new.Values {
		vals[key] = value
	}
	return models.ConstantDetails{
		Values:    vals,
		FieldType: fieldType,
	}
}
