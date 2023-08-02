package resourcemanager

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func terraform(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	terraform, ok := ctx.Value("terraform").(*repositories.TerraformDetails)
	if !ok {
		w.WriteHeader(http.StatusBadRequest)
		return
	}

	resources := mapTerraformResources(terraform.Resources)

	payload := models.TerraformDetails{
		DataSources: map[string]models.TerraformDataSourceDetails{},
		Resources:   resources,
	}
	render.JSON(w, r, payload)
}

func mapTerraformResources(input map[string]repositories.TerraformResourceDetails) map[string]models.TerraformResourceDetails {
	output := make(map[string]models.TerraformResourceDetails, 0)

	for name, resource := range input {
		output[name] = models.TerraformResourceDetails{
			ApiVersion: resource.ApiVersion,
			CreateMethod: models.MethodDefinition{
				Generate:         resource.CreateMethod.Generate,
				MethodName:       resource.CreateMethod.MethodName,
				TimeoutInMinutes: resource.CreateMethod.TimeoutInMinutes,
			},
			DeleteMethod: models.MethodDefinition{
				Generate:         resource.DeleteMethod.Generate,
				MethodName:       resource.DeleteMethod.MethodName,
				TimeoutInMinutes: resource.DeleteMethod.TimeoutInMinutes,
			},
			Documentation: models.ResourceDocumentationDefinition{
				Category:        resource.Documentation.Category,
				Description:     resource.Documentation.Description,
				ExampleUsageHcl: resource.Documentation.ExampleUsageHcl,
			},
			DisplayName:          resource.DisplayName,
			Generate:             resource.Generate,
			GenerateModel:        resource.GenerateModel,
			GenerateIdValidation: resource.GenerateIdValidation,
			GenerateSchema:       resource.GenerateSchema,
			Mappings: models.MappingDefinition{
				Fields:        nil,
				ModelToModels: nil,
				ResourceId:    nil,
			},
			ReadMethod: models.MethodDefinition{
				Generate:         resource.ReadMethod.Generate,
				MethodName:       resource.ReadMethod.MethodName,
				TimeoutInMinutes: resource.ReadMethod.TimeoutInMinutes,
			},
			Resource:        resource.Resource,
			ResourceIdName:  resource.ResourceIdName,
			ResourceName:    resource.ResourceName,
			SchemaModelName: resource.SchemaModelName,
			SchemaModels:    mapSchemaModels(&resource.SchemaModels),
			Tests: models.TerraformResourceTestsDefinition{
				BasicConfiguration:          resource.Tests.BasicConfiguration,
				RequiresImportConfiguration: resource.Tests.RequiresImportConfiguration,
				CompleteConfiguration:       resource.Tests.CompleteConfiguration,
				Generate:                    resource.Tests.Generate,
				OtherTests:                  resource.Tests.OtherTests,
				TemplateConfiguration:       resource.Tests.TemplateConfiguration,
			},
			UpdateMethod: mapUpdateMethod(resource.UpdateMethod),
		}
	}

	return output
}

func mapSchemaModels(input *map[string]repositories.TerraformSchemaModelDefinition) map[string]models.TerraformSchemaModelDefinition {
	if input == nil {
		return nil
	}

	output := make(map[string]models.TerraformSchemaModelDefinition, 0)

	for name, model := range *input {
		output[name] = models.TerraformSchemaModelDefinition{
			Fields: mapFields(model.Fields),
		}
	}

	return output
}

func mapFields(input map[string]repositories.TerraformSchemaFieldDefinition) map[string]models.TerraformSchemaFieldDefinition {
	output := make(map[string]models.TerraformSchemaFieldDefinition, 0)

	for name, field := range input {
		output[name] = models.TerraformSchemaFieldDefinition{
			ObjectDefinition: mapTerraformObjectDefinition(field.ObjectDefinition),
			Computed:         field.Computed,
			ForceNew:         field.ForceNew,
			HclName:          field.HclName,
			Optional:         field.Optional,
			Required:         field.Required,
			Documentation: models.TerraformSchemaDocumentationDefinition{
				Markdown: field.Documentation.Markdown,
			},
			Validation: mapValidation(field.Validation),
		}
	}

	return output
}

func mapTerraformObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) models.TerraformSchemaFieldObjectDefinition {
	output := models.TerraformSchemaFieldObjectDefinition{}

	if input.NestedObject != nil {
		output.NestedObject = pointer.To(mapTerraformObjectDefinition(*input.NestedObject))
	}
	output.ReferenceName = input.ReferenceName
	output.Type = models.TerraformSchemaFieldType(input.Type)

	return output
}

func mapUpdateMethod(input *repositories.MethodDefinition) *models.MethodDefinition {
	if input == nil {
		return nil
	}

	return &models.MethodDefinition{
		Generate:         input.Generate,
		MethodName:       input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}

func mapValidation(input *repositories.TerraformSchemaValidationDefinition) *models.TerraformSchemaValidationDefinition {
	if input == nil {
		return nil
	}

	output := models.TerraformSchemaValidationDefinition{
		Type:           models.TerraformSchemaValidationType(input.Type),
		PossibleValues: nil,
	}

	possibleValues := models.TerraformSchemaValidationPossibleValuesDefinition{}

	if input.PossibleValues != nil {
		possibleValues.Type = models.TerraformSchemaValidationPossibleValueType(input.PossibleValues.Type)
		possibleValues.Values = input.PossibleValues.Values
	}

	return &output
}
