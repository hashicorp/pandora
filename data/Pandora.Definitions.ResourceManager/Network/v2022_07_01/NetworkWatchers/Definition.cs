using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkWatchers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckConnectivityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAzureReachabilityReportOperation(),
        new GetFlowLogStatusOperation(),
        new GetNetworkConfigurationDiagnosticOperation(),
        new GetNextHopOperation(),
        new GetTopologyOperation(),
        new GetTroubleshootingOperation(),
        new GetTroubleshootingResultOperation(),
        new GetVMSecurityRulesOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAvailableProvidersOperation(),
        new SetFlowLogConfigurationOperation(),
        new UpdateTagsOperation(),
        new VerifyIPFlowOperation(),
    };
}
