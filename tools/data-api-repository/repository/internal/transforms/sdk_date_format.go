// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKDateFormatFromRepository(input repositoryModels.DateFormat) (*sdkModels.SDKDateFormat, error) {
	if input == repositoryModels.RFC3339DateFormat {
		return pointer.To(sdkModels.RFC3339SDKDateFormat), nil
	}

	return nil, fmt.Errorf("missing mapping for SDKDateFormat %q", string(input))
}

func mapSDKDateFormatToRepository(input sdkModels.SDKDateFormat) (*repositoryModels.DateFormat, error) {
	if input == sdkModels.RFC3339SDKDateFormat {
		return pointer.To(repositoryModels.RFC3339DateFormat), nil
	}

	if input == sdkModels.RFC3339NanoSDKDateFormat {
		// TODO: support this in the Repository, Go SDK/TF Generator
		return nil, fmt.Errorf("RFC3339 Nano support is not yet implemented - see https://github.com/hashicorp/pandora/issues/8")
	}

	return nil, fmt.Errorf("missing mapping for SDKDateFormat %q", string(input))
}
