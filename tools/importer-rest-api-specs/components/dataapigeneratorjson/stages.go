// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"

type generatorStage interface {
	// generate runs this generation Stage which returns a map of files to be output or an error
	generate(input *helpers.FileSystem) error

	// name returns the name of this generator Stage, for logging purposes.
	name() string
}
