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
        new CreateOrUpdateAtResourceOperation(),
        new CreateOrUpdateAtResourceGroupOperation(),
        new CreateOrUpdateAtSubscriptionOperation(),
        new DeleteAtResourceOperation(),
        new DeleteAtResourceGroupOperation(),
        new DeleteAtSubscriptionOperation(),
        new GetAtResourceOperation(),
        new GetAtResourceGroupOperation(),
        new GetAtSubscriptionOperation(),
        new ListForResourceOperation(),
        new ListForResourceGroupOperation(),
        new ListForSubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ComplianceStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AttestationModel),
        typeof(AttestationEvidenceModel),
        typeof(AttestationPropertiesModel),
    };
}
