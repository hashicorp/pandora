// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p pipeline) PersistCommonTypesDefinitions() error {
	p.logger.Info("Persisting Common Types Definitions..")

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: p.commonTypesForVersion,
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
