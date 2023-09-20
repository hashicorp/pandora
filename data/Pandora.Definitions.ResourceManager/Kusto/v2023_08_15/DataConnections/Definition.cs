using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.DataConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "DataConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DataConnectionValidationOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDatabaseOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BlobStorageEventTypeConstant),
        typeof(CompressionConstant),
        typeof(DataConnectionKindConstant),
        typeof(DataConnectionTypeConstant),
        typeof(DatabaseRoutingConstant),
        typeof(EventGridDataFormatConstant),
        typeof(EventHubDataFormatConstant),
        typeof(IotHubDataFormatConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameResultModel),
        typeof(CosmosDbDataConnectionModel),
        typeof(CosmosDbDataConnectionPropertiesModel),
        typeof(DataConnectionModel),
        typeof(DataConnectionCheckNameRequestModel),
        typeof(DataConnectionListResultModel),
        typeof(DataConnectionValidationModel),
        typeof(DataConnectionValidationListResultModel),
        typeof(DataConnectionValidationResultModel),
        typeof(EventGridConnectionPropertiesModel),
        typeof(EventGridDataConnectionModel),
        typeof(EventHubConnectionPropertiesModel),
        typeof(EventHubDataConnectionModel),
        typeof(IotHubConnectionPropertiesModel),
        typeof(IotHubDataConnectionModel),
    };
}
