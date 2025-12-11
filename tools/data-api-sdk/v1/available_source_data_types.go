// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

// AvailableSourceDataTypes returns a list of the supported Source Data Types.
// This can be used to allow tooling to automatically support new Source Data
// Types as these are defined here, for example by using this information in CLIs.
func AvailableSourceDataTypes() []models.SourceDataType {
	return []models.SourceDataType{
		models.MicrosoftGraphSourceDataType,
		models.ResourceManagerSourceDataType,
	}
}
