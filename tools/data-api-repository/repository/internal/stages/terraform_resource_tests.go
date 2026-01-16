// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = TerraformResourceTestsStage{}

type TerraformResourceTestsStage struct {
	// ResourceDetails specifies the Terraform Resource Definition.
	ResourceDetails sdkModels.TerraformResourceDefinition
}

func (g TerraformResourceTestsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	if !g.ResourceDetails.Tests.Generate {
		logger.Trace("Test Generation is Disabled - skipping.")
		return nil
	}

	workingDirectory := filepath.Join("Terraform", "Tests")

	basicPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Basic-Test.hcl", g.ResourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging Basic Test Configuration to %q", basicPath))
	if err := input.Stage(basicPath, g.ResourceDetails.Tests.BasicConfiguration); err != nil {
		return fmt.Errorf("staging Basic Test Configuration: %+v", err)
	}

	requiresImportPath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Requires-Import-Test.hcl", g.ResourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging RequiresImport Test Configuration to %q", requiresImportPath))
	if err := input.Stage(requiresImportPath, g.ResourceDetails.Tests.RequiresImportConfiguration); err != nil {
		return fmt.Errorf("staging RequiresImport Test Configuration: %+v", err)
	}

	if g.ResourceDetails.Tests.TemplateConfiguration != nil {
		templatePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Template-Test.hcl", g.ResourceDetails.ResourceName))
		logger.Trace(fmt.Sprintf("Staging Template Test Configuration to %q", templatePath))
		if err := input.Stage(templatePath, *g.ResourceDetails.Tests.TemplateConfiguration); err != nil {
			return fmt.Errorf("staging Template Test Configuration: %+v", err)
		}
	}

	if g.ResourceDetails.Tests.CompleteConfiguration != nil {
		completePath := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Complete-Test.hcl", g.ResourceDetails.ResourceName))
		logger.Trace(fmt.Sprintf("Staging Complete Test Configuration to %q", completePath))
		if err := input.Stage(completePath, *g.ResourceDetails.Tests.CompleteConfiguration); err != nil {
			return fmt.Errorf("staging Complete Test Configuration: %+v", err)
		}
	}

	if g.ResourceDetails.Tests.OtherTests != nil {
		for otherTestName, otherTest := range *g.ResourceDetails.Tests.OtherTests {
			for index, testStage := range otherTest {
				testStageFileName := filepath.Join(workingDirectory, fmt.Sprintf("%s-Resource-Other-%s-%d-Test.hcl", g.ResourceDetails.ResourceName, otherTestName, index))
				logger.Trace(fmt.Sprintf("Staging Test %q Stage %d Test Configuration to %q", otherTestName, index, testStageFileName))
				if err := input.Stage(testStageFileName, testStage); err != nil {
					return fmt.Errorf("staging Test %q Stage %d Test Configuration: %+v", otherTestName, index, err)
				}
			}
		}
	}

	return nil
}

func (g TerraformResourceTestsStage) Name() string {
	return "Terraform Resource Tests"
}
