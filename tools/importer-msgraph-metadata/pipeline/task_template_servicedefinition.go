package pipeline

import (
	"fmt"
	"os"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateServiceDefinitionForService(files *Tree, serviceName, apiVersion string, resources Resources, logger hclog.Logger) error {
	if !resources.ServiceHasValidResources(serviceName) {
		return nil
	}

	filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]sServiceDefinition.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), cleanName(serviceName))
	if err := files.addFile(filename, templateServiceDefinition(serviceName, apiVersion)); err != nil {
		return err
	}

	filename = fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]sServiceDefinition-GenerationSettings.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), cleanName(serviceName))
	if err := files.addFile(filename, templateServiceDefinitionGenerationSettings(serviceName, apiVersion)); err != nil {
		return err
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
