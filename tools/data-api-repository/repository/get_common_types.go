// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// GetCommonTypes returns all the Common Types (Constants and Models) for this SourceDataType
// this returns a map of APIVersion (key) to CommonTypes (value).
func (r *repositoryImpl) GetCommonTypes() (*map[string]sdkModels.CommonTypes, error) {
	// The CommonTypes are loaded/cached when the Repository is initialized, as such we
	// can just return those.
	// When the Common Types are updated, the cache is invalidated/updated, so this should
	// always be fresh.
	return &r.cachedCommonTypes, nil
}
