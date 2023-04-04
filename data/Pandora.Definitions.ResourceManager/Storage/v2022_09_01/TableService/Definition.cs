using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.TableService;

internal class Definition : ResourceDefinition
{
    public string Name => "TableService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TableCreateOperation(),
        new TableDeleteOperation(),
        new TableGetOperation(),
        new TableListOperation(),
        new TableUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TableModel),
        typeof(TableAccessPolicyModel),
        typeof(TablePropertiesModel),
        typeof(TableSignedIdentifierModel),
    };
}
