// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

func (api Api) commonTypes(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	availableCommonTypes, err := api.servicesRepository.GetCommonTypes()
	if err != nil {
		internalServerError(w, fmt.Errorf("loading common types: %+v", err))
		return
	}

	payload := v1.GetCommonTypesSummary{
		CommonTypes: map[string]v1.GetCommonTypesMetaData{},
	}
	for apiVersion := range *availableCommonTypes {
		payload.CommonTypes[apiVersion] = v1.GetCommonTypesMetaData{
			CommonTypesURI: fmt.Sprintf("%s/common-types/%s", opts.UriPrefix, apiVersion),
		}
	}

	render.JSON(w, r, payload)
}
