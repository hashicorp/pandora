// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type Options struct {
	// TODO: docs etc
	APIDefinitionsDirectory       string
	ConfigFilePath                string
	ProviderPrefix                string
	RestAPISpecsDirectory         string
	ServiceNamesToLimitTo         []string
	SourceDataOrigin              models.SourceDataOrigin
	SourceDataType                models.SourceDataType
	TerraformDefinitionsDirectory string
}
