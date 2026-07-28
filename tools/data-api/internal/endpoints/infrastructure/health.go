// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package infrastructure

import "net/http"

func health(w http.ResponseWriter, _ *http.Request) {
	w.WriteHeader(http.StatusOK)
}
