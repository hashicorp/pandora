using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.Workflows;

internal class Definition : ResourceDefinition
{
    public string Name => "Workflows";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DisableOperation(),
        new EnableOperation(),
        new GenerateUpgradedDefinitionOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCallbackUrlOperation(),
        new ListSwaggerOperation(),
        new MoveOperation(),
        new RegenerateAccessKeyOperation(),
        new UpdateOperation(),
        new ValidateByLocationOperation(),
        new ValidateByResourceGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KeyTypeConstant),
        typeof(OpenAuthenticationProviderTypeConstant),
        typeof(ParameterTypeConstant),
        typeof(SkuNameConstant),
        typeof(WorkflowProvisioningStateConstant),
        typeof(WorkflowStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FlowAccessControlConfigurationModel),
        typeof(FlowAccessControlConfigurationPolicyModel),
        typeof(FlowEndpointsModel),
        typeof(FlowEndpointsConfigurationModel),
        typeof(GenerateUpgradedDefinitionParametersModel),
        typeof(GetCallbackUrlParametersModel),
        typeof(IPAddressModel),
        typeof(IPAddressRangeModel),
        typeof(OpenAuthenticationAccessPoliciesModel),
        typeof(OpenAuthenticationAccessPolicyModel),
        typeof(OpenAuthenticationPolicyClaimModel),
        typeof(RegenerateActionParameterModel),
        typeof(ResourceReferenceModel),
        typeof(SkuModel),
        typeof(WorkflowModel),
        typeof(WorkflowParameterModel),
        typeof(WorkflowPropertiesModel),
        typeof(WorkflowReferenceModel),
        typeof(WorkflowTriggerCallbackUrlModel),
        typeof(WorkflowTriggerListCallbackUrlQueriesModel),
    };
}
