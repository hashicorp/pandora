using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.ActionGroupsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ActionGroupsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActionGroupsCreateOrUpdateOperation(),
        new ActionGroupsDeleteOperation(),
        new ActionGroupsEnableReceiverOperation(),
        new ActionGroupsGetOperation(),
        new ActionGroupsListByResourceGroupOperation(),
        new ActionGroupsListBySubscriptionIdOperation(),
        new ActionGroupsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReceiverStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionGroupModel),
        typeof(ActionGroupListModel),
        typeof(ActionGroupPatchModel),
        typeof(ActionGroupPatchBodyModel),
        typeof(ActionGroupResourceModel),
        typeof(AutomationRunbookReceiverModel),
        typeof(AzureAppPushReceiverModel),
        typeof(AzureFunctionReceiverModel),
        typeof(EmailReceiverModel),
        typeof(EnableRequestModel),
        typeof(ItsmReceiverModel),
        typeof(LogicAppReceiverModel),
        typeof(SmsReceiverModel),
        typeof(VoiceReceiverModel),
        typeof(WebhookReceiverModel),
    };
}
