using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByInstancePoolOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IdentityTypeConstant),
        typeof(ManagedInstanceLicenseTypeConstant),
        typeof(ManagedInstanceProxyOverrideConstant),
        typeof(ManagedServerCreateModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceModel),
        typeof(ManagedInstancePropertiesModel),
        typeof(ManagedInstanceUpdateModel),
        typeof(ResourceIdentityModel),
        typeof(SkuModel),
    };
}
