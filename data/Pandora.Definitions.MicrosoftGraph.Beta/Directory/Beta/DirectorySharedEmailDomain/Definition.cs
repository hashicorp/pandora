// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectorySharedEmailDomain;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectorySharedEmailDomain";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectorySharedEmailDomainOperation(),
        new DeleteDirectorySharedEmailDomainByIdOperation(),
        new GetDirectorySharedEmailDomainByIdOperation(),
        new GetDirectorySharedEmailDomainCountOperation(),
        new ListDirectorySharedEmailDomainsOperation(),
        new UpdateDirectorySharedEmailDomainByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
