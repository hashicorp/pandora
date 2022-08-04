package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestCodeForClientRegistrationsEmpty(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services:       map[string]models.ServiceInput{},
	}
	actual := codeForClientsRegistration(input)
	expected := `
package clients

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"context"

	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type autoClient struct {
}

func buildAutoClients(client *autoClient, o *common.ClientOptions) error {
	return nil
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestCodeForClientRegistrations(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services: map[string]models.ServiceInput{
			"Compute": {
				ApiVersion:         "2020-01-01",
				SdkServiceName:     "Compute",
				ServicePackageName: "compute",
			},
			"Resource": {
				ApiVersion:         "2015-11-01-preview",
				SdkServiceName:     "Resources",
				ServicePackageName: "resources",
			},
		},
	}
	actual := codeForClientsRegistration(input)
	expected := `
package clients

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"context"

	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
	compute "github.com/hashicorp/terraform-provider-myprovider/internal/services/compute/client"
	compute_v2020_01_01 "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2020-01-01"
	resources "github.com/hashicorp/terraform-provider-myprovider/internal/services/resources/client"
	resources_v2015_11_01_preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
)

type autoClient struct {
	Compute   *compute_v2020_01_01.Client
	Resource   *resources_v2015_11_01_preview.Client
}

func buildAutoClients(client *autoClient, o *common.ClientOptions) error {
	client.Compute = compute.NewClient(o)
	client.Resource = resources.NewClient(o)
	return nil
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
