package components

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform"
	"os"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

const configurationFilePath = "../../../../config/resource-manager.hcl"
const providerPrefix = "azurerm"
const restAPISpecsDirectory = "../../../../submodules/rest-api-specs"
const terraformDefinitionsDirectory = "../../../../config/resources"

func init() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")
}

func TestCanDiscoverFilesForAllServicesFromConfig(t *testing.T) {
	servicesFromConfigurationFile, err := services.LoadFromFile(configurationFilePath)
	if err != nil {
		t.Fatalf("loading config at %q: %+v", configurationFilePath, err)
	}

	for _, service := range servicesFromConfigurationFile.Services {
		t.Run(service.Name, func(t *testing.T) {
			availableDataSet, err := discovery.DiscoverForService(service, restAPISpecsDirectory)
			if err != nil {
				t.Fatalf("discovering Data for Service %q: %+v", service.Name, err)
			}

			t.Logf("Service %q contains %d API Versions", service.Name, len(availableDataSet.DataSetsForAPIVersions))
		})
	}
}

func TestCanParseFilesForAllServicesFromConfig(t *testing.T) {
	// NOTE: this test is an extension on the test above - and whilst we COULD combine them
	// it's actually helpful context to know whether we're having an issue loading the files
	// or parsing them, so that we know where to look - so I think it's worth having these as
	// separate tests for now.
	servicesFromConfigurationFile, err := services.LoadFromFile(configurationFilePath)
	if err != nil {
		t.Fatalf("loading config at %q: %+v", configurationFilePath, err)
	}

	for _, service := range servicesFromConfigurationFile.Services {
		t.Run(service.Name, func(t *testing.T) {
			availableDataSet, err := discovery.DiscoverForService(service, restAPISpecsDirectory)
			if err != nil {
				t.Fatalf("discovering Data for Service %q: %+v", service.Name, err)
			}

			parsedService, err := apidefinitions.ParseService(*availableDataSet)
			if err != nil {
				t.Errorf("parsing Data for Service %q: %+v", service.Name, err)
			}

			t.Logf("Service %q contains %d API Versions", service.Name, len(availableDataSet.DataSetsForAPIVersions))
			for apiVersion, details := range parsedService.APIVersions {
				t.Logf("Service %q API Version %q contains %d APIResources", service.Name, apiVersion, len(details.Resources))
			}
		})
	}
}

func TestCanParseTerraformConfigurations(t *testing.T) {
	terraformConfigurations, err := loadTerraformConfigurations(terraformDefinitionsDirectory)
	if err != nil {
		t.Fatalf(err.Error())
	}
	t.Logf("Loaded %d Terraform Configurations", len(*terraformConfigurations))
}

func TestCanBuildTerraformResources(t *testing.T) {
	servicesFromConfigurationFile, err := services.LoadFromFile(configurationFilePath)
	if err != nil {
		t.Fatalf("loading config at %q: %+v", configurationFilePath, err)
	}

	terraformConfigurations, err := loadTerraformConfigurations(terraformDefinitionsDirectory)
	if err != nil {
		t.Fatalf(err.Error())
	}

	for serviceName, serviceDetails := range *terraformConfigurations {
		service := findService(servicesFromConfigurationFile, serviceName)
		if service == nil {
			t.Fatalf("Unable to find the Configuration for the Service %q referenced in Terraform Resources", serviceName)
		}

		availableDataSet, err := discovery.DiscoverForService(*service, restAPISpecsDirectory)
		if err != nil {
			t.Fatalf("discovering Data for Service %q: %+v", serviceName, err)
		}

		parsedService, err := apidefinitions.ParseService(*availableDataSet)
		if err != nil {
			t.Errorf("parsing Data for Service %q: %+v", serviceName, err)
		}

		buildTerraform, err := terraform.BuildForService(*parsedService, serviceDetails.resourceLabelToResourceDefinitions, providerPrefix, serviceDetails.terraformPackageName)
		if err != nil {
			t.Fatalf("building Terraform for Service %q: %+v", serviceName, err)
		}

		t.Logf("Service %q contains %d Terraform Resources", serviceName, len(buildTerraform.TerraformDefinition.Resources))
	}
}

type terraformDetailsForService struct {
	resourceLabelToResourceDefinitions map[string]definitions.ResourceDefinition
	terraformPackageName               *string
}

func loadTerraformConfigurations(terraformDefinitionsDirectory string) (*map[string]terraformDetailsForService, error) {
	logging.Debugf("Parsing the Terraform Resource Definitions..")
	terraformResourceDefinitions, err := definitions.LoadFromDirectory(terraformDefinitionsDirectory)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Definitions from %q: %+v", terraformDefinitionsDirectory, err)
	}

	// NOTE: when the `definitions` package is refactored, this can be cleaned up
	// part of https://github.com/hashicorp/pandora/issues/3754
	servicesToTerraformDetails := make(map[string]terraformDetailsForService)
	for serviceName, serviceData := range terraformResourceDefinitions.Services {
		terraformResourceDefinition := make(map[string]definitions.ResourceDefinition)
		for _, apiVersionData := range serviceData.ApiVersions {
			for _, apiResourceData := range apiVersionData.Packages {
				for resourceLabel, resourceData := range apiResourceData.Definitions {
					terraformResourceDefinition[resourceLabel] = resourceData
				}
			}
		}
		servicesToTerraformDetails[serviceName] = terraformDetailsForService{
			resourceLabelToResourceDefinitions: terraformResourceDefinition,
			terraformPackageName:               pointer.To(serviceData.TerraformPackageName),
		}
	}
	return &servicesToTerraformDetails, nil
}

func findService(input *services.Config, serviceName string) *services.Service {
	for _, item := range input.Services {
		if item.Name == serviceName {
			return &item
		}
	}
	return nil
}
