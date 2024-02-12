// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1/transforms"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func (api Api) terraform(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}

	// allows us to make assumptions
	if len(service.TerraformDetails.Resources) == 0 {
		w.WriteHeader(http.StatusNoContent)
		return
	}

	resources, err := transforms.MapTerraformResourceDefinitions(service.TerraformDetails.Resources)
	if err != nil {
		internalServerError(w, err)
		return
	}

	payload := models.TerraformDefinition{
		Resources:            *resources,
		TerraformPackageName: *service.TerraformPackageName,
	}
	render.JSON(w, r, payload)
}
