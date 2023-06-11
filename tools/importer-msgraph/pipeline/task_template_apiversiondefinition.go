package pipeline

import (
	"fmt"
	"os"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateApiVersionDefinitionForService(files *Tree, serviceName, apiVersion string, resources Resources, logger hclog.Logger) error {
	categoriesMap := make(map[string]bool)
	for _, resource := range resources {
		categoriesMap[resource.Category] = true
	}

	categories := make([]string, 0, len(categoriesMap))
	for c, _ := range categoriesMap {
		categories = append(categories, c)
	}

	filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]sApiVersionDefinition.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), serviceName, cleanVersion(apiVersion))
	if err := files.addFile(filename, templateApiVersionDefinition(serviceName, apiVersion, categories)); err != nil {
		return err
	}

	filename = fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]sApiVersionDefinition-GenerationSettings.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), serviceName, cleanVersion(apiVersion))
	if err := files.addFile(filename, templateApiVersionDefinitionGenerationSettings(serviceName, apiVersion)); err != nil {
		return err
	}

	return nil
}

func templateApiVersionDefinition(serviceName, apiVersion string, categories []string) string {
	categoriesSlice := make([]string, 0, len(categories))
	for _, c := range categories {
		categoriesSlice = append(categoriesSlice, fmt.Sprintf("new %s.Definition()", c))
	}
	categoriesCode := indentSpace(strings.Join(categoriesSlice, ",\n"), 8)

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "%[3]s";
    public bool Preview => %[4]t;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
%[5]s
    };
}
`, cleanName(serviceName), definitionsDirectory(apiVersion), cleanVersion(apiVersion), versionIsPreview(apiVersion), categoriesCode)
}

func templateApiVersionDefinitionGenerationSettings(serviceName, apiVersion string) string {
	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

public partial class Definition
{
    public bool Generate => true;
}
`, cleanName(serviceName), definitionsDirectory(apiVersion), cleanVersion(apiVersion))
}
