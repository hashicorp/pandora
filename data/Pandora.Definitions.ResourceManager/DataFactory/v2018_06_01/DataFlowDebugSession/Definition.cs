using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;

internal class Definition : ResourceDefinition
{
    public string Name => "DataFlowDebugSession";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddDataFlowOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new ExecuteCommandOperation(),
        new QueryByFactoryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataFlowDebugCommandTypeConstant),
        typeof(IntegrationRuntimeTypeConstant),
        typeof(ParameterTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddDataFlowToDebugSessionResponseModel),
        typeof(CreateDataFlowDebugSessionRequestModel),
        typeof(CreateDataFlowDebugSessionResponseModel),
        typeof(DataFlowModel),
        typeof(DataFlowDebugCommandPayloadModel),
        typeof(DataFlowDebugCommandRequestModel),
        typeof(DataFlowDebugCommandResponseModel),
        typeof(DataFlowDebugPackageModel),
        typeof(DataFlowDebugPackageDebugSettingsModel),
        typeof(DataFlowDebugResourceModel),
        typeof(DataFlowDebugSessionInfoModel),
        typeof(DataFlowFolderModel),
        typeof(DataFlowSourceSettingModel),
        typeof(DataFlowStagingInfoModel),
        typeof(DatasetModel),
        typeof(DatasetDebugResourceModel),
        typeof(DatasetFolderModel),
        typeof(DeleteDataFlowDebugSessionRequestModel),
        typeof(IntegrationRuntimeModel),
        typeof(IntegrationRuntimeDebugResourceModel),
        typeof(IntegrationRuntimeReferenceModel),
        typeof(LinkedServiceModel),
        typeof(LinkedServiceDebugResourceModel),
        typeof(LinkedServiceReferenceModel),
        typeof(ParameterSpecificationModel),
        typeof(ReferenceModel),
    };
}
