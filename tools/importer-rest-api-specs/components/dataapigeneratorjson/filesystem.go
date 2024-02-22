// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var directoryPermissions = os.FileMode(0755)

// filePath is a typealias to make it clearer what's being returned from this generationStage.
// This represents the path to a file on disk
type filePath = string

// fileBody is a typealias to make it clearer what's being returned from this generationStage.
type fileBody = []byte

// fileSystem is an abstraction around a set of files within a working directory.
// It's intended to allow a representation around the API Definitions working directory
// containing a reference to both the files that _would_ be written (during saving/testing)
// and that exist (when loading the API Definitions from disk).
type fileSystem struct {
	f map[filePath]fileBody
}

func newFileSystem() *fileSystem {
	return &fileSystem{
		f: map[filePath]fileBody{},
	}
}

// stage stages the specified body at the specified path, ensuring that it's unique.
// This doesn't persist the file to disk, which is handled in persistFileSystem.
func (f *fileSystem) stage(path filePath, body any) error {
	if _, existing := f.f[path]; existing {
		return fmt.Errorf("a duplicate file exists at the path %q", path)
	}

	fileExtension := strings.ToLower(filepath.Ext(path))
	if fileExtension == ".hcl" {
		str, ok := body.(string)
		if !ok {
			return fmt.Errorf("`body` must be a string for an `*.hcl` file but got %T", body)
		}

		f.f[path] = []byte(str)
		return nil
	}

	if fileExtension == ".json" {
		bytes, err := json.MarshalIndent(body, "", "  ")
		if err != nil {
			return fmt.Errorf("marshalling file body for %q as json: %+v", path, err)
		}

		f.f[path] = bytes
		return nil
	}

	return fmt.Errorf("internal-error: unexpected file extension %q for %q", fileExtension, path)
}

func persistFileSystem(workingDirectory string, dataType models.SourceDataType, serviceName string, input *fileSystem, logger hclog.Logger) error {
	rootDir := filepath.Join(workingDirectory, string(dataType))
	logger.Trace(fmt.Sprintf("Persisting files into %q", rootDir))

	// Delete any existing directory with this service name
	serviceDir := filepath.Join(rootDir, serviceName)
	logger.Debug(fmt.Sprintf("Removing any existing Directory for Service %q", serviceName))
	_ = os.RemoveAll(serviceDir)
	if err := os.MkdirAll(serviceDir, directoryPermissions); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", serviceDir, err)
	}

	// pull out a list of directories
	directories := uniqueDirectories(input.f)
	logger.Debug(fmt.Sprintf("Creating directories for Service %q", serviceName))
	for _, dir := range directories {
		dirPath := filepath.Join(rootDir, dir)
		if err := os.MkdirAll(dirPath, directoryPermissions); err != nil {
			return fmt.Errorf("creating directory %q: %+v", dirPath, err)
		}
	}

	// write the files
	for path, body := range input.f {
		fileFullPath := filepath.Join(rootDir, path)
		logger.Trace(fmt.Sprintf("Writing file %q", fileFullPath))
		file, err := os.Create(fileFullPath)
		if err != nil {
			return fmt.Errorf("opening %q: %+v", fileFullPath, err)
		}

		_, _ = file.Write(body)
		_ = file.Close()
	}

	return nil
}

func uniqueDirectories(input map[filePath]fileBody) []string {
	directories := make(map[string]struct{})
	for path := range input {
		dir := filepath.Dir(path)
		directories[dir] = struct{}{}
	}

	out := make([]string, 0)
	for k := range directories {
		out = append(out, k)
	}
	sort.Strings(out)

	return out
}
