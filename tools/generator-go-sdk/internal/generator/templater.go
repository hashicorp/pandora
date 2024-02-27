// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
)

type templaterForResource interface {
	template(data ServiceGeneratorData) (*string, error)
}

type templaterForVersion interface {
	template() (*string, error)
}

func (s *ServiceGenerator) writeToPathForResource(directory, filePath string, templater templaterForResource, data ServiceGeneratorData, logger hclog.Logger) error {
	fileContents, err := templater.template(data)
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)
	file, err := os.Create(fullFilePath)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	logger.Trace(fmt.Sprintf("writing to %q", fullFilePath))
	_, _ = file.WriteString(*fileContents)
	return nil
}

func (s *ServiceGenerator) writeToPathForVersion(directory, filePath string, templater templaterForVersion, logger hclog.Logger) error {
	fileContents, err := templater.template()
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)
	file, err := os.Create(fullFilePath)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	logger.Trace(fmt.Sprintf("writing to %q", fullFilePath))
	_, _ = file.WriteString(*fileContents)
	return nil
}
