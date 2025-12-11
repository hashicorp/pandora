// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

type commonSchemaDocsBuilderFunc = func(resourceName string) []string

var documentationForCommonSchemaBlocksAttributes = map[models.TerraformSchemaObjectDefinitionType]commonSchemaDocsBuilderFunc{
	models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `type` - (Required) Specifies the type of Managed Identity that should be assigned to this %s. The only possible value is `SystemAssigned`.", resourceName),
		}
	},
	models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `type` - (Required) Specifies the type of Managed Identity that should be assigned to this %s. Possible values are `SystemAssigned`, `SystemAssigned, UserAssigned` and `UserAssigned`.", resourceName),
			fmt.Sprintf("* `identity_ids` - (Optional) A list of the User Assigned Identity IDs that should be assigned to this %s.", resourceName),
		}
	},
	models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `type` - (Required) Specifies the type of Managed Identity that should be assigned to this %s. Possible values are `SystemAssigned` and `UserAssigned`.", resourceName),
			fmt.Sprintf("* `identity_ids` - (Optional) A list of the User Assigned Identity IDs that should be assigned to this %s.", resourceName),
		}
	},
	models.UserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `identity_ids` - (Required) A list of the User Assigned Identity IDs that should be assigned to this %s.", resourceName),
			fmt.Sprintf("* `type` - (Required) Specifies the type of Managed Identity that should be assigned to this %s. The only possible value is `UserAssigned`.", resourceName),
		}
	},
}

var documentationForCommonSchemaBlocksArguments = map[models.TerraformSchemaObjectDefinitionType]commonSchemaDocsBuilderFunc{
	models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `principal_id` - The Principal ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
			fmt.Sprintf("* `tenant_id` - The Tenant ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
		}
	},
	models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `principal_id` - The Principal ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
			fmt.Sprintf("* `tenant_id` - The Tenant ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
		}
	},
	models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{
			fmt.Sprintf("* `principal_id` - The Principal ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
			fmt.Sprintf("* `tenant_id` - The Tenant ID for the System-Assigned Managed Identity assigned to this %s.", resourceName),
		}
	},
	models.UserAssignedIdentityTerraformSchemaObjectDefinitionType: func(resourceName string) []string {
		return []string{}
	},
}

type blockDefinition struct {
	// isList specifies whether this blockDefinition is a List (for example, so we can output "Each XXX block supports"
	// rather than "A XXX block supports")
	isList bool

	// nestedWithin specifies which block this field is nested under - a block nested under the
	// top-level model will be an empty string
	nestedWithin string

	// objectDefinition is the (Top-Level) Object Definition for this Terraform Schema Field
	objectDefinition models.TerraformSchemaObjectDefinition
}

func codeForBlocksReference(input generatorModels.ResourceInput) (*string, error) {
	// We need the `hcl_name` for each field to be able to output it correctly, so we have to first
	// process the top-level model, and then each referenced model to build up the full output.
	//
	// The benefit to doing this is it means we can detect nested models, so we can output things like
	// the "bar" block within the "foo" block.

	// So, let's start with the top-level model and find the blocks nested within it
	nestedWithin := "" // top-level models aren't nested
	blocksWithinModel, err := parseBlocksWithinModel(input.SchemaModels, input.SchemaModelName, nestedWithin)
	if err != nil {
		return nil, fmt.Errorf("parsing blocks within the top-level model %q: %+v", input.SchemaModelName, err)
	}

	// now we have a canonical list of block names, let's go through and sort those
	blockNames := make([]string, 0)
	for k := range *blocksWithinModel {
		blockNames = append(blockNames, k)
	}
	sort.Strings(blockNames)

	// then iterate over each of the block names, and build up the documentation
	documentation := make([]string, 0)
	for _, blockName := range blockNames {
		block := (*blocksWithinModel)[blockName]

		docs, err := buildDocumentationForBlock(blockName, block, input.SchemaModels, input.Details.DisplayName)
		if err != nil {
			return nil, fmt.Errorf("building documentation for the %q block: %+v", blockName, err)
		}
		documentation = append(documentation, *docs)
	}

	// finally format and output that
	output := ""
	if len(documentation) > 0 {
		output = fmt.Sprintf(`## Blocks Reference

%s`, strings.Join(documentation, "\n\n"))
	}

	return &output, nil
}

