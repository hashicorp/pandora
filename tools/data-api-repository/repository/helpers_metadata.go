// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"encoding/json"
	"fmt"
	"os"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (r *repositoryImpl) writeSourceDataInformation(sourceDataOrigin sdkModels.SourceDataOrigin, sourceCommitSHA *string) error {
	data := transforms.MetaData{
		GitRevision:      sourceCommitSHA,
		SourceDataType:   r.sourceDataType,
		SourceDataOrigin: sourceDataOrigin,
	}
	metaData, err := transforms.MapMetaDataToRepository(data)
	if err != nil {
		return fmt.Errorf("mapping metadata: %+v", err)
	}

	sourceDataDirectory, err := r.defaultDirectoryForSourceDataOrigin(sourceDataOrigin)
	if err != nil {
		return fmt.Errorf("determining the default directory: %+v", err)
	}
	path := filepath.Join(*sourceDataDirectory, "metadata.json")

	body, err := json.MarshalIndent(metaData, "", "  ")
	if err != nil {
		return fmt.Errorf("marshalling JSON: %+v", err)
	}

	file, err := os.Create(path)
	if err != nil {
		return fmt.Errorf("opening %q: %+v", path, err)
	}
	defer file.Close()

	_, _ = file.Write(body)
	return nil
}
