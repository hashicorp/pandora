using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ExposureControl;

internal class Definition : ResourceDefinition
{
    public string Name => "ExposureControl";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetFeatureValueOperation(),
        new GetFeatureValueByFactoryOperation(),
        new QueryFeatureValuesByFactoryOperation(),
    };
}
