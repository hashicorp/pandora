// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"encoding/json"
	"fmt"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
)

var DirectoryPermissions = os.FileMode(0755)

// FilePath is a typealias to make it clearer what's being returned from this generationStage.
// This represents the path to a file on disk
type FilePath = string

// FileBody is a typealias to make it clearer what's being returned from this generationStage.
type FileBody = []byte

// FileSystem is an abstraction around a set of files within a working directory.
// It's intended to allow a representation around the API Definitions working directory
// containing a reference to both the files that _would_ be written (during saving/testing)
// and that exist (when loading the API Definitions from disk).
type FileSystem struct {
	f map[FilePath]*FileBody
}

func NewFileSystem() *FileSystem {
	return &FileSystem{
		f: map[FilePath]*FileBody{},
	}
}

// Stage stages the specified body at the specified path, ensuring that it's unique.
// This doesn't persist the file to disk, which is handled in PersistFileSystem.
func (f *FileSystem) Stage(path FilePath, body any) error {
	if existingContents, existing := f.f[path]; existing {
		// The APIVersionDefinition is staged once per API Version currently
		if existingContents == body {
			return nil
		}
		return fmt.Errorf("a duplicate file exists at the path %q", path)
	}

	fileExtension := strings.ToLower(filepath.Ext(path))
	if fileExtension == ".hcl" {
		str, ok := body.(string)
		if !ok {
			return fmt.Errorf("`body` must be a string for an `*.hcl` file but got %T", body)
		}

		f.f[path] = pointer.To([]byte(str))
		return nil
	}

	if fileExtension == ".json" {
		bytes, err := json.MarshalIndent(body, "", "  ")
		if err != nil {
			return fmt.Errorf("marshalling file body for %q as json: %+v", path, err)
		}

		f.f[path] = pointer.To(bytes)
		return nil
	}

	return fmt.Errorf("internal-error: unexpected file extension %q for %q", fileExtension, path)
}

func PersistFileSystem(workingDirectory string, input *FileSystem, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Persisting files into %q", workingDirectory))

	// ensure it exists
	_ = os.MkdirAll(workingDirectory, DirectoryPermissions)

	// pull out a list of directories
	directories := uniqueDirectories(input.f)
	for _, dir := range directories {
		dirPath := filepath.Join(workingDirectory, dir)
		if err := os.MkdirAll(dirPath, DirectoryPermissions); err != nil {
			return fmt.Errorf("creating directory at %q: %+v", dirPath, err)
		}
	}

	// write the files
	for path, body := range input.f {
		fileFullPath := filepath.Join(workingDirectory, path)
		logger.Trace(fmt.Sprintf("Writing file to %q", fileFullPath))
		file, err := os.Create(fileFullPath)
		if err != nil {
			return fmt.Errorf("opening %q: %+v", fileFullPath, err)
		}

		_, _ = file.Write(*body)
		_ = file.Close()
	}

	return nil
}

func uniqueDirectories(input map[FilePath]*FileBody) []string {
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
