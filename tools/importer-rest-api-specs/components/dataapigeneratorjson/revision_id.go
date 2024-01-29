// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func OutputMetaData(workingDirectory, swaggerGitSha string) error {
	metaData := dataapimodels.MetaData{
		DataSource:        dataapimodels.AzureResourceManagerDataSource,
		SourceInformation: dataapimodels.AzureRestApiSpecsRepositoryApiDefinitionsSource,
		GitRevision:       pointer.To(swaggerGitSha),
	}

	data, err := json.MarshalIndent(&metaData, "", "\t")
	if err != nil {
		return err
	}

	revisionIdFileName := path.Join(workingDirectory, "metadata.json")
	if err := writeJsonToFile(revisionIdFileName, data); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
