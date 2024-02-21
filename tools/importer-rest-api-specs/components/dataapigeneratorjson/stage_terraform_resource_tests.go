// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ generatorStage = generateTerraformResourceTestsStage{}

type generateTerraformResourceTestsStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceDetails specifies the Terraform Resource Definition.
	resourceDetails resourcemanager.TerraformResourceDetails
}

func (g generateTerraformResourceTestsStage) generate(input *fileSystem, logger hclog.Logger) error {
	if !g.resourceDetails.Tests.Generate {
		logger.Trace("Test Generation is Disabled - skipping.")
		return nil
	}

	workingDirectory := filepath.Join(g.serviceName, "Terraform", "Tests")

	basicPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Basic-Test.hcl", g.resourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging Basic Test Configuration to %q", basicPath))
	if err := input.stage(basicPath, g.resourceDetails.Tests.BasicConfiguration); err != nil {
		return fmt.Errorf("staging Basic Test Configuration: %+v", err)
	}

	requiresImportPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Requires-Import-Test.hcl", g.resourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging RequiresImport Test Configuration to %q", requiresImportPath))
	if err := input.stage(requiresImportPath, g.resourceDetails.Tests.RequiresImportConfiguration); err != nil {
		return fmt.Errorf("staging RequiresImport Test Configuration: %+v", err)
	}

	if g.resourceDetails.Tests.TemplateConfiguration != nil {
		templatePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Template-Test.hcl", g.resourceDetails.ResourceName))
		logger.Trace(fmt.Sprintf("Staging Template Test Configuration to %q", templatePath))
		if err := input.stage(templatePath, *g.resourceDetails.Tests.TemplateConfiguration); err != nil {
			return fmt.Errorf("staging Template Test Configuration: %+v", err)
		}
	}

	if g.resourceDetails.Tests.CompleteConfiguration != nil {
		completePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Complete-Test.hcl", g.resourceDetails.ResourceName))
		logger.Trace(fmt.Sprintf("Staging Complete Test Configuration to %q", completePath))
		if err := input.stage(completePath, *g.resourceDetails.Tests.CompleteConfiguration); err != nil {
			return fmt.Errorf("staging Complete Test Configuration: %+v", err)
		}
	}

	if g.resourceDetails.Tests.OtherTests != nil {
		for otherTestName, otherTest := range g.resourceDetails.Tests.OtherTests {
			for index, testStage := range otherTest {
				testStageFileName := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Other-%s-%d-Test.hcl", g.resourceDetails.ResourceName, otherTestName, index))
				logger.Trace(fmt.Sprintf("Staging Test %q Stage %d Test Configuration to %q", otherTestName, index, testStageFileName))
				if err := input.stage(testStageFileName, testStage); err != nil {
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
