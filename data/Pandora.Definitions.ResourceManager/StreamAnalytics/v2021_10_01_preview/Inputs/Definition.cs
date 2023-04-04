using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Inputs;

internal class Definition : ResourceDefinition
{
    public string Name => "Inputs";
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
        typeof(CompressionTypeConstant),
        typeof(EncodingConstant),
        typeof(EventGridEventSchemaTypeConstant),
        typeof(EventSerializationTypeConstant),
        typeof(InputWatermarkModeConstant),
        typeof(JsonOutputSerializationFormatConstant),
        typeof(RefreshTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvroSerializationModel),
        typeof(AzureSqlReferenceInputDataSourceModel),
        typeof(AzureSqlReferenceInputDataSourcePropertiesModel),
        typeof(BlobReferenceInputDataSourceModel),
        typeof(BlobReferenceInputDataSourcePropertiesModel),
        typeof(BlobStreamInputDataSourceModel),
        typeof(BlobStreamInputDataSourcePropertiesModel),
        typeof(CompressionModel),
        typeof(CsvSerializationModel),
        typeof(CsvSerializationPropertiesModel),
        typeof(CustomClrSerializationModel),
        typeof(CustomClrSerializationPropertiesModel),
        typeof(DeltaSerializationModel),
        typeof(DeltaSerializationPropertiesModel),
        typeof(DiagnosticConditionModel),
        typeof(DiagnosticsModel),
        typeof(ErrorResponseModel),
        typeof(EventGridStreamInputDataSourceModel),
        typeof(EventGridStreamInputDataSourcePropertiesModel),
        typeof(EventHubStreamInputDataSourceModel),
        typeof(EventHubStreamInputDataSourcePropertiesModel),
        typeof(EventHubV2StreamInputDataSourceModel),
        typeof(FileReferenceInputDataSourceModel),
        typeof(FileReferenceInputDataSourcePropertiesModel),
        typeof(GatewayMessageBusSourcePropertiesModel),
        typeof(GatewayMessageBusStreamInputDataSourceModel),
        typeof(InputModel),
        typeof(InputPropertiesModel),
        typeof(InputWatermarkPropertiesModel),
        typeof(IoTHubStreamInputDataSourceModel),
        typeof(IoTHubStreamInputDataSourcePropertiesModel),
        typeof(JsonSerializationModel),
        typeof(JsonSerializationPropertiesModel),
        typeof(ParquetSerializationModel),
        typeof(RawInputDatasourcePropertiesModel),
        typeof(RawReferenceInputDataSourceModel),
        typeof(RawStreamInputDataSourceModel),
        typeof(ReferenceInputDataSourceModel),
        typeof(ReferenceInputPropertiesModel),
        typeof(ResourceTestStatusModel),
        typeof(SerializationModel),
        typeof(StorageAccountModel),
        typeof(StreamInputDataSourceModel),
        typeof(StreamInputPropertiesModel),
    };
}
