using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowVersions;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowVersions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
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
        typeof(ResourceReferenceModel),
        typeof(WorkflowParameterModel),
        typeof(WorkflowSkuModel),
        typeof(WorkflowVersionModel),
        typeof(WorkflowVersionPropertiesModel),
    };
}
