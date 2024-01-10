using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.ApplicationGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationGroup";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateApplicationGroupOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByNamespaceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationGroupPolicyTypeConstant),
        typeof(MetricIdConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationGroupModel),
        typeof(ApplicationGroupPolicyModel),
        typeof(ApplicationGroupPropertiesModel),
        typeof(ThrottlingPolicyModel),
    };
}
