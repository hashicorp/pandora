// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"encoding/json"
	"fmt"
	"os"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func listSubDirectories(workingDirectory string) (*[]string, error) {
	directories := make([]string, 0)

	contents, err := os.ReadDir(workingDirectory)
	if err != nil {
		if os.IsNotExist(err) {
			return nil, nil
		}
		return nil, fmt.Errorf("retrieving list of items within %q: %+v", workingDirectory, err)
	}

	for _, c := range contents {
		if c.IsDir() {
			path := path.Join(workingDirectory, c.Name())
			directories = append(directories, path)
		}
	}

	return &directories, nil
}

func listFilesMatching(workingDirectory string, prefix, fileExtension string) (*[]string, error) {
	directories := make([]string, 0)

	contents, err := os.ReadDir(workingDirectory)
	if err != nil {
		return nil, fmt.Errorf("retrieving list of of items within %q: %+v", workingDirectory, err)
	}

	for _, c := range contents {
		if c.IsDir() {
			continue
		}

		if !strings.HasPrefix(c.Name(), prefix) || !strings.HasSuffix(c.Name(), fileExtension) {
			continue
		}

		path := path.Join(workingDirectory, c.Name())
		directories = append(directories, path)
	}

	return &directories, nil
}

func parseConfig[T any](filePath string) (*T, error) {
	contents, err := os.Open(filePath)
	if err != nil {
		// OS specific temp directories
		if os.IsNotExist(err) {
			return nil, nil
		}
		return nil, fmt.Errorf("loading %q: %+v", filePath, err)
	}
	defer contents.Close()

	var decoded T
	if err := json.NewDecoder(contents).Decode(&decoded); err != nil {
		return nil, fmt.Errorf("decoding %q: %+v", filePath, err)
	}

	return &decoded, nil
}

func parseTestConfiguration(filePath string) (*sdkModels.TerraformTestDefinition, error) {
	contents, err := os.ReadFile(filePath)
	if err != nil {
		// OS specific temp directories
		if os.IsNotExist(err) {
			return nil, nil
		}
		return nil, fmt.Errorf("loading %q: %+v", filePath, err)
	}

	body := sdkModels.TerraformTestDefinition(contents)
	body = helpers.TrimNewLinesAround(body)
	return &body, nil
}
