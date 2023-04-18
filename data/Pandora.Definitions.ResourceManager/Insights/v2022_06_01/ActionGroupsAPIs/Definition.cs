using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.ActionGroupsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ActionGroupsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActionGroupsCreateNotificationsAtActionGroupResourceLevelOperation(),
        new ActionGroupsCreateNotificationsAtResourceGroupLevelOperation(),
        new ActionGroupsCreateOrUpdateOperation(),
        new ActionGroupsDeleteOperation(),
        new ActionGroupsEnableReceiverOperation(),
        new ActionGroupsGetOperation(),
        new ActionGroupsGetTestNotificationsOperation(),
        new ActionGroupsGetTestNotificationsAtActionGroupResourceLevelOperation(),
        new ActionGroupsGetTestNotificationsAtResourceGroupLevelOperation(),
        new ActionGroupsListByResourceGroupOperation(),
        new ActionGroupsListBySubscriptionIdOperation(),
        new ActionGroupsPostTestNotificationsOperation(),
        new ActionGroupsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReceiverStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionDetailModel),
        typeof(ActionGroupModel),
        typeof(ActionGroupListModel),
        typeof(ActionGroupPatchModel),
        typeof(ActionGroupPatchBodyModel),
        typeof(ActionGroupResourceModel),
        typeof(ArmRoleReceiverModel),
        typeof(AutomationRunbookReceiverModel),
        typeof(AzureAppPushReceiverModel),
        typeof(AzureFunctionReceiverModel),
        typeof(ContextModel),
        typeof(EmailReceiverModel),
        typeof(EnableRequestModel),
        typeof(EventHubReceiverModel),
        typeof(ItsmReceiverModel),
        typeof(LogicAppReceiverModel),
        typeof(NotificationRequestBodyModel),
        typeof(SmsReceiverModel),
        typeof(TestNotificationDetailsResponseModel),
        typeof(VoiceReceiverModel),
        typeof(WebhookReceiverModel),
    };
}
