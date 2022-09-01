using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

internal class Definition : ResourceDefinition
{
    public string Name => "Encodings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new JobsCancelJobOperation(),
        new JobsCreateOperation(),
        new JobsDeleteOperation(),
        new JobsGetOperation(),
        new JobsListOperation(),
        new JobsUpdateOperation(),
        new TransformsCreateOrUpdateOperation(),
        new TransformsDeleteOperation(),
        new TransformsGetOperation(),
        new TransformsListOperation(),
        new TransformsUpdateOperation(),
    };
}
