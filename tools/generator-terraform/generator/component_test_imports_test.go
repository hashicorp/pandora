package generator

import (
	"strings"
	"testing"
)

func TestComponentTestImports(t *testing.T) {
	input := ResourceInput{
		SdkApiVersion:   "2020-06-01",
		SdkResourceName: "virtualmachines",
		SdkServiceName:  "compute",
	}
	actual := strings.TrimSpace(importsForResourceTest(input))
	expected := strings.TrimSpace(`
import (
	"context"
	"fmt"
	"regexp"
	"testing"

	"github.com/hashicorp/go-azure-sdk/resource-manager/compute/2020-06-01/virtualmachines"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance/check"
	"github.com/hashicorp/terraform-provider-azurerm/internal/clients"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
	"github.com/hashicorp/terraform-provider-azurerm/utils"
)
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
