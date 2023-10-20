using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.GlobalRulestack;

internal class Definition : ResourceDefinition
{
    public string Name => "GlobalRulestack";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CommitOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetChangeLogOperation(),
        new ListOperation(),
        new ListAdvancedSecurityObjectsOperation(),
        new ListAppIdsOperation(),
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
        typeof(GlobalRulestackResourceModel),
        typeof(GlobalRulestackResourceUpdateModel),
        typeof(GlobalRulestackResourceUpdatePropertiesModel),
        typeof(ListAppIdResponseModel),
        typeof(ListFirewallsResponseModel),
        typeof(NameDescriptionObjectModel),
        typeof(PredefinedUrlCategoriesResponseModel),
        typeof(PredefinedUrlCategoryModel),
        typeof(RulestackPropertiesModel),
        typeof(SecurityServicesModel),
        typeof(SecurityServicesResponseModel),
        typeof(SecurityServicesTypeListModel),
    };
}
