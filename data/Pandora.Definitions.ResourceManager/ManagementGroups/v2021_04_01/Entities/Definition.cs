using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.Entities;

internal class Definition : ResourceDefinition
{
    public string Name => "Entities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EntitySearchTypeConstant),
        typeof(EntityViewParameterTypeConstant),
        typeof(PermissionsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EntityInfoModel),
        typeof(EntityInfoPropertiesModel),
        typeof(EntityParentGroupInfoModel),
    };
}
