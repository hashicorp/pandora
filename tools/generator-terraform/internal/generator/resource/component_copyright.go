package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func copyrightLinesForResource(_ generatorModels.ResourceInput) (*string, error) {
	// TODO: hook the license up for this service
	output, err := copyrightLinesForSourceDataOrigin(models.AzureRestAPISpecsSourceDataOrigin)
	if err != nil {
		return nil, err
	}
	return output, nil
}

func copyrightLinesForSourceDataOrigin(input models.SourceDataOrigin) (*string, error) {
	if input == models.HandWrittenSourceDataOrigin {
		output := `
// Copyright IBM Corp. 2021, 2025 All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &output, nil
	}

	if input == models.AzureRestAPISpecsSourceDataOrigin {
		output := `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &output, nil
	}

	// this is used purely for acctests - to ensure the config is stable this is a
	// hand-defined value
	if string(input) == "acctest" {
		output := "// acctests licence placeholder"
		return &output, nil
	}

	return nil, fmt.Errorf("unimplemented license type: %s", string(input))
}
