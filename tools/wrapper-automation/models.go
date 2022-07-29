package main

import (
	"fmt"
	"os"
)

type Arguments struct {
	DataApiAssemblyPath     string
	DataApiPort             int
	OutputDirectory         string
	RunGoSdkGenerator       bool
	RunTerraformGenerator   bool
	RunRestApiSpecsImporter bool
}

func (a Arguments) Validate() error {
	if a.DataApiAssemblyPath == "" {
		return fmt.Errorf("missing 'data-api-assembly-path'")
	}

	if _, err := os.Stat(a.DataApiAssemblyPath); err != nil {
		if os.IsNotExist(err) {
			return fmt.Errorf("the Data API Assembly doesn't exist at %q", a.DataApiAssemblyPath)
		}

		return fmt.Errorf("validating Data API Assembly exists: %+v", err)
	}

	return nil
}