func parseBlocksWithinModel(schemaModels map[string]models.TerraformSchemaModel, modelName string, nestedWithin string) (*map[string][]blockDefinition, error) {
	output := make(map[string][]blockDefinition, 0)

	thisModel, ok := schemaModels[modelName]
	if !ok {
		return nil, fmt.Errorf("a schema model named %q was not found", modelName)
	}

	for fieldName, field := range thisModel.Fields {
		objectDefinition := topLevelObjectDefinition(field.ObjectDefinition)
		if _, isBlock := objectDefinitionsWhichShouldBeSurfacedAsBlocks[objectDefinition.Type]; !isBlock {
			continue
		}

		existing, ok := output[field.HCLName]
		if !ok {
			existing = make([]blockDefinition, 0)
		}

		existing = append(existing, blockDefinition{
			isList:           field.ObjectDefinition.Type == models.ListTerraformSchemaObjectDefinitionType || field.ObjectDefinition.Type == models.SetTerraformSchemaObjectDefinitionType,
			nestedWithin:     nestedWithin,
			objectDefinition: objectDefinition,
		})
		output[field.HCLName] = existing

		// for references, we then need to run down the chain to get its items, and append them
		if objectDefinition.Type == models.ReferenceTerraformSchemaObjectDefinitionType {
			// NOTE: we're only doing this for references and not all block types because others can be customtypes which don't have a reference
			if objectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("processing field %q: field is a Reference with no ReferenceName", fieldName)
			}
			nestedBlocks, err := parseBlocksWithinModel(schemaModels, *objectDefinition.ReferenceName, field.HCLName)
			if err != nil {
				return nil, fmt.Errorf("processing field %q: parsing blocks within nested model %q: %+v", fieldName, *objectDefinition.ReferenceName, err)
			}
			// then go through and append the blocks
			for k, v := range *nestedBlocks {
				existing, hasExisting := output[k]
				if !hasExisting {
					output[k] = v
					continue
				}

				existing = append(existing, v...)
				output[k] = existing
			}
		}
	}

	return &output, nil
}

func buildDocumentationForBlock(blockName string, definitions []blockDefinition, schemaModels map[string]models.TerraformSchemaModel, resourceName string) (*string, error) {
	// determine if we need to output each model uniquely, or if we should de-dupe them in the output
	areAllUsagesTheSame := true
	if len(definitions) > 1 {
		firstDefinition := definitions[0]
		for _, thisDefinition := range definitions[1:] {
			if thisDefinition.isList != firstDefinition.isList {
				areAllUsagesTheSame = false
				break
			}

			if !objectDefinitionsMatch(firstDefinition.objectDefinition, thisDefinition.objectDefinition) {
				areAllUsagesTheSame = false
				break
			}
		}
	}

	if areAllUsagesTheSame {
		// output the de-duped documentation directly for this block (e.g. "An 'XXX' block supports")
		definitions[0].nestedWithin = "" // fake this being a top-level block, since it's now being repurposed
		return documentationForBlock(blockName, definitions[0], schemaModels, resourceName)
	}

	nestedWithinNames := make([]string, 0)
	nestedWithinData := make(map[string]blockDefinition)
	var topLevelBlock *blockDefinition
	for _, definition := range definitions {
		if definition.nestedWithin == "" {
			topLevelBlock = pointer.To(definition)
			continue
		}

		nestedWithinData[definition.nestedWithin] = definition
		nestedWithinNames = append(nestedWithinNames, definition.nestedWithin)
	}

	// output the top-level block first
	linesForBlocks := make([]string, 0)
	if topLevelBlock != nil {
		docsForBlock, err := documentationForBlock(blockName, *topLevelBlock, schemaModels, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation for the top-level block %q: %+v", blockName, err)
		}
		linesForBlocks = append(linesForBlocks, *docsForBlock)
	}

	for _, name := range nestedWithinNames {
		nestedWithin := nestedWithinData[name]
		docsForBlock, err := documentationForBlock(blockName, nestedWithin, schemaModels, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation for the top-level block %q: %+v", blockName, err)
		}
		linesForBlocks = append(linesForBlocks, *docsForBlock)
	}

	output := strings.Join(linesForBlocks, "\n\n")
	return &output, nil
}

