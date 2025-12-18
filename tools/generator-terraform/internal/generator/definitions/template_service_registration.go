// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func templateForServiceRegistration(input models.ServiceInput) string {
	codeForResources := make([]string, 0)
	for resource := range input.ResourceToApiVersion {
		codeForResources = append(codeForResources, fmt.Sprintf("%sResource{},", resource))
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

import "github.com/hashicorp/terraform-provider-%[2]s/internal/sdk"

var _ sdk.TypedServiceRegistration = autoRegistration{}

type autoRegistration struct {
}

func (autoRegistration) Name() string {
	return %[3]q
}

func (autoRegistration) DataSources() []sdk.DataSource {
	return []sdk.DataSource{}
}

func (autoRegistration) Resources() []sdk.Resource {
	return []sdk.Resource{
		%[4]s
	}
}

func (autoRegistration) WebsiteCategories() []string {
	return []string{
		%[5]s
	}
}
`, input.ServicePackageName, input.ProviderPrefix, input.ServiceDisplayName, strings.Join(codeForResources, "\n"), strings.Join(categories, "\n"))
	return strings.TrimSpace(output)
}
