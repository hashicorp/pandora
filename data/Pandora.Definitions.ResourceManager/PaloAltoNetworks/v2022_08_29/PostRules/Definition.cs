using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.PostRules;

internal class Definition : ResourceDefinition
{
    public string Name => "PostRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetCountersOperation(),
        new ListOperation(),
        new RefreshCountersOperation(),
        new ResetCountersOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionEnumConstant),
        typeof(BooleanEnumConstant),
        typeof(DecryptionRuleTypeEnumConstant),
        typeof(ProvisioningStateConstant),
        typeof(StateEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppSeenDataModel),
        typeof(AppSeenInfoModel),
        typeof(CategoryModel),
        typeof(DestinationAddrModel),
        typeof(PostRulesResourceModel),
        typeof(RuleCounterModel),
        typeof(RuleCounterResetModel),
        typeof(RuleEntryModel),
        typeof(SourceAddrModel),
        typeof(TagInfoModel),
    };
}
