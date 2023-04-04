using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.Configurations;

internal class Definition : ResourceDefinition
{
    public string Name => "Configurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateInResourceGroupOperation(),
        new CreateInSubscriptionOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CPUThresholdConstant),
        typeof(CategoryConstant),
        typeof(DigestConfigStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigDataModel),
        typeof(ConfigDataPropertiesModel),
        typeof(ConfigurationListResultModel),
        typeof(DigestConfigModel),
    };
}
