package dataapigenerator

import (
	"fmt"
	"log"
	"os"
	"path"
	"strings"
)

const restApiSpecsLicence = `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`

func (s Service) namespaceForResource(resourceName string) string {
	return fmt.Sprintf("%s.%s", s.namespaceForApiVersion, s.packageNameForResource(resourceName))
}

func (s Service) packageNameForResource(resourceName string) string {
	return strings.Title(resourceName)
}

func (s Service) workingDirectoryForResource(resource string) string {
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

func recreateDirectoryExcludingFiles(directory string, excludeList []string, debugLog bool) error {
	if debugLog {
		log.Printf("[DEBUG] (Re)creating directory at path %q..", directory)
	}
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}

	files, err := findFilesInDirectory(directory, excludeList, debugLog)
	if err != nil {
		return fmt.Errorf("finding files in directory %q: %+v", directory, err)
	}

	for _, name := range *files {
		if debugLog {
			log.Printf("[DEBUG] Removing existing file at path %q..", name)
		}
		os.RemoveAll(name)
	}

	return nil
}

func recreateDirectory(directory string, debugLog bool) error {
	if debugLog {
		log.Printf("[DEBUG] Deleting any existing directory at %q..", directory)
	}
	if err := os.RemoveAll(directory); err != nil {
		return fmt.Errorf("removing any existing directory at %q: %+v", directory, err)
	}
	if debugLog {
		log.Printf("[DEBUG] (Re)Creating the directory at %q..", directory)
	}
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	if debugLog {
		log.Printf("[DEBUG] Created Directory at %q", directory)
	}
	return nil
}

func findFilesInDirectory(directory string, excludeList []string, debug bool) (*[]string, error) {
	dir, err := os.Open(directory)
	if err != nil {
		if os.IsNotExist(err) {
			if debug {
				log.Printf("[DEBUG] Creating Directory %q..", directory)
			}

		} else {
			return nil, fmt.Errorf("opening directory %q: %+v", directory, err)
		}
	}
	defer dir.Close()

	files := make([]string, 0)
	f, err := dir.ReadDir(0)
	if err != nil {
		return nil, fmt.Errorf("finding files in %q: %+v", directory, err)
	}
	for i := range f {
		file := f[i]
		fileName := file.Name()

		skip := false
		for _, e := range excludeList {
			if strings.EqualFold(e, fileName) {
				skip = true
				break
			}
		}
		if skip {
			continue
		}
		files = append(files, fileName)
	}

	return &files, nil
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
