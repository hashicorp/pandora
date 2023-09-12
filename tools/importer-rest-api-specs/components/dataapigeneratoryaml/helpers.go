package dataapigeneratoryaml

import (
	"fmt"
	"os"
	"path"
	"strings"

	"github.com/hashicorp/go-hclog"
)

const restApiSpecsLicence = `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`

func (s Generator) namespaceForResource(resourceName string) string {
	return fmt.Sprintf("%s.%s", s.namespaceForApiVersion, s.packageNameForResource(resourceName))
}

func (s Generator) packageNameForResource(resourceName string) string {
	return strings.Title(resourceName)
}

func (s Generator) workingDirectoryForResource(resource string) string {
	dir := s.workingDirectoryForApiVersion
	return path.Join(dir, resource)
}

func fileExistsAtPath(filePath string) (*bool, error) {
	file, err := os.Stat(filePath)
	if err != nil && !os.IsNotExist(err) {
		return nil, fmt.Errorf("checking for a file at %q: %+v", filePath, err)
	}

	result := false
	if file != nil && file.Size() > 0 {
		result = true
	}
	return &result, nil
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

func normalizeApiVersion(input string) string {
	normalized := strings.ReplaceAll(input, "-", "_")     // e.g. 2020-01-01-preview -> 2020_01_01_preview
	normalized = strings.ReplaceAll(normalized, ".", "_") // e.g. 1.0 -> 1_0
	return fmt.Sprintf("v%s", normalized)
}

func writeToFile(fileName, fileContents string) error {
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

func writeYamlToFile(fileName string, fileContents []byte) error {
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
