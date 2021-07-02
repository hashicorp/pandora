package parser

import (
	"fmt"
	"log"
	"sort"
	"strconv"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

const additionalPropertiesLit = "additionalProperties"

type constantDetailsMap map[string]models.ConstantDetails

func (m constantDetailsMap) merge(o constantDetailsMap) {
	for k, v := range o {
		m[k] = v
	}
}

type fieldDetailsMap map[string]models.FieldDetails

func (f fieldDetailsMap) merge(o fieldDetailsMap) {
	for k, v := range o {
		f[k] = v
	}
}

type modelDetailsMap map[string]models.ModelDetails

func (m modelDetailsMap) merge(o modelDetailsMap) {
	for k, v := range o {
		m[k] = v
	}
}

func (d *SwaggerDefinition) parseOperations(input map[string]models.OperationDetails, inlinedModels result) (*result, error) {
	result := result{
		constants: constantDetailsMap{},
		models:    modelDetailsMap{},
	}

	topLevelModelNames := d.findModelsUsedByOperations(input)
	for _, modelName := range topLevelModelNames {
		if d.debugLog {
			log.Printf("[DEBUG] Parsing Top-Level Model %q..", modelName)
		}
		parsedModel, err := d.parseItemsFromModel(modelName, inlinedModels)
		if err != nil {
			return nil, fmt.Errorf("parsing items from top-level model %q: %+v", modelName, err)
		}
		if parsedModel == nil {
			continue
		}

		result.append(*parsedModel)
		details := models.ModelDetails{
			Description: "",
			Fields:      parsedModel.fields,
		}

		nestedModel, ok := parsedModel.models[modelName]
		if ok {
			details.ParentTypeName = nestedModel.ParentTypeName
			details.TypeHintIn = nestedModel.TypeHintIn
			details.TypeHintValue = nestedModel.TypeHintValue
		}

		result.models[modelName] = details
	}

	// now that we've processed all of the models within this operation, we need to find any implementations
	// for any discriminators and ensure they're added too
	for modelName, model := range result.models {
		// if it's not a discriminator, there's nothing to find
		if model.TypeHintIn == nil {
			continue
		}

		if d.debugLog {
			log.Printf("[DEBUG] Finding implementations of %q (discriminating on %q)..", modelName, *model.TypeHintIn)
		}
		implementations, err := d.findImplementationsOf(modelName)
		if err != nil {
			return nil, fmt.Errorf("finding implementations of %q (discriminating on %q): %+v", modelName, *model.TypeHintIn, err)
		}

		result.append(*implementations)
	}

	return &result, nil
}

type result struct {
	constants constantDetailsMap
	fields    fieldDetailsMap
	models    modelDetailsMap
}

func (r *result) append(other result) {
	if r.constants == nil {
		r.constants = make(constantDetailsMap)
	}
	if r.fields == nil {
		r.fields = make(fieldDetailsMap)
	}
	if r.models == nil {
		r.models = make(modelDetailsMap)
	}

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

func (d *SwaggerDefinition) findModelsUsedByOperations(operations map[string]models.OperationDetails) []string {
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

func (d *SwaggerDefinition) parseItemsFromModel(modelName string, inlinedModels result) (*result, error) {
	// check if this is already parsed out from an inlined request/response model
	if _, ok := inlinedModels.models[modelName]; ok {
		return nil, nil
	}
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

	constants, fields, err := d.fieldsForModel(name, input, nil, constants)
	if err != nil {
		return nil, fmt.Errorf("determining fields for model: %+v", err)
	}

	constants, parsedModels, err := d.modelsForModel(name, input, constants, fields)
	if err != nil {
		return nil, fmt.Errorf("determining models for model: %+v", err)
	}

	return &result{
		constants: constants,
		fields:    fields,
		models:    parsedModels,
	}, nil
}

func (d *SwaggerDefinition) constantsForModel(input spec.Schema) (constantDetailsMap, error) {
	output := make(constantDetailsMap, 0)

	// Some models are just Enums
	if len(input.Enum) > 0 {
		constant, err := mapConstant(input)
		if err != nil {
			return nil, fmt.Errorf("parsing constant: %+v", err)
		}
		output[constant.name] = constant.details
	}

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

			output.merge(constantsWithinModel)
		}
	}

	for propName, propVal := range input.Properties {
		if d.debugLog {
			log.Printf("[DEBUG] Processing Property %q..", propName)
		}
		// models can contain nested models - either can contain constants, so around we go..
		nestedConstants, err := d.constantsForModel(propVal)
		if err != nil {
			return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
		}

		output.merge(nestedConstants)
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil && input.AdditionalProperties.Allows {
		for propName, propVal := range input.AdditionalProperties.Schema.Properties {
			if d.debugLog {
				log.Printf("[DEBUG] Processing Additional Property %q..", propName)
			}
			// models can contain nested models - either can contain constants, so around we go..
			nestedConstants, err := d.constantsForModel(propVal)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			output.merge(nestedConstants)
		}
	}

	return output, nil
}

func (d *SwaggerDefinition) fieldsForModel(modelName string, input spec.Schema, requiredKeys []string, constants constantDetailsMap) (constantDetailsMap, fieldDetailsMap, error) {
	allConstants := make(constantDetailsMap)
	for k, v := range constants {
		allConstants[k] = v
	}

	// Merge the required keys of the current Schema with the passed in requiredKeys (e.g. from the inheriting Schema).
	requiredKeysMap := map[string]struct{}{}
	for _, v := range requiredKeys {
		requiredKeysMap[v] = struct{}{}
	}
	for _, v := range input.Required {
		requiredKeysMap[v] = struct{}{}
	}
	requiredKeys = make([]string, 0, len(requiredKeysMap))
	for k := range requiredKeysMap {
		requiredKeys = append(requiredKeys, k)
	}

	fields := make(fieldDetailsMap)

	// This model might just be an Enum list
	if input.Type != nil && input.Type[0] == "string" && len(input.Enum) > 0 {
		constant, err := mapConstant(input)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant %q: %+v", input.Title, err)
		}
		allConstants[constant.name] = constant.details
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

			inheritedConstants, inheritedFields, err := d.fieldsForModel(*fragmentName, *model, requiredKeys, constants)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving fields for inherited type %q: %+v", *fragmentName, err)
			}
			allConstants.merge(inheritedConstants)
			fields.merge(inheritedFields)
		}
	}

	// then we get the simple thing of iterating over these fields
	for propName, propVal := range input.Properties {
		isRequired := fieldIsRequired(requiredKeys, propName)
		consts, field, err := d.mapField(modelName, propName, propVal, isRequired, constants)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping field %q: %+v", modelName, err)
		}

		allConstants.merge(consts)

		// whilst we could look to normalize the name we're intentionally not doing so here
		fields[propName] = *field
	}

	// In case current schema has additional properties defined, we'll add it to the fields.
	if input.AdditionalProperties != nil {
		tptr := func(t models.FieldDefinitionType) *models.FieldDefinitionType {
			return &t
		}

		var field *models.FieldDetails

		// TODO:There is a bug here that we will regard explicit false additionalProperties as a dict of free-form values.
		// 		Which actually should mean there is no `additionalProperties` allowed.
		// 		Differentiate between empty schema and explicit false after below issue got fixed:
		//       https://github.com/go-openapi/spec/issues/148
		if input.AdditionalProperties.Schema == nil {
			field = &models.FieldDetails{
				Type:          models.Dictionary,
				DictValueType: tptr(models.Object),
			}
		} else {
			// This is kind of a weird piece of code that we reuse the mapField to map an `additionalProperties` block to the fieldDetails.
			// For general fields, the `mapField()` resolves the type of the field. While applies to `additionalProperties`,
			// it is resolving the type of the "value" in the dictionary.
			// Also, `mapField()` will pull out the nested model to be a reference, which is named to be "{modelName}{jsonName}".
			// Hence, we'll manipulate the fieldDetails returned to reflect that.
			consts, vfield, err := d.mapField(modelName, additionalPropertiesLit, *input.AdditionalProperties.Schema, false, constants)
			if err != nil {
				return nil, nil, fmt.Errorf("mapping additionalProperties: %+v", err)
			}
			field = vfield
			field.DictValueType = tptr(field.Type)
			field.Type = models.Dictionary

			allConstants.merge(consts)
		}
		fields[additionalPropertiesLit] = *field
	}

	return allConstants, fields, nil
}

