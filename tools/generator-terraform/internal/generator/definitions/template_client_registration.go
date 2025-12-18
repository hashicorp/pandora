// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForClientsRegistration(input models.ServicesInput) string {
	importLines := make([]string, 0)
	structFields := make([]string, 0)
	assignmentLines := make([]string, 0)

	for serviceName, service := range input.Services {
		serviceImportLine := fmt.Sprintf(`%[2]s "github.com/hashicorp/terraform-provider-%[1]s/internal/services/%[2]s/client"`, input.ProviderPrefix, service.ServicePackageName)
		importLines = append(importLines, serviceImportLine)

		structField := fmt.Sprintf(`%[1]s   *%[2]s.AutoClient`, serviceName, service.ServicePackageName)
		structFields = append(structFields, structField)

		assignmentLine := fmt.Sprintf(`
		if client.%[1]s, err = %[2]s.NewClient(o); err != nil {
			return fmt.Errorf("building client for %[1]s: %%+v", err)
		}
`, serviceName, service.ServicePackageName)
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

	"github.com/hashicorp/terraform-provider-%[1]s/internal/common"
	%[2]s
)

type autoClient struct {
	%[3]s
}

func buildAutoClients(client *autoClient, o *common.ClientOptions) (err error) {
	%[4]s
	return nil
}
`, input.ProviderPrefix, strings.Join(importLines, "\n"), strings.Join(structFields, "\n"), strings.Join(assignmentLines, "\n"))
	return strings.TrimSpace(output)
}
