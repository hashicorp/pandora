// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"slices"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ serviceWorkaround = workaroundApplicationTemplates{}

// workaroundApplicationTemplates adds a missing GET method for synchronization secrets, which is absent from upstream specs.
type workaroundApplicationTemplates struct{}

func (workaroundApplicationTemplates) Name() string {
	return "ApplicationTemplates / set correct response status codes"
}

func (workaroundApplicationTemplates) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	if serviceName != "applicationTemplates" {
		return nil
	}

	resource, ok := resources["InstantiateApplicationTemplate"]
	if !ok {
		return fmt.Errorf("`InstantiateApplicationTemplate` resource was not found for the `applicationTemplates` service")
	}

	for i := range resource.Operations {
		if resource.Operations[i].Name == "Instantiate" {
			statusesFromSpec := make([]int, 0, len(resource.Operations[i].Responses))
			for j := range resource.Operations[i].Responses {
				statusesFromSpec = append(statusesFromSpec, resource.Operations[i].Responses[j].Status)
			}

			if !slices.Contains(statusesFromSpec, 201) {
				resource.Operations[i].Responses = append(resource.Operations[i].Responses, parser.Response{
					Status:      201,
					ContentType: pointer.To("application/json"),
				})
			}
			break
		}
	}

	return nil
}
