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

func (api Api) schemaForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing resourceName"))
		return
	}

	mappedConstants, err := transforms.MapConstants(resource.Schema.Constants)
	if err != nil {
		internalServerError(w, fmt.Errorf("mapping Constants: %+v", err))
		return
	}
	mappedModels, err := transforms.MapSDKModels(resource.Schema.Models)
	if err != nil {
		internalServerError(w, fmt.Errorf("mapping Models: %+v", err))
		return
	}
	resourceIds, err := transforms.MapResourceIDs(resource.Schema.ResourceIds, *mappedConstants)
	if err != nil {
		internalServerError(w, fmt.Errorf("mapping ResourceIDs: %+v", err))
		return
	}

	payload := v1.GetSDKSchemaForAPIResource{
		Constants:   *mappedConstants,
		Models:      *mappedModels,
		ResourceIDs: *resourceIds,
	}

	render.JSON(w, r, payload)
}
