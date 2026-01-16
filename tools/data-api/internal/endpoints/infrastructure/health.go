// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package infrastructure

import "net/http"

func health(w http.ResponseWriter, _ *http.Request) {
	w.WriteHeader(http.StatusOK)
}
