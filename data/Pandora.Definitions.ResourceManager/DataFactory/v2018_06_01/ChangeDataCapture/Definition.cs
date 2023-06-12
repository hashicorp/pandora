using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;

internal class Definition : ResourceDefinition
{
    public string Name => "ChangeDataCapture";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByFactoryOperation(),
        new StartOperation(),
        new StatusOperation(),
        new StopOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionTypeConstant),
        typeof(FrequencyTypeConstant),
        typeof(MappingTypeConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ChangeDataCaptureModel),
        typeof(ChangeDataCaptureFolderModel),
        typeof(ChangeDataCaptureResourceModel),
        typeof(DataMapperMappingModel),
        typeof(LinkedServiceReferenceModel),
        typeof(MapperAttributeMappingModel),
        typeof(MapperAttributeMappingsModel),
        typeof(MapperAttributeReferenceModel),
        typeof(MapperConnectionModel),
        typeof(MapperConnectionReferenceModel),
        typeof(MapperDslConnectorPropertiesModel),
        typeof(MapperPolicyModel),
        typeof(MapperPolicyRecurrenceModel),
        typeof(MapperSourceConnectionsInfoModel),
        typeof(MapperTableModel),
        typeof(MapperTablePropertiesModel),
        typeof(MapperTableSchemaModel),
        typeof(MapperTargetConnectionsInfoModel),
    };
}
