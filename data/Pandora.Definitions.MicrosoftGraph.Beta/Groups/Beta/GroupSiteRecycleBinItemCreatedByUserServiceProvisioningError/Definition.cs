// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteRecycleBinItemCreatedByUserServiceProvisioningError;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteRecycleBinItemCreatedByUserServiceProvisioningError";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetGroupByIdSiteByIdRecycleBinItemByIdCreatedByUserServiceProvisioningErrorCountOperation(),
        new ListGroupByIdSiteByIdRecycleBinItemByIdCreatedByUserServiceProvisioningErrorsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
