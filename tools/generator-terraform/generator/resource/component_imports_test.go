package resource

import (
	"strings"
	"testing"
)

func TestComponentImports(t *testing.T) {
	input := ResourceInput{
		SdkApiVersion:   "2020-06-01",
		SdkResourceName: "virtualmachines",
		SdkServiceName:  "compute",
	}
	actual := strings.TrimSpace(importsForResource(input))
	expected := strings.TrimSpace(`
import (
	"context"
	"fmt"
	"time"

	"github.com/hashicorp/go-azure-helpers/lang/response"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonschema"
	"github.com/hashicorp/go-azure-sdk/resource-manager/compute/2020-06-01/virtualmachines"
	"github.com/hashicorp/terraform-provider-azurerm/internal/sdk"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
)
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
