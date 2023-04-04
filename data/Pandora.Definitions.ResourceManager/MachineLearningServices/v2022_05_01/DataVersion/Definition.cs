using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.DataVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "DataVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataTypeConstant),
        typeof(ListViewTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataVersionBaseModel),
        typeof(DataVersionBaseResourceModel),
        typeof(MLTableDataModel),
        typeof(UriFileDataVersionModel),
        typeof(UriFolderDataVersionModel),
    };
}
