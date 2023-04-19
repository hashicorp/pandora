using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Tenants;

internal class Definition : ResourceDefinition
{
    public string Name => "Tenants";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckResourceNameOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ResourceNameStatusConstant),
        typeof(TenantCategoryConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckResourceNameResultModel),
        typeof(ResourceNameModel),
        typeof(TenantIdDescriptionModel),
    };
}
