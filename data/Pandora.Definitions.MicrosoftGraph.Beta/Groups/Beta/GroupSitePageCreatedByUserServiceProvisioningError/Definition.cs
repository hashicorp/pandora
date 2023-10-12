// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSitePageCreatedByUserServiceProvisioningError;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSitePageCreatedByUserServiceProvisioningError";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetGroupByIdSiteByIdPageByIdCreatedByUserServiceProvisioningErrorCountOperation(),
        new ListGroupByIdSiteByIdPageByIdCreatedByUserServiceProvisioningErrorsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
