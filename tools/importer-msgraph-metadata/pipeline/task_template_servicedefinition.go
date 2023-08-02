package pipeline

import (
	"fmt"
	"path"
)

func (p pipelineTask) templateServiceDefinitionForService(resources Resources) error {
	if !resources.ServiceHasValidResources(p.service) {
		return nil
	}

	filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(p.apiVersion)), cleanName(p.service), "ServiceDefinition.cs")
	if err := p.files.addFile(filename, templateServiceDefinition(p.service, p.apiVersion)); err != nil {
		return err
	}

	filename = path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(p.apiVersion)), cleanName(p.service), "ServiceDefinition-GenerationSettings.cs")
	if err := p.files.addFile(filename, templateServiceDefinitionGenerationSettings(p.service, p.apiVersion)); err != nil {
		return err
	}

	return nil
}

func templateServiceDefinition(serviceName, apiVersion string) string {
	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

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
