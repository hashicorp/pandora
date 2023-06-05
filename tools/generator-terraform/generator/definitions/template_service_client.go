package definitions

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

var servicesUsingOldBaseLayer = map[string]struct{}{
	// these should be lower-cased
	"containerservice": {},
	"loadtestservice":  {},
	"managedidentity":  {},
}

func templateForServiceClient(input models.ServiceInput) string {
	output := fmt.Sprintf(`
package client

import (
	%[1]s%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)

type AutoClient struct {
	%[2]s %[1]s%[2]s.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	%[5]sClient, err := %[1]s%[2]s.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for %[1]s %[2]s: %%+v", err)
	}

	return &AutoClient{
		%[2]s: %[5]sClient,
	}, nil
}
`, strings.ToLower(input.SdkServiceName), strings.Title(helpers.NamespaceForApiVersion(input.ApiVersion)), input.ApiVersion, input.ProviderPrefix, helpers.NamespaceForApiVersion(input.ApiVersion))

	if _, ok := servicesUsingOldBaseLayer[strings.ToLower(input.SdkServiceName)]; ok {
		output = fmt.Sprintf(`
package client
import (
	"github.com/Azure/go-autorest/autorest"
	%[1]s%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)

type AutoClient struct {
	%[2]s %[1]s%[2]s.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	%[5]sClient := %[1]s%[2]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &AutoClient{
		%[2]s: %[5]sClient,
	}, nil
}
`, strings.ToLower(input.SdkServiceName), strings.Title(helpers.NamespaceForApiVersion(input.ApiVersion)), input.ApiVersion, input.ProviderPrefix, helpers.NamespaceForApiVersion(input.ApiVersion))
	}

	return strings.TrimSpace(output)
}
