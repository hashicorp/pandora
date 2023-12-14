using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.EnvironmentTypes;

internal class Definition : ResourceDefinition
{
    public string Name => "EnvironmentTypes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EnvironmentTypesCreateOrUpdateOperation(),
        new EnvironmentTypesDeleteOperation(),
        new EnvironmentTypesGetOperation(),
        new EnvironmentTypesListByDevCenterOperation(),
        new EnvironmentTypesUpdateOperation(),
        new ProjectAllowedEnvironmentTypesGetOperation(),
        new ProjectAllowedEnvironmentTypesListOperation(),
        new ProjectEnvironmentTypesCreateOrUpdateOperation(),
        new ProjectEnvironmentTypesDeleteOperation(),
        new ProjectEnvironmentTypesGetOperation(),
        new ProjectEnvironmentTypesListOperation(),
        new ProjectEnvironmentTypesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnvironmentTypeEnableStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AllowedEnvironmentTypeModel),
        typeof(AllowedEnvironmentTypePropertiesModel),
        typeof(EnvironmentRoleModel),
        typeof(EnvironmentTypeModel),
        typeof(EnvironmentTypePropertiesModel),
        typeof(EnvironmentTypeUpdateModel),
        typeof(ProjectEnvironmentTypeModel),
        typeof(ProjectEnvironmentTypePropertiesModel),
        typeof(ProjectEnvironmentTypeUpdateModel),
        typeof(ProjectEnvironmentTypeUpdatePropertiesModel),
        typeof(ProjectEnvironmentTypeUpdatePropertiesCreatorRoleAssignmentModel),
        typeof(UserRoleAssignmentModel),
    };
}
