// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationJobSchemaDirectory;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationSynchronizationJobSchemaDirectory";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateApplicationByIdSynchronizationJobByIdSchemaDirectoryOperation(),
        new DeleteApplicationByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new DiscoverApplicationByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new GetApplicationByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new GetApplicationByIdSynchronizationJobByIdSchemaDirectoryCountOperation(),
        new ListApplicationByIdSynchronizationJobByIdSchemaDirectoriesOperation(),
        new UpdateApplicationByIdSynchronizationJobByIdSchemaDirectoryByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
