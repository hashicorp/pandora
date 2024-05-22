// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import "github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"

type Stage interface {
	// Generate runs this generation Stage which returns a map of files to be output or an error
	Generate(input *helpers.FileSystem) error

	// Name returns the name of this generator Stage, for logging purposes.
	Name() string
}
