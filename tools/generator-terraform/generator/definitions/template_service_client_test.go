package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/testhelpers"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestTemplateForServiceClient(t *testing.T) {
	input := models.ServiceInput{
		ApiVersion:         "2015-11-01-preview",
		ProviderPrefix:     "myprovider", // intentionally not used, since this is `client`
		SdkServiceName:     "resources",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceClient(input)
	expected := `
package client

import (
	"github.com/Azure/go-autorest/autorest"
	resources_v2015_11_01_preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

func NewClient(o *common.ClientOptions) *resources_v2015_11_01_preview.Client {
	client := resources_v2015_11_01_preview.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &client
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
