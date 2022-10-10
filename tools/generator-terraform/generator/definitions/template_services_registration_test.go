package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestCodeForServicesRegistrationEmpty(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services:       map[string]models.ServiceInput{},
	}
	actual := codeForServicesRegistration(input)
	expected := `
package provider

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"github.com/hashicorp/terraform-provider-myprovider/internal/sdk"
)

func autoRegisteredTypedServices() []sdk.TypedServiceRegistration {
	return []sdk.TypedServiceRegistration{
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestCodeForServicesRegistration(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services: map[string]models.ServiceInput{
			"Compute": {
				ServicePackageName: "compute",
			},
			"Resource": {
				ServicePackageName: "resources",
			},
		},
	}
	actual := codeForServicesRegistration(input)
	expected := `
package provider

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"github.com/hashicorp/terraform-provider-myprovider/internal/sdk"

	"github.com/hashicorp/terraform-provider-myprovider/internal/services/compute"
	"github.com/hashicorp/terraform-provider-myprovider/internal/services/resources"
)

func autoRegisteredTypedServices() []sdk.TypedServiceRegistration {
	return []sdk.TypedServiceRegistration{
		compute.Registration{},
		resources.Registration{},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
