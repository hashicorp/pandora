// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"fmt"
	"os"
	"path/filepath"
	"sort"
)

func filesWithinDirectory(workingDirectory string) (*[]string, error) {
	filePaths := make([]string, 0)
	err := filepath.Walk(workingDirectory,
		func(fullPath string, info os.FileInfo, err error) error {
			if err != nil {
				return fmt.Errorf("opening %q: %+v", filePaths, err)
			}

			// no point pulling empty directories along, just the files will be fine
			if !info.IsDir() {
				filePaths = append(filePaths, fullPath)
			}
			return nil
		})
	if err != nil {
		return nil, err // wrapped elsewhere
	}
	sort.Strings(filePaths)
	return &filePaths, nil
}
