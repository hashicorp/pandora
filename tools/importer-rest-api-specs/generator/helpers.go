package generator

import (
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"strings"
)

const restApiSpecsLicence = `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`

func (g PandoraDefinitionGenerator) RecreateDirectory(directory string, permissions os.FileMode) error {
	if g.debugLog {
		log.Printf("[DEBUG] Deleting any existing directory at %q..", directory)
	}
	os.RemoveAll(directory)
	if g.debugLog {
		log.Printf("[DEBUG] (Re)Creating the directory at %q..", directory)
	}
	if err := os.MkdirAll(directory, permissions); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	if g.debugLog {
		log.Printf("[DEBUG] Created Directory at %q", directory)
	}
	return nil
}

func normalizeApiVersion(input string) string {
	normalized := strings.ReplaceAll(input, "-", "_")     // e.g. 2020-01-01-preview -> 2020_01_01_preview
	normalized = strings.ReplaceAll(normalized, ".", "_") // e.g. 1.0 -> 1_0
	return fmt.Sprintf("v%s", normalized)
}

func readFromFile(path string) (*[]byte, error) {
	contents, err := ioutil.ReadFile(path)
	if err != nil {
		if os.IsNotExist(err) {
			return nil, nil
		}

		return nil, fmt.Errorf("opening file %q: %+v", path, err)
	}

	return &contents, nil
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
