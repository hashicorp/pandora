// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type RemoveCommonTypesOptions struct {
	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType

	// Version is an optional API version to remove. When omitted, all versions are removed.
	Version string
}

// RemoveCommonTypes removes any existing Common Types Definitions.
func (r repositoryImpl) RemoveCommonTypes(opts RemoveCommonTypesOptions) error {
	commonTypesDirectory := path.Join(r.workingDirectory, string(opts.SourceDataType), commonTypesDirectoryName)

	if opts.Version != "" {
		commonTypesDirectory = path.Join(commonTypesDirectory, opts.Version)
	}

	if err := os.RemoveAll(commonTypesDirectory); err != nil && os.IsNotExist(err) {
		return fmt.Errorf("removing any existing directory at %q: %+v", commonTypesDirectory, err)
	}

	return nil
}
