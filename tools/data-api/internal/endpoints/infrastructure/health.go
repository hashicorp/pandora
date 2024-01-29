// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package infrastructure

import "net/http"

func health(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusOK)
}
