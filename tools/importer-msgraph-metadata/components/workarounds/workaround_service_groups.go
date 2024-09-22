// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"slices"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ serviceWorkaround = workaroundGroups{}

// workaroundGroups adds a missing GET method for synchronization secrets, which is absent from upstream specs.
type workaroundGroups struct{}

func (workaroundGroups) Name() string {
	return "Groups / set correct response status codes"
}

func (workaroundGroups) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	if serviceName != "groups" {
		return nil
	}

	resource, ok := resources["Group"]
	if !ok {
		return fmt.Errorf("`Group` resource was not found for the `groups` service")
	}

	for i := range resource.Operations {
		if resource.Operations[i].Name == "UpdateGroup" {
			statusesFromSpec := make([]int, 0, len(resource.Operations[i].Responses))
			for j := range resource.Operations[i].Responses {
				statusesFromSpec = append(statusesFromSpec, resource.Operations[i].Responses[j].Status)
			}

			if !slices.Contains(statusesFromSpec, 200) {
				resource.Operations[i].Responses = append(resource.Operations[i].Responses, parser.Response{
					Status:      200,
					ContentType: pointer.To("application/json"),
				})
			}
			break
		}
	}

	return nil
}
