// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForConstant(constantName string, details resourcemanager.ConstantDetails) ([]byte, error) {
	mapped, err := transforms.MapConstantToRepository(constantName, details)
	if err != nil {
		return nil, err
	}

	data, err := json.MarshalIndent(mapped, "", "\t")
	if err != nil {
		return nil, err
	}

	return data, nil
}
