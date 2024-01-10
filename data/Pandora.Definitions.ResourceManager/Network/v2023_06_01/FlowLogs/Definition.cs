using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.FlowLogs;

internal class Definition : ResourceDefinition
{
    public string Name => "FlowLogs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FlowLogFormatTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FlowLogModel),
        typeof(FlowLogFormatParametersModel),
        typeof(FlowLogPropertiesFormatModel),
        typeof(RetentionPolicyParametersModel),
        typeof(TagsObjectModel),
        typeof(TrafficAnalyticsConfigurationPropertiesModel),
        typeof(TrafficAnalyticsPropertiesModel),
    };
}
