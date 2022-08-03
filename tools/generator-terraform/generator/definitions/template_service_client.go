package definitions

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func templateForServiceClient(input models.ServiceInput) string {
	output := fmt.Sprintf(`
package client

import (
	"github.com/Azure/go-autorest/autorest"
	%[1]s_%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"
	"github.com/hashicorp/terraform-provider-%[4]s/internal/common"
)

func NewClient(o *common.ClientOptions) *%[1]s_%[2]s.Client {
	client := %[1]s_%[2]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &client
}
`, strings.ToLower(input.SdkServiceName), namespaceForApiVersion(input.ApiVersion), input.ApiVersion, input.ProviderPrefix)
	return strings.TrimSpace(output)
}
