package transforms

import (
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapServiceDefinitionToRepository(serviceName string, resourceProvider, terraformPackage *string, terraformResourceNames []string) (*dataapimodels.ServiceDefinition, error) {
	output := dataapimodels.ServiceDefinition{
		Name:                 serviceName,
		ResourceProvider:     resourceProvider,
		TerraformPackageName: terraformPackage,
		Generate:             true,
	}

	if terraformPackage != nil {
		sort.Strings(terraformResourceNames)

		output.Terraform = &dataapimodels.TerraformServiceDefinition{
			ServicePackageName: pointer.From(terraformPackage),
			Resources:          terraformResourceNames,
		}
	}

	return &output, nil
}
