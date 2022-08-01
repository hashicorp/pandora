package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func copyrightLinesForResource(_ models.ResourceInput) (*string, error) {
	// TODO: hook the license up for this service
	output, err := copyrightLinesForSource(resourcemanager.ApiDefinitionsSourceResourceManagerRestApiSpecs)
	if err != nil {
		return nil, err
	}
	return output, nil
}

func copyrightLinesForSource(input resourcemanager.ApiDefinitionsSource) (*string, error) {
	if input == resourcemanager.ApiDefinitionsSourceHandWritten {
		output := `
// Copyright (c) HashiCorp Inc. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &output, nil
	}

	if input == resourcemanager.ApiDefinitionsSourceResourceManagerRestApiSpecs {
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
