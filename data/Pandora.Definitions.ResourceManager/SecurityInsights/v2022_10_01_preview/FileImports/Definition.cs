using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;

internal class Definition : ResourceDefinition
{
    public string Name => "FileImports";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DeleteStatusConstant),
        typeof(FileFormatConstant),
        typeof(FileImportContentTypeConstant),
        typeof(FileImportStateConstant),
        typeof(IngestionModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FileImportModel),
        typeof(FileImportPropertiesModel),
        typeof(FileMetadataModel),
        typeof(ValidationErrorModel),
    };
}
