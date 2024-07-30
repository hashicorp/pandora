// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
)

type templaterForResource interface {
	template(GeneratorData) (*string, error)
}

type templaterForVersion interface {
	template() (*string, error)
}

func (s *ServiceGenerator) writeToPathForResource(directory, filePath string, templater templaterForResource, data GeneratorData) error {
	fileContents, err := templater.template(data)
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)

	// call os.OpenFile instead of os.Create to reduce spurious "file not found" errors when O_TRUNC is used
	file, err := os.OpenFile(fullFilePath, os.O_WRONLY|os.O_CREATE, 0666)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	logging.Tracef(fmt.Sprintf("writing to %q", fullFilePath))
	_, _ = file.WriteString(*fileContents)
	return nil
}

func (s *ServiceGenerator) writeToPathForVersion(directory, filePath string, templater templaterForVersion) error {
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

	logging.Tracef(fmt.Sprintf("writing to %q", fullFilePath))
	_, _ = file.WriteString(*fileContents)
	return nil
}
