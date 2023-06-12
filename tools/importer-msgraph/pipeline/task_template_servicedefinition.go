package pipeline

import (
	"fmt"
	"os"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateServiceDefinitionForService(files *Tree, serviceName, apiVersion string, resources Resources, logger hclog.Logger) error {
	hasResources := false
	for _, resource := range resources {
		if resource.Category == "" {
			continue // TODO do something about orphaned resources
		}

		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "resource", operation.ResourceId.ID(), "method", operation.Method)
				logger.Debug(fmt.Sprintf("Skipping unknown operation for ID %q (category %q, service %q, version %q)", operation.ResourceId.ID(), resource.Category, resource.Service, resource.Version))
				continue
			}

			// Skip functions and casts for now
			if operation.ResourceId != nil && len(operation.ResourceId.Segments) > 0 {
				if lastSegment := operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction || lastSegment.Type == SegmentODataReference {
					logger.Debug(fmt.Sprintf("Skipping suspected cast/function/reference resource for ID %q (category %q, service %q, version %q)", operation.ResourceId.ID(), resource.Category, resource.Service, resource.Version))
					continue
				}
			}

			if operation.Type == OperationTypeList || operation.Type == OperationTypeRead {
				// Determine whether to skip operation with missing response model
				if operation.Type != OperationTypeDelete {
					if responseModel := findModel(operation.Responses); responseModel == "" {
						if operation.ResourceId == nil || len(operation.ResourceId.Segments) == 0 || operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1].Value != "$ref" {
							continue
						}
					}
				}
			}

			hasResources = true
			break
		}
	}

	if hasResources {
		filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]sServiceDefinition.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), cleanName(serviceName))
		if err := files.addFile(filename, templateServiceDefinition(serviceName, apiVersion)); err != nil {
			return err
		}

		filename = fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]sServiceDefinition-GenerationSettings.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), cleanName(serviceName))
		if err := files.addFile(filename, templateServiceDefinitionGenerationSettings(serviceName, apiVersion)); err != nil {
			return err
		}
	}

	return nil
}

func templateServiceDefinition(serviceName, apiVersion string) string {
	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s;

public partial class Service : ServiceDefinition
{
    public string Name => "%[1]s";
    public string? ResourceProvider => null;
    public string? TerraformPackageName => null;

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {

    };
}
`, cleanName(serviceName), definitionsDirectory(apiVersion))
}

func templateServiceDefinitionGenerationSettings(serviceName, apiVersion string) string {
	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s;

public partial class Service
{
    public bool Generate => true;
}
`, cleanName(serviceName), definitionsDirectory(apiVersion), cleanVersion(apiVersion))
}
