// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import "github.com/hashicorp/go-hclog"

type generatorStage interface {
	// generate runs this generation stage which returns a map of files to be output or an error
	generate(input *fileSystem, logger hclog.Logger) error

	// name returns the name of this generator stage, for logging purposes.
	name() string
}
