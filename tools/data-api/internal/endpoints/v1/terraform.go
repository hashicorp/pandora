// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"
	"strings"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
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

	resources, err := mapTerraformResources(service.TerraformDetails.Resources)
	if err != nil {
		internalServerError(w, err)
		return
	}

	payload := models.TerraformDetails{
		DataSources: map[string]models.TerraformDataSourceDetails{},
		Resources:   *resources,
	}

	render.JSON(w, r, payload)
}

func mapTerraformResources(input map[string]repositories.TerraformResourceDetails) (*map[string]models.TerraformResourceDetails, error) {
	output := make(map[string]models.TerraformResourceDetails, 0)

	for name, resource := range input {
		mappings, err := mapMappings(resource.Mappings)
		if err != nil {
			return nil, fmt.Errorf("mapping mappings for %q: %+v", name, err)
		}

		schemaModels, err := mapSchemaModels(resource.SchemaModels)
		if err != nil {
			return nil, fmt.Errorf("mapping schema models for %s: %+v", resource.ResourceName, err)
		}

		resourceDetails := models.TerraformResourceDetails{
			ApiVersion:   resource.ApiVersion,
			CreateMethod: mapMethodDefinition(resource.CreateMethod),
			DeleteMethod: mapMethodDefinition(resource.DeleteMethod),
			Documentation: models.ResourceDocumentationDefinition{
				Category:        resource.Documentation.Category,
				Description:     resource.Documentation.Description,
				ExampleUsageHcl: strings.TrimPrefix(strings.TrimSuffix(resource.Documentation.ExampleUsageHcl, "\n"), "\n"),
			},
			DisplayName:          resource.DisplayName,
			Generate:             resource.Generate,
			GenerateModel:        resource.GenerateModel,
			GenerateIdValidation: resource.GenerateIdValidation,
			GenerateSchema:       resource.GenerateSchema,
			Mappings:             *mappings,
			ReadMethod:           mapMethodDefinition(resource.ReadMethod),
			Resource:             resource.Resource,
			ResourceIdName:       resource.ResourceIdName,
			ResourceName:         resource.ResourceName,
			SchemaModelName:      resource.SchemaModelName,
			SchemaModels:         *schemaModels,
			Tests: models.TerraformResourceTestsDefinition{
				BasicConfiguration:          resource.Tests.BasicConfiguration,
				RequiresImportConfiguration: resource.Tests.RequiresImportConfiguration,
				CompleteConfiguration:       resource.Tests.CompleteConfiguration,
				Generate:                    resource.Tests.Generate,
				OtherTests:                  resource.Tests.OtherTests,
				TemplateConfiguration:       resource.Tests.TemplateConfiguration,
			},
		}
		if resource.UpdateMethod != nil {
			resourceDetails.UpdateMethod = pointer.To(mapMethodDefinition(*resource.UpdateMethod))
		}

		// todo remove this when https://github.com/hashicorp/pandora/issues/3352 is fixed
		// tests won't be added unless Generate is true when writing this out in dataapigeneratorjson/helpers.go writeTestsHclToFile
		// so we can set this to true if BasicConfiguration has been written out
		if resourceDetails.Tests.BasicConfiguration != "" {
			resourceDetails.Tests.Generate = true
		}

		output[resource.Label] = resourceDetails
	}

	return &output, nil
}
