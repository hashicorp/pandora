package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func templateForServiceRegistration(input models.ServiceInput) string {
	codeForDataSources := make([]string, 0)
	for _, v := range input.DataSourceNames {
		codeForDataSources = append(codeForDataSources, fmt.Sprintf("%sDataSource{},", v))
	}
	sort.Strings(codeForDataSources)

	codeForResources := make([]string, 0)
	for _, v := range input.ResourceNames {
		codeForResources = append(codeForResources, fmt.Sprintf("%sResource{},", v))
	}
	sort.Strings(codeForResources)

	categories := make([]string, 0)
	for _, v := range input.CategoryNames {
		categories = append(categories, fmt.Sprintf("%q,", v))
	}
	sort.Strings(categories)

	output := fmt.Sprintf(`
package %[1]s

// NOTE: this file is generated - manual changes will be overwritten.

import "github.com/hashicorp/terraform-provider-%[5]s/internal/sdk"

var _ sdk.TypedServiceRegistration = autoRegistration{}

type autoRegistration struct {
}

func (autoRegistration) Name() string {
	return %[2]q
}

func (autoRegistration) DataSources() []sdk.DataSource {
	return []sdk.DataSource{
		%[3]s
	}
}

func (autoRegistration) Resources() []sdk.Resource {
	return []sdk.Resource{
		%[4]s
	}
}

func (autoRegistration) WebsiteCategories() []string {
	return []string{
		%[6]s
	}
}
`, input.ServicePackageName, input.ServiceDisplayName, strings.Join(codeForDataSources, "\n"), strings.Join(codeForResources, "\n"), input.ProviderPrefix, strings.Join(categories, "\n"))
	return strings.TrimSpace(output)
}
