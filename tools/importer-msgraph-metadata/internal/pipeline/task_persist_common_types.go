// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

func (p pipeline) PersistCommonTypesDefinitions(commonTypesForVersion sdkModels.CommonTypes) error {
	logging.Infof("Persisting Common Types Definitions..")

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: commonTypesForVersion,
	}

	opts := repository.SaveCommonTypesOptions{
		CommonTypes:      commonTypes,
		SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
	}

	if err := p.repo.SaveCommonTypes(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Common Types: %+v", err)
	}

	return nil
}
