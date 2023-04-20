using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IotSecuritySolutions;

internal class Definition : ResourceDefinition
{
    public string Name => "IotSecuritySolutions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IoTSecuritySolutionsListOperation(),
        new IoTSecuritySolutionsResourceGroupListOperation(),
        new IotSecuritySolutionCreateOperation(),
        new IotSecuritySolutionDeleteOperation(),
        new IotSecuritySolutionGetOperation(),
        new IotSecuritySolutionUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSourceConstant),
        typeof(ExportDataConstant),
        typeof(RecommendationConfigStatusConstant),
        typeof(RecommendationTypeConstant),
        typeof(SecuritySolutionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IoTSecuritySolutionModelModel),
        typeof(IoTSecuritySolutionPropertiesModel),
        typeof(RecommendationConfigurationPropertiesModel),
        typeof(UpdateIotSecuritySolutionDataModel),
        typeof(UserDefinedResourcesPropertiesModel),
    };
}
