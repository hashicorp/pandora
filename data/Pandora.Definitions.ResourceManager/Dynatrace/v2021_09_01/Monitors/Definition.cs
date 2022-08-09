using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;

internal class Definition : ResourceDefinition
{
    public string Name => "Monitors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAccountCredentialsOperation(),
        new GetSSODetailsOperation(),
        new GetVMHostPayloadOperation(),
        new ListAppServicesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionIdOperation(),
        new ListHostsOperation(),
        new ListLinkableEnvironmentsOperation(),
        new ListMonitoredResourcesOperation(),
        new UpdateOperation(),
    };
}
