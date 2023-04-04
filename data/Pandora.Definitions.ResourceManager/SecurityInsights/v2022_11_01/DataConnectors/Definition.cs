using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.DataConnectors;

internal class Definition : ResourceDefinition
{
    public string Name => "DataConnectors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DataConnectorsCreateOrUpdateOperation(),
        new DataConnectorsDeleteOperation(),
        new DataConnectorsGetOperation(),
        new DataConnectorsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataConnectorKindConstant),
        typeof(DataTypeStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AADDataConnectorModel),
        typeof(AADDataConnectorPropertiesModel),
        typeof(AATPDataConnectorModel),
        typeof(AATPDataConnectorPropertiesModel),
        typeof(ASCDataConnectorModel),
        typeof(ASCDataConnectorPropertiesModel),
        typeof(AlertsDataTypeOfDataConnectorModel),
        typeof(AwsCloudTrailDataConnectorModel),
        typeof(AwsCloudTrailDataConnectorDataTypesModel),
        typeof(AwsCloudTrailDataConnectorPropertiesModel),
        typeof(DataConnectorModel),
        typeof(DataConnectorDataTypeCommonModel),
        typeof(MCASDataConnectorModel),
        typeof(MCASDataConnectorDataTypesModel),
        typeof(MCASDataConnectorPropertiesModel),
        typeof(MDATPDataConnectorModel),
        typeof(MDATPDataConnectorPropertiesModel),
        typeof(OfficeDataConnectorModel),
        typeof(OfficeDataConnectorDataTypesModel),
        typeof(OfficeDataConnectorPropertiesModel),
        typeof(TIDataConnectorModel),
        typeof(TIDataConnectorDataTypesModel),
        typeof(TIDataConnectorPropertiesModel),
    };
}
