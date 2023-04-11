using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.Pricings;

internal class Definition : ResourceDefinition
{
    public string Name => "Pricings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateResourceGroupPricingOperation(),
        new GetResourceGroupPricingOperation(),
        new GetSubscriptionPricingOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateSubscriptionPricingOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InformationProtectionPolicyNameConstant),
        typeof(PricingTierConstant),
        typeof(SettingNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PricingModel),
        typeof(PricingPropertiesModel),
    };
}