func documentationForBlock(blockName string, objectDefinition blockDefinition, schemaModels map[string]models.TerraformSchemaModel, resourceName string) (*string, error) {
	argumentsForBlock, err := getArgumentsForBlock(objectDefinition.objectDefinition, blockName, schemaModels, resourceName)
	if err != nil {
		return nil, fmt.Errorf("building arguments for block %s: %+v", blockName, err)
	}
	attributesForBlock, err := getAttributesForBlock(objectDefinition.objectDefinition, blockName, schemaModels, resourceName)
	if err != nil {
		return nil, fmt.Errorf("building attributes for block %s: %+v", blockName, err)
	}

	// if all usages aren't the same, and this is a top-level block, call out that this is a top-level block explictly
	// e.g. "'example' block (top-level)"
	title := fmt.Sprintf("`%s` Block", blockName)
	descriptionPrefix := fmt.Sprintf("The `%s` block", blockName)
	if objectDefinition.nestedWithin != "" {
		title = fmt.Sprintf("%s (within the `%s` block)", title, objectDefinition.nestedWithin)
		descriptionPrefix = fmt.Sprintf("%s within the `%s` block", descriptionPrefix, objectDefinition.nestedWithin)
	}

	out := fmt.Sprintf("### %[1]s\n", title)
	if len(*argumentsForBlock) > 0 {
		out = fmt.Sprintf(`%[1]s

%[2]s supports the following arguments:

%[3]s
`, out, descriptionPrefix, strings.Join(*argumentsForBlock, "\n"))
	}
	if len(*attributesForBlock) > 0 {
		line := fmt.Sprintf("%s exports the following attributes:", descriptionPrefix)
		if len(*argumentsForBlock) > 0 {
			line = fmt.Sprintf("In addition to the arguments defined above, the `%s` block exports the following attributes:", blockName)
			if objectDefinition.nestedWithin != "" {
				line = fmt.Sprintf("In addition to the arguments defined above, the `%s` block within the `%s` block exports the following attributes:", blockName, objectDefinition.nestedWithin)
			}
		}

		out = fmt.Sprintf(`%[1]s

%[2]s

%[3]s
`, out, line, strings.Join(*attributesForBlock, "\n"))
	}
	return &out, nil
}

func getArgumentsForBlock(objectDefinition models.TerraformSchemaObjectDefinition, nestedWithin string, schemaModels map[string]models.TerraformSchemaModel, resourceName string) (*[]string, error) {
	// if it's a commonschema item, the documentation is hand-defined since it's a reference, so we should pull this out
	commonSchemaArgsFunc, isCommonSchemaField := documentationForCommonSchemaBlocksAttributes[objectDefinition.Type]
	if isCommonSchemaField {
		out := commonSchemaArgsFunc(resourceName)
		return &out, nil
	}

	if objectDefinition.Type != models.ReferenceTerraformSchemaObjectDefinitionType {
		return nil, fmt.Errorf("expected a reference but got %q", string(objectDefinition.Type))
	}
	model, ok := schemaModels[*objectDefinition.ReferenceName]
	if !ok {
		return nil, fmt.Errorf("the schema model %q was not found", *objectDefinition.ReferenceName)
	}

	requiredFieldNames := make([]string, 0)
	optionalFieldNames := make([]string, 0)
	for fieldName, field := range model.Fields {
		if field.Required {
			requiredFieldNames = append(requiredFieldNames, fieldName)
		}
		if field.Optional {
			optionalFieldNames = append(optionalFieldNames, fieldName)
		}
	}
	sort.Strings(requiredFieldNames)
	sort.Strings(optionalFieldNames)

	lines := make([]string, 0)
	for _, fieldName := range requiredFieldNames {
		field := model.Fields[fieldName]
		docs, err := documentationLineForArgument(field, nestedWithin, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation for required argument field %q: %+v", fieldName, err)
		}
		lines = append(lines, *docs)
	}
	for _, fieldName := range optionalFieldNames {
		field := model.Fields[fieldName]
		docs, err := documentationLineForArgument(field, nestedWithin, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation for optional argument field %q: %+v", fieldName, err)
		}
		lines = append(lines, *docs)
	}

	return &lines, nil
}

func getAttributesForBlock(objectDefinition models.TerraformSchemaObjectDefinition, nestedWithin string, schemaModels map[string]models.TerraformSchemaModel, resourceName string) (*[]string, error) {
	// if it's a commonschema item, the documentation is hand-defined since it's a reference, so we should pull this out
	commonSchemaAttrsFunc, isCommonSchemaField := documentationForCommonSchemaBlocksArguments[objectDefinition.Type]
	if isCommonSchemaField {
		out := commonSchemaAttrsFunc(resourceName)
		return &out, nil
	}

	if objectDefinition.Type != models.ReferenceTerraformSchemaObjectDefinitionType {
		return nil, fmt.Errorf("expected a reference but got %q", string(objectDefinition.Type))
	}
	model, ok := schemaModels[*objectDefinition.ReferenceName]
	if !ok {
		return nil, fmt.Errorf("the schema model %q was not found", *objectDefinition.ReferenceName)
	}

	fieldNames := make([]string, 0)
	for fieldName, field := range model.Fields {
		if field.Computed && !field.Optional && !field.Required {
			fieldNames = append(fieldNames, fieldName)
		}
	}
	sort.Strings(fieldNames)

	lines := make([]string, 0)
	for _, fieldName := range fieldNames {
		field := model.Fields[fieldName]
		docs, err := documentationLineForAttribute(field, nestedWithin)
		if err != nil {
			return nil, fmt.Errorf("building documentation for computed attribute field %q: %+v", fieldName, err)
		}
		lines = append(lines, *docs)
	}

	return &lines, nil
}
