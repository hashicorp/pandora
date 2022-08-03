package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestCodeForManualServiceRegistration(t *testing.T) {
	input := models.ServiceInput{
		ProviderPrefix:     "myprovider",
		ServicePackageName: "mypackage",
	}
	actual := codeForManualServiceRegistration(input)
	expected := `
package mypackage

import (
	"github.com/hashicorp/terraform-provider-myprovider/internal/sdk"
	"github.com/hashicorp/terraform-provider-myprovider/internal/tf/pluginsdk"
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
`
	assertTemplatedCodeMatches(t, expected, actual)
}
