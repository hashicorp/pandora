package pipeline

import (
	"fmt"
	"os"
	"sort"
	"strings"
)

func (p pipelineTask) templateApiVersionDefinitionForService(resources Resources) error {
	if !resources.ServiceHasValidResources(p.service) {
		return nil
	}

	categoriesMap := make(map[string]bool)
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		categoriesMap[resource.Category] = true
	}

	categories := make([]string, 0, len(categoriesMap))
	for c, _ := range categoriesMap {
		categories = append(categories, c)
	}

	filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]sApiVersionDefinition.cs", string(os.PathSeparator), definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion))
	if err := p.files.addFile(filename, templateApiVersionDefinition(p.service, p.apiVersion, categories)); err != nil {
		return err
	}

	filename = fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]sApiVersionDefinition-GenerationSettings.cs", string(os.PathSeparator), definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion))
	if err := p.files.addFile(filename, templateApiVersionDefinitionGenerationSettings(p.service, p.apiVersion)); err != nil {
		return err
	}

	return nil
}

func templateApiVersionDefinition(serviceName, apiVersion string, categories []string) string {
	categoriesSlice := make([]string, 0, len(categories))
	for _, c := range categories {
		categoriesSlice = append(categoriesSlice, fmt.Sprintf("new %s.Definition()", c))
	}
	sort.Strings(categoriesSlice)
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
