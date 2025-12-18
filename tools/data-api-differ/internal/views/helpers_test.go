// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

func init() {
	log.Logger = hclog.Default()
}
