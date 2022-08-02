package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func importsForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
import (
	"context"
	"fmt"
	"time"

	"github.com/hashicorp/go-azure-helpers/lang/response"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonschema"
	"github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[2]s/%[3]s"
	"github.com/hashicorp/terraform-provider-azurerm/internal/sdk"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
)
`, strings.ToLower(input.SdkServiceName), input.SdkApiVersion, strings.ToLower(input.SdkResourceName))
	return &output, nil
}
