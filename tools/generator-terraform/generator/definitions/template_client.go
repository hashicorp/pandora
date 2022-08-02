package definitions

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

// TODO: tests

func templateForServiceClient(input models.ServiceInput) string {
	output := fmt.Sprintf(`
package %[1]s

import (
	"github.com/Azure/go-autorest/autorest"
	%[2]s_v%[3]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[2]s/%[4]s"
	"github.com/hashicorp/terraform-provider-azurerm/internal/common"
)

func NewClient(o *common.ClientOptions) *%[2]s_v%[3]s.Client {
	client := %[2]s_v%[3]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
		c.Authorizer = o.ResourceManagerAuthorizer
	})
	return &client
}
`, input.ServicePackageName, strings.ToLower(input.SdkServiceName), strings.ReplaceAll(input.ApiVersion, "-", "_"), input.ApiVersion)
	return strings.TrimSpace(output)
}
