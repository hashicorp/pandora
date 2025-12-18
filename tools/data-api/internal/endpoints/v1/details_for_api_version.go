// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (api Api) detailsForApiVersion(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	service, ok := ctx.Value("service").(*sdkModels.Service)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}
	apiVersion, ok := ctx.Value("serviceApiVersion").(*sdkModels.APIVersion)
	if !ok {
		internalServerError(w, fmt.Errorf("missing serviceApiVersion"))
		return
	}

	resources := make(map[string]v1.APIResourceSummary)
	for k := range apiVersion.Resources {
		resources[k] = v1.APIResourceSummary{
			OperationsURI: fmt.Sprintf("%s/services/%s/%s/%s/operations", opts.UriPrefix, service.Name, apiVersion.APIVersion, k),
			SchemaURI:     fmt.Sprintf("%s/services/%s/%s/%s/schema", opts.UriPrefix, service.Name, apiVersion.APIVersion, k),
		}
	}

	payload := v1.DetailsForAPIVersionSummary{
		Resources: resources,
		Source:    apiVersion.Source,
	}
	render.JSON(w, r, payload)
}
