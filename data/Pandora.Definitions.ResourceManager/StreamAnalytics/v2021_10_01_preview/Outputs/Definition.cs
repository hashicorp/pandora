using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Outputs;

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
        typeof(BlobWriteModeConstant),
        typeof(EncodingConstant),
        typeof(EventSerializationTypeConstant),
        typeof(JsonOutputSerializationFormatConstant),
        typeof(OutputWatermarkModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvroSerializationModel),
        typeof(AzureDataExplorerOutputDataSourceModel),
        typeof(AzureDataExplorerOutputDataSourcePropertiesModel),
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
        typeof(CustomClrSerializationModel),
        typeof(CustomClrSerializationPropertiesModel),
        typeof(DeltaSerializationModel),
        typeof(DeltaSerializationPropertiesModel),
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
        typeof(LastOutputEventTimestampModel),
        typeof(OutputModel),
        typeof(OutputDataSourceModel),
        typeof(OutputPropertiesModel),
        typeof(OutputWatermarkPropertiesModel),
        typeof(ParquetSerializationModel),
        typeof(PostgreSQLDataSourcePropertiesModel),
        typeof(PostgreSQLOutputDataSourceModel),
        typeof(PowerBIOutputDataSourceModel),
        typeof(PowerBIOutputDataSourcePropertiesModel),
        typeof(RawOutputDatasourceModel),
        typeof(RawOutputDatasourcePropertiesModel),
        typeof(ResourceTestStatusModel),
        typeof(SerializationModel),
        typeof(ServiceBusQueueOutputDataSourceModel),
        typeof(ServiceBusQueueOutputDataSourcePropertiesModel),
        typeof(ServiceBusTopicOutputDataSourceModel),
        typeof(ServiceBusTopicOutputDataSourcePropertiesModel),
        typeof(StorageAccountModel),
    };
}
