package pipeline

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (pipelineTask) generateTerraformDetails(input discovery.ServiceInput, data *models.AzureApiDefinition, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	for key, resource := range data.Resources {
		if resource.Terraform == nil {
			continue
		}

		// This is the data API name of the resource i.e. VirtualMachines
		r, err := transformer.ApiResourceFromModelResource(resource)
		if err != nil {
			return nil, err
		}

		b := schema.NewBuilder(resource.Constants, r.Schema.Models, r.Operations.Operations, r.Schema.ResourceIds)

		terraformResources := make(map[string]resourcemanager.TerraformResourceDetails)
		for resourceLabel, resourceDetails := range resource.Terraform.Resources {
			// We need to add to this map any sub-schemas we find so their classes can also be generated
			logger.Info(fmt.Sprintf("Building Schema for %s", resourceLabel))

			// use the ResourceName to build up the name for this Schema Model
			resourceDetails.SchemaModelName = fmt.Sprintf("%sResource", resourceDetails.ResourceName)
			modelsForResource, err := b.Build(resourceDetails, logger)
			if err != nil {
				return nil, err
			}

			if modelsForResource == nil {
				logger.Debug(fmt.Sprintf("Resource %q returned no models, meaning this has been filtered out (maybe a discriminated type)"))
				continue
			}

			resourceDetails.SchemaModels = *modelsForResource

			terraformResources[resourceLabel] = resourceDetails
		}
		resource.Terraform.Resources = terraformResources

		data.Resources[key] = resource
	}

	return data, nil
}

func findAllNestedModelsForResource(model *resourcemanager.TerraformSchemaModelDefinition, resource models.AzureApiResource) ([]string, []string) {
	foundModels := make([]string, 0)
	foundEnums := make([]string, 0)

	for _, m := range model.Fields {
		if ref := m.ObjectDefinition.ReferenceName; ref != nil {
			if strings.EqualFold(*ref, "subresource") {
				// subresources are remote IDs, so should be references to the IDs not models here
				continue
			}
			if _, ok := resource.Models[*ref]; ok {
				// Check it's actually a model, not a reference to an enum
				foundModels = append(foundModels, *ref)
				continue
			}
			if _, ok := resource.Constants[*ref]; ok {
				foundEnums = append(foundEnums, *ref)
				continue
			}
		}
		if m.ObjectDefinition.NestedObject != nil {
			if ref := m.ObjectDefinition.NestedObject.ReferenceName; ref != nil {
				if strings.EqualFold(*ref, "subresource") {
					// subresources are remote IDs, so should be references to the IDs not models here
					continue
				}
				if _, ok := resource.Models[*ref]; ok {
					// Check it's actually a model, not a reference to an enum
					foundModels = append(foundModels, *ref)
					continue
				}
				if _, ok := resource.Constants[*ref]; ok {
					foundEnums = append(foundEnums, *ref)
					continue
				}
			}
		}
	}

	// make the list unique
	foundModels = dedupeList(foundModels)
	foundEnums = dedupeList(foundEnums)

	for _, v := range foundModels {
		if m, ok := resource.Models[v]; ok {
			for n, f := range m.Fields {
				log.Printf("processing field %q for model %q", n, v)
				if f.ObjectDefinition != nil && f.ObjectDefinition.ReferenceName != nil {
					ref := *f.ObjectDefinition.ReferenceName
					if _, constant := resource.Constants[ref]; constant {
						if _, isConstant := resource.Constants[ref]; isConstant {
							foundEnums = append(foundEnums, ref)
						}
						continue
					}
					foundModels, foundEnums = findNestedModelsForModel(ref, resource, foundModels, foundEnums)
				} else if f.ObjectDefinition != nil && f.ObjectDefinition.NestedItem != nil && f.ObjectDefinition.NestedItem.ReferenceName != nil {
					ref := *f.ObjectDefinition.NestedItem.ReferenceName
					if _, constant := resource.Constants[ref]; constant {
						if _, isConstant := resource.Constants[ref]; isConstant {
							foundEnums = append(foundEnums, ref)
						}
						continue
					}
					foundModels, foundEnums = findNestedModelsForModel(ref, resource, foundModels, foundEnums)
				}
			}
		}
	}

	return foundModels, foundEnums
}

func findNestedModelsForModel(model string, resource models.AzureApiResource, foundModels []string, foundEnums []string) ([]string, []string) {
	newRef := ""
	if m, ok := resource.Models[model]; ok {
		foundModels = append(foundModels, model)
		for _, v := range m.Fields {
			if v.ObjectDefinition != nil && v.ObjectDefinition.ReferenceName != nil {
				newRef = *v.ObjectDefinition.ReferenceName
				if _, ok := resource.Models[newRef]; !ok {
					if _, isConstant := resource.Constants[newRef]; isConstant {
						foundEnums = append(foundEnums, newRef)
					}
					continue
				}
				foundModels = append(foundModels, newRef)
			} else if v.ObjectDefinition.NestedItem != nil && v.ObjectDefinition.NestedItem.ReferenceName != nil {
				newRef = *v.ObjectDefinition.NestedItem.ReferenceName
				if _, ok := resource.Models[newRef]; !ok {
					if _, isConstant := resource.Constants[newRef]; isConstant {
						foundEnums = append(foundEnums, newRef)
					}
					continue
				}
				foundModels = append(foundModels, newRef)
			}
			if newRef != "" {
				foundModels, foundEnums = findNestedModelsForModel(newRef, resource, foundModels, foundEnums)
			}
		}
	}

	return dedupeList(foundModels), dedupeList(foundEnums)
}

func dedupeList(input []string) []string {
	uniqMap := make(map[string]struct{})
	for _, v := range input {
		uniqMap[v] = struct{}{}
	}

	uniqList := make([]string, 0, len(uniqMap))
	for v := range uniqMap {
		uniqList = append(uniqList, v)
	}

	return uniqList
}
