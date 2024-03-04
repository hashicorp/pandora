// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateTerraformResourceTestsStage{}

type generateTerraformResourceTestsStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceDetails specifies the Terraform Resource Definition.
	resourceDetails models.TerraformResourceDefinition
}

func (g generateTerraformResourceTestsStage) generate(input *helpers.FileSystem) error {
	if !g.resourceDetails.Tests.Generate {
		logging.Log.Trace("Test Generation is Disabled - skipping.")
		return nil
	}

	workingDirectory := filepath.Join(g.serviceName, "Terraform", "Tests")

	basicPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Basic-Test.hcl", g.resourceDetails.ResourceName))
	logging.Log.Trace(fmt.Sprintf("Staging Basic Test Configuration to %q", basicPath))
	if err := input.Stage(basicPath, g.resourceDetails.Tests.BasicConfiguration); err != nil {
		return fmt.Errorf("staging Basic Test Configuration: %+v", err)
	}

	requiresImportPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Requires-Import-Test.hcl", g.resourceDetails.ResourceName))
	logging.Log.Trace(fmt.Sprintf("Staging RequiresImport Test Configuration to %q", requiresImportPath))
	if err := input.Stage(requiresImportPath, g.resourceDetails.Tests.RequiresImportConfiguration); err != nil {
		return fmt.Errorf("staging RequiresImport Test Configuration: %+v", err)
	}

	if g.resourceDetails.Tests.TemplateConfiguration != nil {
		templatePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Template-Test.hcl", g.resourceDetails.ResourceName))
		logging.Log.Trace(fmt.Sprintf("Staging Template Test Configuration to %q", templatePath))
		if err := input.Stage(templatePath, *g.resourceDetails.Tests.TemplateConfiguration); err != nil {
			return fmt.Errorf("staging Template Test Configuration: %+v", err)
		}
	}

	if g.resourceDetails.Tests.CompleteConfiguration != nil {
		completePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Complete-Test.hcl", g.resourceDetails.ResourceName))
		logging.Log.Trace(fmt.Sprintf("Staging Complete Test Configuration to %q", completePath))
		if err := input.Stage(completePath, *g.resourceDetails.Tests.CompleteConfiguration); err != nil {
			return fmt.Errorf("staging Complete Test Configuration: %+v", err)
		}
	}

	if g.resourceDetails.Tests.OtherTests != nil {
		for otherTestName, otherTest := range *g.resourceDetails.Tests.OtherTests {
			for index, testStage := range otherTest {
				testStageFileName := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Other-%s-%d-Test.hcl", g.resourceDetails.ResourceName, otherTestName, index))
				logging.Log.Trace(fmt.Sprintf("Staging Test %q Stage %d Test Configuration to %q", otherTestName, index, testStageFileName))
				if err := input.Stage(testStageFileName, testStage); err != nil {
					return fmt.Errorf("staging Test %q Stage %d Test Configuration: %+v", otherTestName, index, err)
				}
			}
		}
	}

	return nil
}

func (g generateTerraformResourceTestsStage) name() string {
	return "Terraform Resource Tests"
}
