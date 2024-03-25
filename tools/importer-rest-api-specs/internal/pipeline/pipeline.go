// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type Pipeline struct {
}

type Options struct {
	sourceDataType   models.SourceDataType
	sourceDataOrigin models.SourceDataOrigin
}