func (d *SwaggerDefinition) modelsForModel(name string, input spec.Schema, constants constantDetailsMap, fields fieldDetailsMap) (constantDetailsMap, modelDetailsMap, error) {
	allConstants := make(constantDetailsMap, 0)
	for k, v := range constants {
		allConstants[k] = v
	}

	allModels := make(modelDetailsMap, 0)
	constantsWithinModel, modelsWithinModel, err := d.findModelsForModel(name, input, constants, modelDetailsMap{})
	if err != nil {
		return nil, nil, err
	}
	allConstants.merge(*constantsWithinModel)
	allModels.merge(*modelsWithinModel)

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
		allConstants.merge(*constantsHiddenInFields)
		allModels.merge(*modelsHiddenInFields)
	}

	return allConstants, allModels, nil
}

func (d *SwaggerDefinition) findModelsForModel(name string, input spec.Schema, constants constantDetailsMap, knownModels modelDetailsMap) (*constantDetailsMap, *modelDetailsMap, error) {
	allConstants := make(constantDetailsMap)
	for k, v := range constants {
		allConstants[k] = v
	}
	foundModels := make(modelDetailsMap)

	// handles recursive models
	for k := range knownModels {
		if strings.EqualFold(k, name) {
			return &allConstants, &foundModels, nil
		}
	}

	var allModels = func() modelDetailsMap {
		all := make(modelDetailsMap)
		all.merge(knownModels)
		all.merge(foundModels)
		return all
	}

	// add this model
	consts, fields, err := d.fieldsForModel(name, input, nil, constants)
	if err != nil {
		return nil, nil, fmt.Errorf("finding fields for %q: %+v", name, err)
	}
	allConstants.merge(consts)
	if len(fields) > 0 {
		foundModels[name] = models.ModelDetails{
			Description: "",
			Fields:      fields,
		}
	}

	// then iterate over the others
	properties := map[string]spec.Schema{}
	for k, v := range input.Properties {
		properties[k] = v
	}
	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		properties[additionalPropertiesLit] = *input.AdditionalProperties.Schema
	}

	for propName, propVal := range properties {
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
		if len(propVal.Type) != 0 && propVal.Type[0] == "array" {
			if propVal.Items.Schema != nil {
				fragmentName = fragmentNameFromReference(propVal.Items.Schema.Ref)
			}
		}
		if fragmentName != nil {
			// referenced constants are pulled out elsewhere
			if d.isConstant(constants, *fragmentName) {
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
			allConstants.merge(*nestedConstants)
			foundModels.merge(*nestedModels)
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

			allConstants.merge(*nestedConstants)
			foundModels.merge(*nestedModels)

			// update the model name for this field
			field := fields[propName]
			field.ModelReference = &uniqueName
			fields[propName] = field
			continue
		}
	}

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

			parent, err := d.findTopLevelModel(*fragmentName)
			if err != nil {
				return nil, nil, fmt.Errorf("finding top level model %q: %+v", *fragmentName, err)
			}

			if parent.Discriminator == "" {
				continue
			}

			details.ParentTypeName = fragmentName
			details.TypeHintIn = &parent.Discriminator
		}
	}

	foundModels[name] = details

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

	constExtension, err := parseConstantExtensionFromField(input)
	if err != nil {
		return nil, fmt.Errorf("parsing `x-ms-enum` extension: %+v", err)
	}

	constantType := models.StringConstant
	if input.Type.Contains("integer") {
		constantType = models.IntegerConstant
	} else if input.Type.Contains("number") {
		constantType = models.FloatConstant
	}

	keysAndValues := make(map[string]string)
	for i, raw := range input.Enum {
		if constantType == models.StringConstant {
			value, ok := raw.(string)
			if !ok {
				return nil, fmt.Errorf("expected a string but got %+v for the %d value for %q", raw, i, *name)
			}
			// Some numbers are modelled as strings
			if numVal, err := strconv.ParseFloat(value, 64); err == nil {
				if strings.Contains(value, ".") {
					normalizedName := cleanup.NormalizeConstantKey(value)
					keysAndValues[normalizedName] = value
					continue
				} else {
					key := keyValueForInteger(int64(numVal))
					val := fmt.Sprintf("%d", int64(numVal))
					normalizedName := cleanup.NormalizeConstantKey(key)
					keysAndValues[normalizedName] = val
					continue
				}
			}
			normalizedName := cleanup.NormalizeConstantKey(value)
			keysAndValues[normalizedName] = value
			continue
		}

		if constantType == models.IntegerConstant {
			// this gets parsed out as a float64 even though it's an Integer :upside_down_smile:
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an integer but got %+v for the %d value for %q", raw, i, *name)
			}

			key := keyValueForInteger(int64(value))
			val := fmt.Sprintf("%d", int64(value))
			normalizedName := cleanup.NormalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		if constantType == models.FloatConstant {
			value, ok := raw.(float64)
			if !ok {
				return nil, fmt.Errorf("expected an float but got %+v for the %d value for %q", raw, i, *name)
			}

			key := keyValueForFloat(value)
			val := stringValueForFloat(value)
			normalizedName := cleanup.NormalizeConstantKey(key)
			keysAndValues[normalizedName] = val
			continue
		}

		return nil, fmt.Errorf("unsupported constant type %q", string(constantType))
	}

	// allows us to parse out the actual types above then force a string here if needed
	if constExtension.modelAsString {
		constantType = models.StringConstant
	}

	return &parsedConstant{
		name: *name,
		details: models.ConstantDetails{
			Values:    keysAndValues,
			FieldType: constantType,
		},
	}, nil
}

