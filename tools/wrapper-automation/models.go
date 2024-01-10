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
	if a.ApiDefinitionsDirectory != "" {
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
	}

	if a.DataApiAssemblyPath != "" {
		if _, err := os.Stat(a.DataApiAssemblyPath); err != nil {
			if os.IsNotExist(err) {
				return fmt.Errorf("the Data API Assembly doesn't exist at %q", a.DataApiAssemblyPath)
			}

			return fmt.Errorf("validating Data API Assembly exists: %+v", err)
		}
	}

	if a.ApiDefinitionsDirectory == "" && a.DataApiAssemblyPath == "" {
		return fmt.Errorf("one of either 'api-definitions-directory' or 'data-api-assembly-path' must be specified")
	}

	return nil
}
