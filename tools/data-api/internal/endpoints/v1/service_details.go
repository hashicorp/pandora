// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
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

	payload := models.ServiceDetails{
		ResourceProvider:     service.ResourceProvider,
		TerraformPackageName: service.TerraformPackageName,
		TerraformUri:         fmt.Sprintf("%s/services/%s/terraform", opts.UriPrefix, service.Name),
		Versions:             make(map[string]models.ServiceVersion, 0),
	}
	for _, version := range service.ApiVersions {
		payload.Versions[version.Name] = models.ServiceVersion{
			Generate: version.Generate,
			Uri:      fmt.Sprintf("%s/services/%s/%s", opts.UriPrefix, service.Name, version.Name),
		}
	}
	render.JSON(w, r, payload)
}
