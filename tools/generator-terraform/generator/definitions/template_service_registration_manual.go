package definitions

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForManualServiceRegistration(input models.ServiceInput) string {
	output := fmt.Sprintf(`
package %[1]s

import (
	"github.com/hashicorp/terraform-provider-azurerm/internal/sdk"
	"github.com/hashicorp/terraform-provider-azurerm/internal/tf/pluginsdk"
)

type Registration struct {
	autoRegistration
}

// Name is the name of this Service
func (r Registration) Name() string {
	return r.autoRegistration.Name()
}

// WebsiteCategories returns a list of categories which can be used for the sidebar
func (r Registration) WebsiteCategories() []string {
	return r.autoRegistration.WebsiteCategories()
}


// DataSources returns a list of Data Sources supported by this Service
func (r Registration) DataSources() []sdk.DataSource {
	dataSources := []sdk.DataSource{}
	dataSources = append(dataSources, r.autoRegistration.DataSources()...)
	return dataSources
}

// Resources returns a list of Resources supported by this Service
func (r Registration) Resources() []sdk.Resource {
	resources := []sdk.Resource{}
	resources = append(resources, r.autoRegistration.Resources()...)
	return resources
}
`, input.ServicePackageName)
	return strings.TrimSpace(output)
}
