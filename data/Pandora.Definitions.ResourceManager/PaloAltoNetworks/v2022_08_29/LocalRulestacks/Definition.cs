using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.LocalRulestacks;

internal class Definition : ResourceDefinition
{
    public string Name => "LocalRulestacks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CommitOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetChangeLogOperation(),
        new GetSupportInfoOperation(),
        new ListAdvancedSecurityObjectsOperation(),
        new ListAppIdsOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCountriesOperation(),
        new ListFirewallsOperation(),
        new ListPredefinedUrlCategoriesOperation(),
        new ListSecurityServicesOperation(),
        new RevertOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdvSecurityObjectTypeEnumConstant),
        typeof(BooleanEnumConstant),
        typeof(DefaultModeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ScopeTypeConstant),
        typeof(SecurityServicesTypeEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvSecurityObjectListResponseModel),
        typeof(AdvSecurityObjectModelModel),
        typeof(ChangelogModel),
        typeof(CountriesResponseModel),
        typeof(CountryModel),
        typeof(ListAppIdResponseModel),
        typeof(ListFirewallsResponseModel),
        typeof(LocalRulestackResourceModel),
        typeof(LocalRulestackResourceUpdateModel),
        typeof(LocalRulestackResourceUpdatePropertiesModel),
        typeof(NameDescriptionObjectModel),
        typeof(PredefinedUrlCategoriesResponseModel),
        typeof(PredefinedUrlCategoryModel),
        typeof(RulestackPropertiesModel),
        typeof(SecurityServicesModel),
        typeof(SecurityServicesResponseModel),
        typeof(SecurityServicesTypeListModel),
        typeof(SupportInfoModel),
    };
}
