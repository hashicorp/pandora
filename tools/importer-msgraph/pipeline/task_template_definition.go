package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"os"
)

func (pipelineTask) templateDefinitionForService(files *Tree, serviceName, apiVersion string, logger hclog.Logger) error {
	filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]sDefinition.cs", string(os.PathSeparator), versionDirectory(apiVersion), serviceName, cleanName(apiVersion))
	tpl := templateDefinition(serviceName, apiVersion)

	if err := files.addFile(filename, tpl); err != nil {
		return err
	}

	return nil
}

func templateDefinition(serviceName, apiVersion string) string {
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
        new Definition(),
    };
}
`, serviceName, versionDirectory(apiVersion), cleanName(apiVersion), versionIsPreview(apiVersion))
}
