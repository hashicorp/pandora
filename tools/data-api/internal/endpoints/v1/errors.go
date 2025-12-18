// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"net/http"

	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
)

func internalServerError(w http.ResponseWriter, err error) {
	// TODO: update errors
	logging.Errorf("%+v", err)
	http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
}
