package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func Run(input []importerModels.AzureApiDefinition, outputDirectory, swaggerGitSha string, resourceProvider, terraformServicePackage *string, logger hclog.Logger) error {
	sourceDataOrigin := models.AzureRestAPISpecsSourceDataOrigin
	sourceDataType := models.ResourceManagerSourceDataType

	// TODO: remove this once the repository is consolidated since this should be inferrable
	terraformResourceNames := make([]string, 0)
	if terraformServicePackage != nil {
		for _, item := range input {
			for _, resource := range item.Resources {
				if resource.Terraform == nil {
					continue
				}

				for _, details := range resource.Terraform.Resources {
					terraformResourceNames = append(terraformResourceNames, details.ResourceName)
				}
			}
		}
	}

	serviceName := input[0].ServiceName

	stages := []generatorStage{
		generateMetaDataStage{
			gitRevision:      pointer.To(swaggerGitSha),
			sourceDataOrigin: sourceDataOrigin,
			sourceDataType:   sourceDataType,
		},
		generateServiceDefinitionStage{
			serviceName:             serviceName,
			resourceProvider:        resourceProvider,
			shouldGenerate:          true,
			terraformServicePackage: terraformServicePackage,
			terraformResourceNames:  terraformResourceNames,
		},
	}

	for _, serviceDetails := range input {
		stages = append(stages, generateAPIVersionStage{
			serviceName:      serviceDetails.ServiceName,
			apiVersion:       serviceDetails.ApiVersion,
			isPreviewVersion: serviceDetails.IsPreviewVersion(),
			resources:        serviceDetails.Resources,
			sourceDataOrigin: sourceDataOrigin,
			shouldGenerate:   true,
		})

		for apiResourceName, apiResourceDetails := range serviceDetails.Resources {
			// transform `models.AzureAPIResource` into the `resourcemanager` models so we have a consistent type
			// whilst this WILL change to the `data-api-sdk` models, we should standardise on `resourcemanager` first
			// so we have an easier migration path.
			input, err := transformer.ApiResourceFromModelResource(apiResourceDetails)
			if err != nil {
				return fmt.Errorf("transforming to APIResource: %+v", err)
			}

			stages = append(stages, generateConstantStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
			})

			stages = append(stages, generateModelsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
				models:      input.Schema.Models,
			})

			stages = append(stages, generateOperationsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
				models:      input.Schema.Models,
				operations:  input.Operations.Operations,
			})

			stages = append(stages, generateResourceIDsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				resourceIDs: input.Schema.ResourceIds,
			})
		}
	}

	fs := newFileSystem()

	logger.Debug("Running stages..")
	for _, stage := range stages {
		logger.Trace(fmt.Sprintf("Processing Stage %q", stage.name()))
		if err := stage.generate(fs, logger); err != nil {
			return fmt.Errorf("running stage %q: %+v", stage.name(), err)
		}
	}

	logger.Debug("Persisting files to disk..")
	if err := persistFileSystem(outputDirectory, sourceDataType, serviceName, fs, logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
