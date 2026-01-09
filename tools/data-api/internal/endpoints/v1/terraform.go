// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (api Api) terraform(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	service, ok := ctx.Value("service").(*models.Service)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}

	// allows us to make assumptions
	if service.TerraformDefinition == nil || len(service.TerraformDefinition.Resources) == 0 {
		w.WriteHeader(http.StatusNoContent)
		return
	}

	render.JSON(w, r, *service.TerraformDefinition)
}
