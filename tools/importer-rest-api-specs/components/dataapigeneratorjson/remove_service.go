// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type RemoveServiceOptions struct {
	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// RemoveService removes any existing API Definitions for the Service specified in opts.
func (r repositoryImpl) RemoveService(opts RemoveServiceOptions) error {
	// TODO: note this is going to need to take SourceDataOrigin into account too

	serviceDirectory := path.Join(r.workingDirectory, string(opts.SourceDataType), opts.ServiceName)
	if err := os.RemoveAll(serviceDirectory); err != nil && os.IsNotExist(err) {
		return fmt.Errorf("removing any existing directory at %q: %+v", serviceDirectory, err)
	}

	return nil
}
