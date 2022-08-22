package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (pipelineTask) generateTerraformDetails(input discovery.ServiceInput, data *models.AzureApiDefinition, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	// TODO: iterate over each of the TF resources that we have in input.TerraformServiceDefinition
	// call the Schema package build that up and the other stuff..
	//var details resourcemanager.TerraformDetails

	for _, resource := range data.Resources {
		r, err := transformer.ApiResourceFromModelResource(resource)
		if err != nil {
			return nil, err
		}

		b := schema.NewBuilder(resource.Constants, r.Schema.Models, r.Operations.Operations, r.Schema.ResourceIds)

		var details resourcemanager.TerraformDetails
		if t := resource.Terraform; t != nil {
			for k, v := range t.Resources {
				logger.Info(fmt.Sprintf("Building Schema for %s", k))
				model, err := b.Build(t.Resources[k], logger)
				if err != nil {
					return nil, err
				}
				//log.Printf("[DEBUG] model for %s: %+v", k, *model)
				//log.Printf("[DEBUG] resource: %+v", details.Resources[v.ResourceName].SchemaModels[k])

				if model != nil {
					if details.Resources == nil {
						details.Resources = make(map[string]resourcemanager.TerraformResourceDetails, 0)
						details.Resources[v.ResourceName] = resourcemanager.TerraformResourceDetails{
							SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
								k: *model,
							},
						}
					} else {
						details.Resources[v.ResourceName] = resourcemanager.TerraformResourceDetails{
							SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
								k: *model,
							},
						}
					}
				}
			}
		}
		resource.Terraform = &details
	}
	return data, nil
}
