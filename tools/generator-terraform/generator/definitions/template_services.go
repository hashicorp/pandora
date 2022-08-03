package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForClientsRegistration(input models.ServicesInput) string {
	importLines := make([]string, 0)
	structFields := make([]string, 0)
	assignmentLines := make([]string, 0)

	for serviceName, service := range input.Services {
		sdkPackageName := strings.ToLower(service.SdkServiceName)
		sdkApiVersion := namespaceForApiVersion(service.ApiVersion)

		sdkImportLine := fmt.Sprintf(`%[1]s_%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"`, sdkPackageName, sdkApiVersion, service.ApiVersion)
		importLines = append(importLines, sdkImportLine)
		serviceImportLine := fmt.Sprintf(`%[1]s "github.com/hashicorp/terraform-provider-azurerm/internal/services/%[1]s/client"`, service.ServicePackageName)
		importLines = append(importLines, serviceImportLine)

		structField := fmt.Sprintf(`%[1]s   *%[2]s_%[3]s.Client`, serviceName, sdkPackageName, sdkApiVersion)
		structFields = append(structFields, structField)

		assignmentLine := fmt.Sprintf(`client.%[1]s = %[2]s.NewClient(o)`, serviceName, service.ServicePackageName)
		assignmentLines = append(assignmentLines, assignmentLine)
	}

	sort.Strings(importLines)
	sort.Strings(structFields)
	sort.Strings(assignmentLines)

	output := fmt.Sprintf(`
package clients

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"context"

	"github.com/hashicorp/terraform-provider-azurerm/internal/common"
	%[1]s
)

type autoClient struct {
	%[2]s
}

func (client *autoClient) buildAutoClients(ctx context.Context, o *common.ClientOptions) error {
	%[3]s
	return nil
}
`, strings.Join(importLines, "\n"), strings.Join(structFields, "\n"), strings.Join(assignmentLines, "\n"))
	return strings.TrimSpace(output)
}
