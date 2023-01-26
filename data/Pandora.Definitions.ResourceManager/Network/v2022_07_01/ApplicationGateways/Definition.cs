using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BackendHealthOperation(),
        new BackendHealthOnDemandOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetSslPredefinedPolicyOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAvailableRequestHeadersOperation(),
        new ListAvailableResponseHeadersOperation(),
        new ListAvailableServerVariablesOperation(),
        new ListAvailableSslOptionsOperation(),
        new ListAvailableSslPredefinedPoliciesOperation(),
        new ListAvailableWafRuleSetsOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateTagsOperation(),
    };
}
