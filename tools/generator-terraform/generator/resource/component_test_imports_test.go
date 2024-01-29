// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentTestImports(t *testing.T) {
	input := models.ResourceInput{
		SdkApiVersion:   "2020-06-01",
		SdkResourceName: "virtualmachines",
		SdkServiceName:  "compute",
	}
	actual, err := importsForResourceTest(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
import (
	"context"
	"fmt"
	"regexp"
	"testing"

	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/resource-manager/compute/2020-06-01/virtualmachines"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance"
	"github.com/hashicorp/terraform-provider-azurerm/internal/acceptance/check"
	"github.com/hashicorp/terraform-provider-azurerm/internal/clients"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
	"github.com/hashicorp/terraform-provider-azurerm/utils"
)
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
