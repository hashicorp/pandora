// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func importsForResourceTest(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
import (
	"context"
	"fmt"
	"regexp"
	"testing"

	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[2]s/%[3]s"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance/check"
	"github.com/hashicorp/terraform-provider-azurerm/internal/clients"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
	"github.com/hashicorp/terraform-provider-azurerm/utils"
)
`, strings.ToLower(input.SdkServiceName), input.SdkApiVersion, strings.ToLower(input.SdkResourceName))
	return &output, nil
}
