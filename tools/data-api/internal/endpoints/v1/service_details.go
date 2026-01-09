// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (api Api) serviceDetails(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	service, ok := ctx.Value("service").(*sdkModels.Service)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}

	payload := v1.ServiceDetailsResponse{
		ResourceProvider: service.ResourceProvider,
		TerraformURI:     fmt.Sprintf("%s/services/%s/terraform", opts.UriPrefix, service.Name),
		Versions:         make(map[string]v1.ServiceAPIVersionSummary),
	}
	if service.TerraformDefinition != nil {
		payload.TerraformPackageName = pointer.To(service.TerraformDefinition.TerraformPackageName)
	}
	for apiVersion, version := range service.APIVersions {
		payload.Versions[apiVersion] = v1.ServiceAPIVersionSummary{
			Generate: version.Generate,
			URI:      fmt.Sprintf("%s/services/%s/%s", opts.UriPrefix, service.Name, apiVersion),
		}
	}
	render.JSON(w, r, payload)
}
