// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
)

type Stage interface {
	// Generate runs this generation Stage which returns a map of files to be output or an error
	Generate(input *helpers.FileSystem, logger hclog.Logger) error

	// Name returns the name of this generator Stage, for logging purposes.
	Name() string
}
