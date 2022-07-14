package generator

import "fmt"

func importsForResource(input ResourceInput) string {
	return fmt.Sprintf(`
import (
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[2]s/%[3]s"
	"github.com/hashicorp/terraform-provider-azurerm/internal/sdk"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
)
`, input.SdkServiceName, input.SdkApiVersion, input.SdkResourceName)
}
