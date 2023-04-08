using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolution;

internal class Definition : ResourceDefinition
{
    public string Name => "IoTSecuritySolution";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IotSecuritySolutionCreateOrUpdateOperation(),
        new IotSecuritySolutionDeleteOperation(),
        new IotSecuritySolutionGetOperation(),
        new IotSecuritySolutionListByResourceGroupOperation(),
        new IotSecuritySolutionListBySubscriptionOperation(),
        new IotSecuritySolutionUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdditionalWorkspaceDataTypeConstant),
        typeof(AdditionalWorkspaceTypeConstant),
        typeof(DataSourceConstant),
        typeof(ExportDataConstant),
        typeof(RecommendationConfigStatusConstant),
        typeof(RecommendationTypeConstant),
        typeof(SecuritySolutionStatusConstant),
        typeof(UnmaskedIPLoggingStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalWorkspacesPropertiesModel),
        typeof(IoTSecuritySolutionModelModel),
        typeof(IoTSecuritySolutionPropertiesModel),
        typeof(RecommendationConfigurationPropertiesModel),
        typeof(UpdateIoTSecuritySolutionPropertiesModel),
        typeof(UpdateIotSecuritySolutionDataModel),
        typeof(UserDefinedResourcesPropertiesModel),
    };
}
