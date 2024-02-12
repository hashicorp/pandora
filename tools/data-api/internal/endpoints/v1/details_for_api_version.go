// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1/transforms"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func (api Api) detailsForApiVersion(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}
	apiVersion, ok := ctx.Value("serviceApiVersion").(*repositories.ServiceApiVersionDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing serviceApiVersion"))
		return
	}

	resources := make(map[string]v1.APIResourceSummary, 0)
	for k := range apiVersion.Resources {
		resources[k] = v1.APIResourceSummary{
			OperationsURI: fmt.Sprintf("%s/services/%s/%s/%s/operations", opts.UriPrefix, service.Name, apiVersion.Name, k),
			SchemaURI:     fmt.Sprintf("%s/services/%s/%s/%s/schema", opts.UriPrefix, service.Name, apiVersion.Name, k),
		}
	}
	source, err := transforms.MapSourceDataOrigin(apiVersion.Source)
	if err != nil {
		internalServerError(w, fmt.Errorf("mapping SourceDataOrigin: %+v", err))
	}

	payload := v1.DetailsForAPIVersionSummary{
		Resources: resources,
		Source:    *source,
	}
	render.JSON(w, r, payload)
}
