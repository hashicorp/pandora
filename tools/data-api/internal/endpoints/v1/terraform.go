package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func (api Api) terraform(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}

	resources := mapTerraformResources(service.TerraformDetails.Resources)

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
