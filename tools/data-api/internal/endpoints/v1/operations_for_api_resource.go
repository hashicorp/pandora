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

func (api Api) operationsForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*sdkModels.APIResource)
	if !ok {
		internalServerError(w, fmt.Errorf("missing resourceName"))
		return
	}

	payload := v1.GetSDKOperationsForAPIResource{
		Operations: resource.Operations,
	}
	render.JSON(w, r, payload)
}
