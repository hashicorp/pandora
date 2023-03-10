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

func NewClient(o *common.ClientOptions) (*%[1]s_%[2]s.Client, error) {
	client, err := %[1]s_%[2]s.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for %[1]s %[2]s: %%+v", err)
	}

	return &client, nil
}
`, strings.ToLower(input.SdkServiceName), namespaceForApiVersion(input.ApiVersion), input.ApiVersion, input.ProviderPrefix)

	if _, ok := servicesUsingOldBaseLayer[strings.ToLower(input.SdkServiceName)]; ok {
		output = fmt.Sprintf(`
package client
import (
	"github.com/Azure/go-autorest/autorest"
	%[1]s_%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)
func NewClient(o *common.ClientOptions) (*%[1]s_%[2]s.Client, error) {
	client := %[1]s_%[2]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &client, nil
}
`, strings.ToLower(input.SdkServiceName), namespaceForApiVersion(input.ApiVersion), input.ApiVersion, input.ProviderPrefix)
	}

	return strings.TrimSpace(output)
}
