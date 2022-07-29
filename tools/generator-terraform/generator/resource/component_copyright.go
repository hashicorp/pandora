package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func copyrightLinesForResource(_ models.ResourceInput) (*string, error) {
	// TODO: hook the license up for this service
	output := copyrightLinesForSource(resourcemanager.ApiDefinitionsSourceResourceManagerRestApiSpecs)
	return &output, nil
}

func copyrightLinesForSource(input resourcemanager.ApiDefinitionsSource) string {
	if input == resourcemanager.ApiDefinitionsSourceHandWritten {
		return `
// Copyright (c) HashiCorp Inc. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
	}

	if input == resourcemanager.ApiDefinitionsSourceResourceManagerRestApiSpecs {
		return `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
	}

	// this is used purely for acctests - to ensure the config is stable this is a
	// hand-defined value
	if string(input) == "acctest" {
		return "// acctests licence placeholder"
	}

	panic(fmt.Errorf("unimplemented license type: %s", string(input)))
}
