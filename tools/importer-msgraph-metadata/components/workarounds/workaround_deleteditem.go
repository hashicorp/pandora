// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ serviceWorkaround = workaroundDeletedItem{}

// workaroundDeletedItem fixes the object type used by the deleted items list operations. The specs describe
// these as `/directory/deletedItems/{type}`, e.g. `/directory/deletedItems/group`, however the API returns a 400 for these
// and seems to expect the `microsoft.graph.` prefix, e.g. `/directory/deletedItems/microsoft.graph.group`.
type workaroundDeletedItem struct{}

func (workaroundDeletedItem) Name() string {
	return "DeletedItem / fix incorrect object type for list operations"
}

func (workaroundDeletedItem) Process(_, serviceName string, resources parser.Resources, _ parser.ResourceIds) error {
	if serviceName != "directory" {
		return nil
	}

	resourcesToFix := []string{
		"DirectoryDeletedItemApplication",
		"DirectoryDeletedItemGroup",
		"DirectoryDeletedItemServicePrincipal",
		"DirectoryDeletedItemUser",
	}

	operationsToFix := map[string]string{
		"ListDeletedItemApplications":      "/directory/deletedItems/microsoft.graph.application",
		"ListDeletedItemGroups":            "/directory/deletedItems/microsoft.graph.group",
		"ListDeletedItemServicePrincipals": "/directory/deletedItems/microsoft.graph.servicePrincipal",
		"ListDeletedItemUsers":             "/directory/deletedItems/microsoft.graph.user",
	}

	for _, r := range resourcesToFix {
		resource, ok := resources[r]
		if !ok {
			return fmt.Errorf("expected a `%s` resource but didn't get one", r)
		}

		for i, operation := range resource.Operations {
			if newPath, ok := operationsToFix[operation.Name]; ok {
				operation.UriSuffix = &newPath
				resource.Operations[i] = operation
			}
		}
	}

	return nil
}