func keyValueForInteger(value int64) string {
	s := fmt.Sprintf("%d", value)
	vals := map[int32]string{
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	out := ""
	for _, c := range s {
		v, ok := vals[c]
		if !ok {
			panic(fmt.Sprintf("missing mapping for %q", string(c)))
		}
		out += v
	}

	return out
}

func keyValueForFloat(value float64) string {
	stringified := stringValueForFloat(value)
	return cleanup.StringifyNumberInput(stringified)
}

func stringValueForFloat(value float64) string {
	return strconv.FormatFloat(value, 'f', -1, 64)
}

func (d *SwaggerDefinition) mapField(parentModelName, jsonName string, value spec.Schema, isRequired bool, constants constantDetailsMap) (constantDetailsMap, *models.FieldDetails, error) {
	allConstants := make(constantDetailsMap)
	for k, v := range constants {
		allConstants[k] = v
	}

	field := models.FieldDetails{
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
		constantName, err := parseConstantNameFromField(value)
		field.Type = models.Object
		field.ConstantReference = constantName

		// if it's inlined pull it out that way
		constant, err := mapConstant(value)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant: %+v", err)
		}
		allConstants[*constantName] = constant.details
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

			field.ListElementMin = value.MinItems
			field.ListElementMax = value.MaxItems
			field.ListElementUnique = &value.UniqueItems
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
							field.Type = models.Dictionary
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

				if value.AdditionalProperties.Schema.AdditionalItems != nil {
					field.ListElementMin = value.AdditionalItems.Schema.MinItems
					field.ListElementMax = value.AdditionalItems.Schema.MaxItems
					field.ListElementUnique = &value.AdditionalItems.Schema.UniqueItems
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
		if d.isConstant(constants, *referenceType) {
			field.ConstantReference = referenceType

			// if this is a reference to a top-level type it can be missed so it's worth pulling this out explicitly too
			if _, ok := allConstants[*referenceType]; !ok {
				model, err := d.findTopLevelModel(*referenceType)
				if err != nil {
					return nil, nil, fmt.Errorf("finding top level constant %q: %+v", *referenceType, err)
				}

				constant, err := mapConstant(*model)
				if err != nil {
					return nil, nil, fmt.Errorf("populating top level constant %q: %+v", *referenceType, err)
				}

				allConstants[*referenceType] = constant.details
			}
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

	return allConstants, &field, nil
}

func (d *SwaggerDefinition) isConstant(constants constantDetailsMap, name string) bool {
	// it must be either a constant or a model, but there'll be less constants to check
	for constName := range constants {
		if strings.EqualFold(constName, name) {
			return true
		}
	}

	// if it's a top level model, we can assert that too
	model, err := d.findTopLevelModel(name)
	if err != nil || model == nil {
		// intentional, since it may not be a top level model
		return false
	}

	return len(model.Enum) > 0
}

func mergeConstants(new models.ConstantDetails, existing *models.ConstantDetails) models.ConstantDetails {
	vals := make(map[string]string)
	fieldType := models.UnknownConstant
	if existing != nil {
		vals = existing.Values
		fieldType = existing.FieldType
	}
	if fieldType == models.UnknownConstant {
		fieldType = new.FieldType
	}
	for key, value := range new.Values {
		vals[key] = value
	}
	return models.ConstantDetails{
		Values:    vals,
		FieldType: fieldType,
	}
}

func (d *SwaggerDefinition) findImplementationsOf(parentName string) (*result, error) {
	out := result{}
	for childName, value := range d.swaggerSpecExtendedRaw.Definitions {
		if childName == parentName {
			continue
		}

		// does it implement (AllOf) the base class
		implementsParent := false
		for _, parent := range value.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			if *fragmentName == parentName {
				implementsParent = true
				break
			}
		}
		if !implementsParent {
			continue
		}

		if d.debugLog {
			log.Printf("[DEBUG] Found %q implements %q", childName, parentName)
		}

		result, err := d.parseModel(childName, value)
		if err != nil {
			return nil, fmt.Errorf("parsing model %q: %+v", childName, err)
		}

		out.append(*result)
	}

	return &out, nil
}
