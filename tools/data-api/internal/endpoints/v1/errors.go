// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"log"
	"net/http"
)

func internalServerError(w http.ResponseWriter, err error) {
	log.Printf("[ERROR] %+v", err)
	http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
}
