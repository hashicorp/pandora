// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"fmt"
	"os"
	"path/filepath"
)

type Arguments struct {
	ApiDefinitionsDirectory string
	DataApiAssemblyPath     string
	DataApiPort             int
	OutputDirectory         string
	RunGoSdkGenerator       bool
	RunTerraformGenerator   bool
	RunRestApiSpecsImporter bool
}

func (a Arguments) Validate() error {
	if a.ApiDefinitionsDirectory == "" {
		return fmt.Errorf("'api-definitions-dir' must be specified")
	}

	abs, err := filepath.Abs(a.ApiDefinitionsDirectory)
	if err != nil {
		return fmt.Errorf("determining absolute path to %q: %+v", a.ApiDefinitionsDirectory, err)
	}
	a.ApiDefinitionsDirectory = abs
	if _, err := os.Stat(a.ApiDefinitionsDirectory); err != nil {
		if os.IsNotExist(err) {
			return fmt.Errorf("the API Definitions Directory doesn't exist at %q", a.ApiDefinitionsDirectory)
		}

		return fmt.Errorf("validating API Definitions Directory exists at %q: %+v", a.ApiDefinitionsDirectory, err)
	}

	return nil
}
