// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"os"
	"path"
)

func (p pipelineTask) removeDirectoryForService(resources Resources) error {
	categories := make(map[string]bool)
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		categories[resource.Category] = true
	}

	for category, _ := range categories {
		dirName := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(p.apiVersion)), cleanName(p.service), cleanVersion(p.apiVersion), category)
		if err := os.RemoveAll(dirName); err != nil {
			return fmt.Errorf("removing any existing directory at %q: %+v", dirName, err)
		}
	}

	return nil
}
