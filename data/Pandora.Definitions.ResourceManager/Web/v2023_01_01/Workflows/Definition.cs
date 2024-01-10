using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Workflows;

internal class Definition : ResourceDefinition
{
    public string Name => "Workflows";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegenerateAccessKeyOperation(),
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KeyTypeConstant),
        typeof(KindConstant),
        typeof(OpenAuthenticationProviderTypeConstant),
        typeof(ParameterTypeConstant),
        typeof(WorkflowProvisioningStateConstant),
        typeof(WorkflowSkuNameConstant),
        typeof(WorkflowStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FlowAccessControlConfigurationModel),
        typeof(FlowAccessControlConfigurationPolicyModel),
        typeof(FlowEndpointsModel),
        typeof(FlowEndpointsConfigurationModel),
        typeof(IPAddressModel),
        typeof(IPAddressRangeModel),
        typeof(OpenAuthenticationAccessPoliciesModel),
        typeof(OpenAuthenticationAccessPolicyModel),
        typeof(OpenAuthenticationPolicyClaimModel),
        typeof(RegenerateActionParameterModel),
        typeof(ResourceReferenceModel),
        typeof(WorkflowModel),
        typeof(WorkflowParameterModel),
        typeof(WorkflowPropertiesModel),
        typeof(WorkflowSkuModel),
    };
}
