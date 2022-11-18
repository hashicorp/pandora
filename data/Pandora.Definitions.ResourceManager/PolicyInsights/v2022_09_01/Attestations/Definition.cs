using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2022_09_01.Attestations;

internal class Definition : ResourceDefinition
{
    public string Name => "Attestations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AttestationsCreateOrUpdateAtResourceOperation(),
        new AttestationsCreateOrUpdateAtResourceGroupOperation(),
        new AttestationsCreateOrUpdateAtSubscriptionOperation(),
        new AttestationsDeleteAtResourceOperation(),
        new AttestationsDeleteAtResourceGroupOperation(),
        new AttestationsDeleteAtSubscriptionOperation(),
        new AttestationsGetAtResourceOperation(),
        new AttestationsGetAtResourceGroupOperation(),
        new AttestationsGetAtSubscriptionOperation(),
        new AttestationsListForResourceOperation(),
        new AttestationsListForResourceGroupOperation(),
        new AttestationsListForSubscriptionOperation(),
    };
}
