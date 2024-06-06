// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type PurgeExistingDefinitionsOptions struct {
	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// PurgeExistingDefinitions removes any existing API Definitions.
func (r repositoryImpl) PurgeExistingDefinitions(opts PurgeExistingDefinitionsOptions) error {
	definitionsDirectory := path.Join(r.workingDirectory, string(opts.SourceDataType))

	if err := os.RemoveAll(definitionsDirectory); err != nil && !os.IsNotExist(err) {
		return fmt.Errorf("removing any existing directory at %q: %+v", definitionsDirectory, err)
	}

	return nil
}
