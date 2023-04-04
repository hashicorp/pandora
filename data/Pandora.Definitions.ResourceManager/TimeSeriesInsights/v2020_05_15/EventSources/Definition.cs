using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.EventSources;

internal class Definition : ResourceDefinition
{
    public string Name => "EventSources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByEnvironmentOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EventSourceKindConstant),
        typeof(IngressStartAtTypeConstant),
        typeof(KindConstant),
        typeof(LocalTimestampFormatConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EventHubEventSourceCommonPropertiesModel),
        typeof(EventHubEventSourceCreateOrUpdateParametersModel),
        typeof(EventHubEventSourceCreationPropertiesModel),
        typeof(EventHubEventSourceMutablePropertiesModel),
        typeof(EventHubEventSourceResourceModel),
        typeof(EventHubEventSourceUpdateParametersModel),
        typeof(EventSourceCreateOrUpdateParametersModel),
        typeof(EventSourceListResponseModel),
        typeof(EventSourceResourceModel),
        typeof(EventSourceUpdateParametersModel),
        typeof(IngressStartAtPropertiesModel),
        typeof(IoTHubEventSourceCommonPropertiesModel),
        typeof(IoTHubEventSourceCreateOrUpdateParametersModel),
        typeof(IoTHubEventSourceCreationPropertiesModel),
        typeof(IoTHubEventSourceMutablePropertiesModel),
        typeof(IoTHubEventSourceResourceModel),
        typeof(IoTHubEventSourceUpdateParametersModel),
        typeof(LocalTimestampModel),
        typeof(LocalTimestampTimeZoneOffsetModel),
    };
}
