// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationTemplateSchemaDirectory;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationSynchronizationTemplateSchemaDirectory";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateSchemaDirectoryOperation(),
        new DeleteSchemaDirectoryOperation(),
        new DiscoverSchemaDirectoryOperation(),
        new GetSchemaDirectoriesCountOperation(),
        new GetSchemaDirectoryOperation(),
        new ListSchemaDirectoriesOperation(),
        new UpdateSchemaDirectoryOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
