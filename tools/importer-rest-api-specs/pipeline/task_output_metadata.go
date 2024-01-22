// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
)

func (pipelineTask) outputMetaData(input RunInput, rootNamespace, swaggerGitSha string) error {
	if featureflags.GenerateV1APIDefinitions {
		if err := dataapigenerator.OutputRevisionId(input.OutputDirectoryCS, rootNamespace, swaggerGitSha); err != nil {
			return fmt.Errorf("outputting the Revision Id: %+v", err)
		}
	}

	if featureflags.GenerateV2APIDefinitions {
		// This is named metadata since it could make sense to output additional items in the future
		// such as the licence for this imported data etc
		if err := dataapigeneratorjson.OutputMetaData(input.OutputDirectoryJson, swaggerGitSha); err != nil {
			return fmt.Errorf("outputting the Revision ID into the V2 Data: %+v", err)
		}
	}

	return nil
}
