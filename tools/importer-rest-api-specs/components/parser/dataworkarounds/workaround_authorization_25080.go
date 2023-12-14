package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAuthorization25080{}

type workaroundAuthorization25080 struct {
}

func (workaroundAuthorization25080) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "Authorization" && apiDefinition.ApiVersion == "2020-10-01"
}

func (workaroundAuthorization25080) Name() string {
	return "Authorization / 25080"
}

func (workaroundAuthorization25080) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["RoleManagementPolicies"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `RoleManagementPolicies` but didn't get one")
	}
	operation, ok := resource.Operations["ListForScope"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `ListForScope` but didn't get one")
	}
	operation.Options["Filter"] = models.OperationOption{
		ObjectDefinition: &models.ObjectDefinition{
			Type: models.ObjectDefinitionString,
		},
		QueryStringName: pointer.To("$filter"),
		Required:        false,
	}
	resource.Operations["ListForScope"] = operation
	apiDefinition.Resources["RoleManagementPolicies"] = resource
	return &apiDefinition, nil
}
