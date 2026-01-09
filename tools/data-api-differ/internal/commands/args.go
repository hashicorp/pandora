// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"flag"
	"fmt"
	"os"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

type arguments struct {
	// binaryName specifies the name of the binary
	binaryName string

	// dataApiBinaryPath specifies the path to the Data API (v2) binary.
	dataApiBinaryPath string

	// initialApiDefinitionsPath specifies the path to the initial set of API Definitions which should be compared against those within updatedPath.
	initialApiDefinitionsPath string

	// outputFilePath specifies the path to the output file where the Result should be rendered.
	outputFilePath *string

	// updatedApiDefinitionsPath specifies the path to the updated set of API Definitions which should be compared against those within initialPath.
	updatedApiDefinitionsPath string
}

func (a *arguments) parse(input []string) error {
	f := flag.NewFlagSet(a.binaryName, flag.ExitOnError)

	// this default allows for the binary to be on the path, helpful for automation purposes where the GOBIN is on the PATH
	f.StringVar(&a.dataApiBinaryPath, "data-api-binary-path", "", "--data-api-binary-path=/path/to/the/data-api-binary")
	f.StringVar(&a.initialApiDefinitionsPath, "initial-path", "", "--initial-path=/path/to/the/initial-api-definitions")
	f.StringVar(&a.updatedApiDefinitionsPath, "updated-path", "", "--updated-path=/path/to/the/updated-api-definitions")
	var outputFilePath string
	f.StringVar(&outputFilePath, "output-file-path", "", "--output-file=/path/to/the/output/file")
	if err := f.Parse(input); err != nil {
		return err
	}

	if outputFilePath != "" {
		a.outputFilePath = &outputFilePath
	}

	var err error
	if a.dataApiBinaryPath != "" {
		log.Logger.Debug(fmt.Sprintf("Determining the absolute path to %q", a.dataApiBinaryPath))
		a.dataApiBinaryPath, err = filepath.Abs(a.dataApiBinaryPath)
		if err != nil {
			return fmt.Errorf("determining absolute path to %q: %+v", a.dataApiBinaryPath, err)
		}
	} else {
		log.Logger.Debug("A path to the Data API Binary was not specified - assuming this is installed onto the PATH")
		a.dataApiBinaryPath = "data-api"
	}

	if a.initialApiDefinitionsPath == "" {
		return fmt.Errorf("`--initial-path` was not specified")
	}
	log.Logger.Debug(fmt.Sprintf("Determining the absolute path to %q", a.initialApiDefinitionsPath))
	a.initialApiDefinitionsPath, err = filepath.Abs(a.initialApiDefinitionsPath)
	if err != nil {
		return fmt.Errorf("determining the absolute path to %q: %+v", a.initialApiDefinitionsPath, err)
	}

	if a.updatedApiDefinitionsPath == "" {
		return fmt.Errorf("`--updated-path` was not specified")
	}
	log.Logger.Debug(fmt.Sprintf("Determining the absolute path to %q", a.updatedApiDefinitionsPath))
	a.updatedApiDefinitionsPath, err = filepath.Abs(a.updatedApiDefinitionsPath)
	if err != nil {
		return fmt.Errorf("determining the absolute path to %q: %+v", a.updatedApiDefinitionsPath, err)
	}

	if a.outputFilePath != nil {
		log.Logger.Debug(fmt.Sprintf("Determining the absolute path to %q", *a.outputFilePath))
		path, err := filepath.Abs(*a.outputFilePath)
		if err != nil {
			return fmt.Errorf("determining the absolute path to %q: %+v", *a.outputFilePath, err)
		}
		a.outputFilePath = &path
	}

	return nil
}

// validate asserts that the arguments are valid
func (a *arguments) validate() error {
	log.Logger.Trace("Validating the Initial API Definitions Path exists..")
	if _, err := os.Stat(a.initialApiDefinitionsPath); err != nil {
		if os.IsNotExist(err) {
			return fmt.Errorf("validating `initial-path`: %q does not exist", a.initialApiDefinitionsPath)
		}

		return fmt.Errorf("validating `initial-path`: %+v", err)
	}

	log.Logger.Trace("Validating the Updated API Definitions Path exists..")
	if _, err := os.Stat(a.updatedApiDefinitionsPath); err != nil {
		if os.IsNotExist(err) {
			return fmt.Errorf("validating `updated-path`: %q does not exist", a.updatedApiDefinitionsPath)
		}

		return fmt.Errorf("validating `updated-path`: %+v", err)
	}

	return nil
}
