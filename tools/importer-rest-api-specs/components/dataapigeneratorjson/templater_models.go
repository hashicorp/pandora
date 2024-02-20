// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForModel(modelName string, model importerModels.ModelDetails, parentModel *importerModels.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) ([]byte, error) {
	mapped, err := transforms.MapSDKModelToRepository(modelName, model, parentModel, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping model %q: %+v", modelName, err)
	}

	data, err := json.MarshalIndent(mapped, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
