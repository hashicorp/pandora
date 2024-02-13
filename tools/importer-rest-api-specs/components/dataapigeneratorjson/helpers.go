// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"os"
	"path"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func (s Generator) workingDirectoryForResource(resource string) string {
	dir := s.workingDirectoryForApiVersion
	return path.Join(dir, resource)
}

func RecreateDirectory(directory string, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Deleting any existing directory at %q..", directory))
	if err := os.RemoveAll(directory); err != nil {
		return fmt.Errorf("removing any existing directory at %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("(Re)Creating the directory at %q..", directory))
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("Created Directory at %q", directory))
	return nil
}

func ensureDirectoryExists(directory string, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Ensuring the directory exists at %q..", directory))
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		if os.IsExist(err) {
			logger.Trace(fmt.Sprintf("Directory already exists at %q", directory))
			return nil
		}
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("Created Directory at %q", directory))
	return nil
}

func writeJsonToFile(fileName string, fileContents []byte) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.Write(fileContents)
	file.Close()
	return nil
}

func writeTestsHclToFile(directory, resourceName string, tests dataapimodels.TerraformResourceTestConfig) error {
	if !tests.Generate {
		return nil
	}
	if tests.TemplateConfig != nil {
		templateTestFileName := path.Join(directory, fmt.Sprintf("%s-Resource-Template-Test.hcl", resourceName))
		if err := writeStringToFile(templateTestFileName, *tests.TemplateConfig); err != nil {
			return fmt.Errorf("writing Template Test Config: %+v", err)
		}
	}

	basicTestFileName := path.Join(directory, fmt.Sprintf("%s-Resource-Basic-Test.hcl", resourceName))
	if err := writeStringToFile(basicTestFileName, tests.BasicConfig); err != nil {
		return fmt.Errorf("writing Basic Test Config: %+v", err)
	}

	requiresImportTestFileName := path.Join(directory, fmt.Sprintf("%s-Resource-Requires-Import-Test.hcl", resourceName))
	if err := writeStringToFile(requiresImportTestFileName, tests.RequiresImport); err != nil {
		return fmt.Errorf("writing Requires Import Test Config: %+v", err)
	}

	if tests.CompleteConfig != nil {
		completeTestFileName := path.Join(directory, fmt.Sprintf("%s-Resource-Complete-Test.hcl", resourceName))
		if err := writeStringToFile(completeTestFileName, *tests.CompleteConfig); err != nil {
			return fmt.Errorf("writing Complete Test Config: %+v", err)
		}
	}

	if tests.OtherTests != nil {
		for otherTestName, v := range tests.OtherTests {
			for i, test := range v {
				otherTestFileName := path.Join(directory, fmt.Sprintf("%s-Resource-Other-%s-%d-Test.hcl", resourceName, otherTestName, i))
				if err := writeStringToFile(otherTestFileName, test); err != nil {
					return fmt.Errorf("writing %s Test Config: %+v", otherTestName, err)
				}
			}
		}
	}

	return nil
}

func writeStringToFile(fileName string, fileContents string) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.WriteString(fileContents)
	file.Close()
	return nil
}
