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

func (api Api) operationsForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing resourceName"))
		return
	}

	operations, err := transforms.MapSDKOperations(resource.Operations)
	if err != nil {
		internalServerError(w, fmt.Errorf("mapping SDK Operations: %+v", err))
		return
	}

	payload := v1.GetSDKOperationsForAPIResource{
		Operations: *operations,
	}
	render.JSON(w, r, payload)
}
