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
	resourcesV20151101Preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type AutoClient struct {
	V20151101Preview resourcesV20151101Preview.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	v20151101PreviewClient, err := resourcesV20151101Preview.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for resources v20151101Preview: %+v", err)
	}
	return &AutoClient{
		V20151101Preview: v20151101PreviewClient,
	}, nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateForServiceClient_GoAutoRest(t *testing.T) {
	input := models.ServiceInput{
		ApiVersion:         "2015-11-01-preview",
		ProviderPrefix:     "myprovider", // intentionally not used, since this is `client`
		SdkServiceName:     "loadtestservice",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceClient(input)
	expected := `
package client

import (
	"github.com/Azure/go-autorest/autorest"
	loadtestserviceV20151101Preview "github.com/hashicorp/go-azure-sdk/resource-manager/loadtestservice/2015-11-01-preview"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type AutoClient struct {
	V20151101Preview loadtestserviceV20151101Preview.Client
	}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	v20151101PreviewClient := loadtestserviceV20151101Preview.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &AutoClient{
		V20151101Preview: v20151101PreviewClient,
	}, nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
