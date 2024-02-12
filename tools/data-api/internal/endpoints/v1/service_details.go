// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func (api Api) serviceDetails(w http.ResponseWriter, r *http.Request) {
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

	payload := v1.ServiceDetailsResponse{
		ResourceProvider:     service.ResourceProvider,
		TerraformPackageName: service.TerraformPackageName,
		TerraformURI:         fmt.Sprintf("%s/services/%s/terraform", opts.UriPrefix, service.Name),
		Versions:             make(map[string]v1.ServiceAPIVersionSummary),
	}
	for _, version := range service.ApiVersions {
		payload.Versions[version.Name] = v1.ServiceAPIVersionSummary{
			Generate: version.Generate,
			URI:      fmt.Sprintf("%s/services/%s/%s", opts.UriPrefix, service.Name, version.Name),
		}
	}
	render.JSON(w, r, payload)
}
