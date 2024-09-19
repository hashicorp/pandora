// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"net/http"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ serviceWorkaround = workaroundSynchronizationSecrets{}

// workaroundSynchronizationSecrets adds a missing GET method for synchronization secrets, which is absent from upstream specs.
type workaroundSynchronizationSecrets struct{}

func (workaroundSynchronizationSecrets) Name() string {
	return "Synchronization Secrets / add missing get method"
}

func (workaroundSynchronizationSecrets) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	serviceNamesToPaths := map[string]string{
		"applications":      "/applications/{application-id}/synchronization/secrets",
		"servicePrincipals": "/servicePrincipals/{servicePrincipal-id}/synchronization/secrets",
	}

	for serviceNameToMatch, path := range serviceNamesToPaths {
		if serviceNameToMatch != serviceName {
			continue
		}

		resourceName := fmt.Sprintf("%sSynchronizationSecret", normalize.Singularize(normalize.CleanName(serviceName)))
		resource, ok := resources[resourceName]
		if !ok {
			return fmt.Errorf("%q was not found for the service %q", resourceName, serviceName)
		}

		tags := []string{serviceName + ".synchronization"}

		var resourceId *parser.ResourceId
		var uriSuffix *string

		parsedPath := parser.NewResourceId(path, tags)
		match, ok := resourceIds.MatchIdOrAncestor(parsedPath)
		if ok {
			if match.Id != nil {
				resourceId = match.Id
			}
			if match.Remainder != nil && len(match.Remainder.Segments) > 0 {
				uriSuffix = pointer.To(match.Remainder.ID())
			}
		} else {
			uriSuffix = pointer.To(parsedPath.ID())
		}

		resource.Operations = append(resource.Operations, parser.Operation{
			Name:            "ListSynchronizationSecrets",
			Description:     "Retrieve synchronization secrets.",
			Type:            parser.OperationTypeList,
			Method:          http.MethodGet,
			PaginationField: pointer.To("@odata.nextLink"),
			ResourceId:      resourceId,
			UriSuffix:       uriSuffix,
			Responses: []parser.Response{
				{
					Status:        http.StatusOK,
					ContentType:   pointer.To("application/json"),
					ReferenceName: pointer.To("microsoft.graph.synchronizationSecretKeyStringValuePair"),
					Type:          pointer.To(parser.DataTypeReference),
				},
			},
			Tags: tags,
		})
	}

	return nil
}
