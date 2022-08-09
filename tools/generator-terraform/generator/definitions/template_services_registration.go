package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForServicesRegistration(input models.ServicesInput) string {
	importLines := make([]string, 0)
	serviceRegistrationLines := make([]string, 0)
	for _, service := range input.Services {
		importLines = append(importLines, fmt.Sprintf(`"github.com/hashicorp/terraform-provider-%s/internal/services/%s"`, input.ProviderPrefix, service.ServicePackageName))
		serviceRegistrationLines = append(serviceRegistrationLines, fmt.Sprintf("%s.Registration{},", service.ServicePackageName))
	}
	sort.Strings(importLines)
	sort.Strings(serviceRegistrationLines)

	output := fmt.Sprintf(`
package provider

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"github.com/hashicorp/terraform-provider-%[1]s/internal/sdk"

	%[2]s
)

func autoRegisteredTypedServices() []sdk.TypedServiceRegistration {
	return []sdk.TypedServiceRegistration{
		%[3]s
	}
}
`, input.ProviderPrefix, strings.Join(importLines, "\n"), strings.Join(serviceRegistrationLines, "\n"))
	return strings.TrimSpace(output)
}
