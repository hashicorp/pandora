// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package datasource

import (
	"log"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func DataSource(input models.DataSourceInput) error {
	// TODO: conditionally output both a Singular and Plural Data Source?
	log.Printf("TODO: Data Source stuff")
	return nil
}
