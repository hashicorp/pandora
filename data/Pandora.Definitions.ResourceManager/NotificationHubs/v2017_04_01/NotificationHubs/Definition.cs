using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01.NotificationHubs;

internal class Definition : ResourceDefinition
{
    public string Name => "NotificationHubs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNotificationHubAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAuthorizationRuleOperation(),
        new DebugSendOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new GetPnsCredentialsOperation(),
        new ListOperation(),
        new ListAuthorizationRulesOperation(),
        new ListKeysOperation(),
        new PatchOperation(),
        new RegenerateKeysOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
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
        typeof(CheckAvailabilityParametersModel),
        typeof(CheckAvailabilityResultModel),
        typeof(DebugSendResponseModel),
        typeof(DebugSendResultModel),
        typeof(GcmCredentialModel),
        typeof(GcmCredentialPropertiesModel),
        typeof(MpnsCredentialModel),
        typeof(MpnsCredentialPropertiesModel),
        typeof(NotificationHubCreateOrUpdateParametersModel),
        typeof(NotificationHubPatchParametersModel),
        typeof(NotificationHubPropertiesModel),
        typeof(NotificationHubResourceModel),
        typeof(PnsCredentialsPropertiesModel),
        typeof(PnsCredentialsResourceModel),
        typeof(PolicykeyResourceModel),
        typeof(ResourceListKeysModel),
        typeof(SharedAccessAuthorizationRuleCreateOrUpdateParametersModel),
        typeof(SharedAccessAuthorizationRulePropertiesModel),
        typeof(SharedAccessAuthorizationRuleResourceModel),
        typeof(SkuModel),
        typeof(WnsCredentialModel),
        typeof(WnsCredentialPropertiesModel),
    };
}
