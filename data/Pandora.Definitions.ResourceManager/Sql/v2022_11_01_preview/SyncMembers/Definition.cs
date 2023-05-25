using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.SyncMembers;

internal class Definition : ResourceDefinition
{
    public string Name => "SyncMembers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListBySyncGroupOperation(),
        new ListMemberSchemasOperation(),
        new RefreshMemberSchemaOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SyncDirectionConstant),
        typeof(SyncMemberDbTypeConstant),
        typeof(SyncMemberStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SyncFullSchemaPropertiesModel),
        typeof(SyncFullSchemaTableModel),
        typeof(SyncFullSchemaTableColumnModel),
        typeof(SyncMemberModel),
        typeof(SyncMemberPropertiesModel),
    };
}
