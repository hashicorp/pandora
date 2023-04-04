using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Outputs;

internal class Definition : ResourceDefinition
{
    public string Name => "Outputs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrReplaceOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByStreamingJobOperation(),
        new TestOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationModeConstant),
        typeof(EncodingConstant),
        typeof(EventSerializationTypeConstant),
        typeof(JsonOutputSerializationFormatConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvroSerializationModel),
        typeof(AzureDataLakeStoreOutputDataSourceModel),
        typeof(AzureDataLakeStoreOutputDataSourcePropertiesModel),
        typeof(AzureFunctionOutputDataSourceModel),
        typeof(AzureFunctionOutputDataSourcePropertiesModel),
        typeof(AzureSqlDatabaseDataSourcePropertiesModel),
        typeof(AzureSqlDatabaseOutputDataSourceModel),
        typeof(AzureSynapseDataSourcePropertiesModel),
        typeof(AzureSynapseOutputDataSourceModel),
        typeof(AzureTableOutputDataSourceModel),
        typeof(AzureTableOutputDataSourcePropertiesModel),
        typeof(BlobOutputDataSourceModel),
        typeof(BlobOutputDataSourcePropertiesModel),
        typeof(CsvSerializationModel),
        typeof(CsvSerializationPropertiesModel),
        typeof(DiagnosticConditionModel),
        typeof(DiagnosticsModel),
        typeof(DocumentDbOutputDataSourceModel),
        typeof(DocumentDbOutputDataSourcePropertiesModel),
        typeof(ErrorResponseModel),
        typeof(EventHubOutputDataSourceModel),
        typeof(EventHubOutputDataSourcePropertiesModel),
        typeof(EventHubV2OutputDataSourceModel),
        typeof(GatewayMessageBusOutputDataSourceModel),
        typeof(GatewayMessageBusSourcePropertiesModel),
        typeof(JsonSerializationModel),
        typeof(JsonSerializationPropertiesModel),
        typeof(OutputModel),
        typeof(OutputDataSourceModel),
        typeof(OutputPropertiesModel),
        typeof(ParquetSerializationModel),
        typeof(PowerBIOutputDataSourceModel),
        typeof(PowerBIOutputDataSourcePropertiesModel),
        typeof(ResourceTestStatusModel),
        typeof(SerializationModel),
        typeof(ServiceBusQueueOutputDataSourceModel),
        typeof(ServiceBusQueueOutputDataSourcePropertiesModel),
        typeof(ServiceBusTopicOutputDataSourceModel),
        typeof(ServiceBusTopicOutputDataSourcePropertiesModel),
        typeof(StorageAccountModel),
    };
}
