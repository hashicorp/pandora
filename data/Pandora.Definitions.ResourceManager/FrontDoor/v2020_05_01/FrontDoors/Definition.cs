using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;

internal class Definition : ResourceDefinition
{
    public string Name => "FrontDoors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new EndpointsPurgeContentOperation(),
        new FrontendEndpointsDisableHTTPSOperation(),
        new FrontendEndpointsEnableHTTPSOperation(),
        new FrontendEndpointsGetOperation(),
        new FrontendEndpointsListByFrontDoorOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RulesEnginesCreateOrUpdateOperation(),
        new RulesEnginesDeleteOperation(),
        new RulesEnginesGetOperation(),
        new RulesEnginesListByFrontDoorOperation(),
        new ValidateCustomDomainOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackendEnabledStateConstant),
        typeof(CustomHTTPSProvisioningStateConstant),
        typeof(CustomHTTPSProvisioningSubstateConstant),
        typeof(DynamicCompressionEnabledConstant),
        typeof(EnforceCertificateNameCheckEnabledStateConstant),
        typeof(FrontDoorCertificateSourceConstant),
        typeof(FrontDoorCertificateTypeConstant),
        typeof(FrontDoorEnabledStateConstant),
        typeof(FrontDoorForwardingProtocolConstant),
        typeof(FrontDoorHealthProbeMethodConstant),
        typeof(FrontDoorProtocolConstant),
        typeof(FrontDoorQueryConstant),
        typeof(FrontDoorRedirectProtocolConstant),
        typeof(FrontDoorRedirectTypeConstant),
        typeof(FrontDoorResourceStateConstant),
        typeof(FrontDoorTlsProtocolTypeConstant),
        typeof(HeaderActionTypeConstant),
        typeof(HealthProbeEnabledConstant),
        typeof(MatchProcessingBehaviorConstant),
        typeof(MinimumTLSVersionConstant),
        typeof(PrivateEndpointStatusConstant),
        typeof(RoutingRuleEnabledStateConstant),
        typeof(RulesEngineMatchVariableConstant),
        typeof(RulesEngineOperatorConstant),
        typeof(SessionAffinityEnabledStateConstant),
        typeof(TransformConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackendModel),
        typeof(BackendPoolModel),
        typeof(BackendPoolPropertiesModel),
        typeof(BackendPoolsSettingsModel),
        typeof(CacheConfigurationModel),
        typeof(CustomHTTPSConfigurationModel),
        typeof(ForwardingConfigurationModel),
        typeof(FrontDoorModel),
        typeof(FrontDoorCertificateSourceParametersModel),
        typeof(FrontDoorPropertiesModel),
        typeof(FrontendEndpointModel),
        typeof(FrontendEndpointPropertiesModel),
        typeof(FrontendEndpointUpdateParametersWebApplicationFirewallPolicyLinkModel),
        typeof(HeaderActionModel),
        typeof(HealthProbeSettingsModelModel),
        typeof(HealthProbeSettingsPropertiesModel),
        typeof(KeyVaultCertificateSourceParametersModel),
        typeof(KeyVaultCertificateSourceParametersVaultModel),
        typeof(LoadBalancingSettingsModelModel),
        typeof(LoadBalancingSettingsPropertiesModel),
        typeof(PurgeParametersModel),
        typeof(RedirectConfigurationModel),
        typeof(RouteConfigurationModel),
        typeof(RoutingRuleModel),
        typeof(RoutingRulePropertiesModel),
        typeof(RoutingRuleUpdateParametersWebApplicationFirewallPolicyLinkModel),
        typeof(RulesEngineModel),
        typeof(RulesEngineActionModel),
        typeof(RulesEngineMatchConditionModel),
        typeof(RulesEnginePropertiesModel),
        typeof(RulesEngineRuleModel),
        typeof(SubResourceModel),
        typeof(ValidateCustomDomainInputModel),
        typeof(ValidateCustomDomainOutputModel),
    };
}
