using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedServerDnsAliases;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedServerDnsAliases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AcquireOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByManagedInstanceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedServerDnsAliasModel),
        typeof(ManagedServerDnsAliasAcquisitionModel),
        typeof(ManagedServerDnsAliasCreationModel),
        typeof(ManagedServerDnsAliasPropertiesModel),
    };
}
