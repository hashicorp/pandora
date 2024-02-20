// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

func OutputMetaData(workingDirectory, swaggerGitSha string) error {
	// TODO: this needs to be moved

	metaData, err := transforms.MapMetaDataToRepository(pointer.To(swaggerGitSha), models.ResourceManagerSourceDataType, models.AzureRestAPISpecsSourceDataOrigin)
	if err != nil {
		return err
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
