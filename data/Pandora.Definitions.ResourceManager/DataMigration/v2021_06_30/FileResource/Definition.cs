using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.FileResource;

internal class Definition : ResourceDefinition
{
    public string Name => "FileResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FilesDeleteOperation(),
        new FilesGetOperation(),
        new FilesListOperation(),
        new FilesReadOperation(),
        new FilesReadWriteOperation(),
        new FilesUpdateOperation(),
    };
}
