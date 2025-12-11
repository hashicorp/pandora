// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (api Api) commonTypesForApiVersion(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	commonTypesForThisApiVersion, ok := ctx.Value("commonTypesForApiVersion").(*sdkModels.CommonTypes)
	if !ok {
		internalServerError(w, fmt.Errorf("missing commonTypesForApiVersion"))
		return
	}

	render.JSON(w, r, commonTypesForThisApiVersion)
}
