using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LedgerDigestUploads;

internal class Definition : ResourceDefinition
{
    public string Name => "LedgerDigestUploads";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DisableOperation(),
        new GetOperation(),
        new ListByDatabaseOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LedgerDigestUploadsStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LedgerDigestUploadsModel),
        typeof(LedgerDigestUploadsPropertiesModel),
    };
}
