package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func commonTypes(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}
	payload := models.CommonTypesDetails{
		Constants: map[string]models.ConstantDetails{},
		Models:    map[string]models.ModelDetails{},
	}
	if !opts.UsesCommonTypes {
		render.JSON(w, r, payload)
		return
	}

	// TODO: go through and map these across

	render.JSON(w, r, payload)
}
