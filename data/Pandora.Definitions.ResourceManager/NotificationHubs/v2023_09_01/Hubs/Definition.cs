using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Hubs;

internal class Definition : ResourceDefinition
{
    public string Name => "Hubs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NotificationHubsCheckNotificationHubAvailabilityOperation(),
        new NotificationHubsCreateOrUpdateOperation(),
        new NotificationHubsCreateOrUpdateAuthorizationRuleOperation(),
        new NotificationHubsDebugSendOperation(),
        new NotificationHubsDeleteOperation(),
        new NotificationHubsDeleteAuthorizationRuleOperation(),
        new NotificationHubsGetOperation(),
        new NotificationHubsGetAuthorizationRuleOperation(),
        new NotificationHubsGetPnsCredentialsOperation(),
        new NotificationHubsListOperation(),
        new NotificationHubsListAuthorizationRulesOperation(),
        new NotificationHubsListKeysOperation(),
        new NotificationHubsRegenerateKeysOperation(),
        new NotificationHubsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(PolicyKeyTypeConstant),
        typeof(SkuNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdmCredentialModel),
        typeof(AdmCredentialPropertiesModel),
        typeof(ApnsCredentialModel),
        typeof(ApnsCredentialPropertiesModel),
        typeof(BaiduCredentialModel),
        typeof(BaiduCredentialPropertiesModel),
        typeof(BrowserCredentialModel),
        typeof(BrowserCredentialPropertiesModel),
        typeof(CheckAvailabilityParametersModel),
        typeof(CheckAvailabilityResultModel),
        typeof(DebugSendResponseModel),
        typeof(DebugSendResultModel),
        typeof(GcmCredentialModel),
        typeof(GcmCredentialPropertiesModel),
        typeof(MpnsCredentialModel),
        typeof(MpnsCredentialPropertiesModel),
        typeof(NotificationHubPatchParametersModel),
        typeof(NotificationHubPropertiesModel),
        typeof(NotificationHubResourceModel),
        typeof(PnsCredentialsModel),
        typeof(PnsCredentialsResourceModel),
        typeof(PolicyKeyResourceModel),
        typeof(RegistrationResultModel),
        typeof(ResourceListKeysModel),
        typeof(SharedAccessAuthorizationRulePropertiesModel),
        typeof(SharedAccessAuthorizationRuleResourceModel),
        typeof(SkuModel),
        typeof(WnsCredentialModel),
        typeof(WnsCredentialPropertiesModel),
        typeof(XiaomiCredentialModel),
        typeof(XiaomiCredentialPropertiesModel),
    };
}
