package definitions

import (
	"fmt"
	"strings"

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
	%[1]s_%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)

type AutoClient struct {
	%[5]s_%[2]s %[1]s_%[2]s.Client
}

func NewClient(o *common.ClientOptions) (*%[1]s_%[2]s.Client, error) {
	client_%[2]s, err := %[1]s_%[2]s.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for %[1]s %[2]s: %%+v", err)
	}

	return &AutoClient{
		%[5]s_%[2]s: client_%[2]s,
	}, nil
}
`, strings.ToLower(input.SdkServiceName), namespaceForApiVersion(input.ApiVersion), input.ApiVersion, input.ProviderPrefix, input.SdkServiceName)

	if _, ok := servicesUsingOldBaseLayer[strings.ToLower(input.SdkServiceName)]; ok {
		output = fmt.Sprintf(`
package client
import (
	"github.com/Azure/go-autorest/autorest"
	%[1]s_%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)

type AutoClient struct {
	%[5]s_%[2]s %[1]s_%[2]s.Client
}

func NewClient(o *common.ClientOptions) (*%[1]s_%[2]s.Client, error) {
	client_%[2]s := %[1]s_%[2]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &AutoClient{
		%[5]s_%[2]s: client_%[2]s,
	}, nil
}
`, strings.ToLower(input.SdkServiceName), namespaceForApiVersion(input.ApiVersion), input.ApiVersion, input.ProviderPrefix, input.SdkServiceName)
	}

	return strings.TrimSpace(output)
}
