// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package infrastructure

import (
	"github.com/go-chi/chi/v5"
)

func Router(router chi.Router) {
	router.Get("/health", health)
}
