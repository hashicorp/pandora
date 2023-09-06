using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;

internal class Definition : ResourceDefinition
{
    public string Name => "DataConnectors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AvailabilityStatusConstant),
        typeof(ConnectivityTypeConstant),
        typeof(DataConnectorKindConstant),
        typeof(DataTypeStateConstant),
        typeof(PermissionProviderScopeConstant),
        typeof(PollingFrequencyConstant),
        typeof(ProviderNameConstant),
        typeof(SettingTypeConstant),
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
        typeof(ApiPollingParametersModel),
        typeof(AvailabilityModel),
        typeof(AwsCloudTrailDataConnectorModel),
        typeof(AwsCloudTrailDataConnectorDataTypesModel),
        typeof(AwsCloudTrailDataConnectorPropertiesModel),
        typeof(AwsS3DataConnectorModel),
        typeof(AwsS3DataConnectorDataTypesModel),
        typeof(AwsS3DataConnectorPropertiesModel),
        typeof(CodelessApiPollingDataConnectorModel),
        typeof(CodelessConnectorPollingAuthPropertiesModel),
        typeof(CodelessConnectorPollingConfigPropertiesModel),
        typeof(CodelessConnectorPollingPagingPropertiesModel),
        typeof(CodelessConnectorPollingRequestPropertiesModel),
        typeof(CodelessConnectorPollingResponsePropertiesModel),
        typeof(CodelessParametersModel),
        typeof(CodelessUiConnectorConfigPropertiesModel),
        typeof(CodelessUiDataConnectorModel),
        typeof(ConnectivityCriteriaModel),
        typeof(ConnectorInstructionModelBaseModel),
        typeof(CustomsPermissionModel),
        typeof(DataConnectorModel),
        typeof(DataConnectorDataTypeCommonModel),
        typeof(Dynamics365DataConnectorModel),
        typeof(Dynamics365DataConnectorDataTypesModel),
        typeof(Dynamics365DataConnectorPropertiesModel),
        typeof(GraphQueriesModel),
        typeof(InstructionStepsModel),
        typeof(IoTDataConnectorModel),
        typeof(IoTDataConnectorPropertiesModel),
        typeof(LastDataReceivedDataTypeModel),
        typeof(MCASDataConnectorModel),
        typeof(MCASDataConnectorDataTypesModel),
        typeof(MCASDataConnectorPropertiesModel),
        typeof(MDATPDataConnectorModel),
        typeof(MDATPDataConnectorPropertiesModel),
        typeof(MSTIDataConnectorModel),
        typeof(MSTIDataConnectorDataTypesModel),
        typeof(MSTIDataConnectorDataTypesBingSafetyPhishingURLModel),
        typeof(MSTIDataConnectorDataTypesMicrosoftEmergingThreatFeedModel),
        typeof(MSTIDataConnectorPropertiesModel),
        typeof(MTPDataConnectorModel),
        typeof(MTPDataConnectorDataTypesModel),
        typeof(MTPDataConnectorPropertiesModel),
        typeof(Office365ProjectConnectorDataTypesModel),
        typeof(Office365ProjectDataConnectorModel),
        typeof(Office365ProjectDataConnectorPropertiesModel),
        typeof(OfficeATPDataConnectorModel),
        typeof(OfficeATPDataConnectorPropertiesModel),
        typeof(OfficeDataConnectorModel),
        typeof(OfficeDataConnectorDataTypesModel),
        typeof(OfficeDataConnectorPropertiesModel),
        typeof(OfficeIRMDataConnectorModel),
        typeof(OfficeIRMDataConnectorPropertiesModel),
        typeof(OfficePowerBIConnectorDataTypesModel),
        typeof(OfficePowerBIDataConnectorModel),
        typeof(OfficePowerBIDataConnectorPropertiesModel),
        typeof(PermissionsModel),
        typeof(RequiredPermissionsModel),
        typeof(ResourceProviderModel),
        typeof(SampleQueriesModel),
        typeof(TIDataConnectorModel),
        typeof(TIDataConnectorDataTypesModel),
        typeof(TIDataConnectorPropertiesModel),
        typeof(TiTaxiiDataConnectorModel),
        typeof(TiTaxiiDataConnectorDataTypesModel),
        typeof(TiTaxiiDataConnectorPropertiesModel),
    };
}
