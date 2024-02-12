// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var sdkDateFormats = map[repositories.DateFormat]models.DateFormat{
	repositories.RFC3339DateFormat: models.RFC3339SDKDateFormat,
}

func mapSDKDateFormat(input repositories.DateFormat) (*models.DateFormat, error) {
	if v, ok := sdkDateFormats[input]; ok {
		return pointer.To(v), nil
	}
	return nil, fmt.Errorf("internal-error: missing mapping for SDKDateFormat %q", string(input))
}
