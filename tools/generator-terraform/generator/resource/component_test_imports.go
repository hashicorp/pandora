package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func importsForResourceTest(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
import (
	"context"
	"fmt"
	"regexp"
	"testing"

	"github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[2]s/%[3]s"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance/check"
	"github.com/hashicorp/terraform-provider-azurerm/internal/clients"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
	"github.com/hashicorp/terraform-provider-azurerm/utils"
)
`, input.SdkServiceName, input.SdkApiVersion, input.SdkResourceName)
	return &output, nil
}
