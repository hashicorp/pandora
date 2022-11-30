using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.StreamingPoliciesAndStreamingLocators;

internal class Definition : ResourceDefinition
{
    public string Name => "StreamingPoliciesAndStreamingLocators";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new StreamingLocatorsCreateOperation(),
        new StreamingLocatorsDeleteOperation(),
        new StreamingLocatorsGetOperation(),
        new StreamingLocatorsListOperation(),
        new StreamingLocatorsListContentKeysOperation(),
        new StreamingLocatorsListPathsOperation(),
        new StreamingPoliciesCreateOperation(),
        new StreamingPoliciesDeleteOperation(),
        new StreamingPoliciesGetOperation(),
        new StreamingPoliciesListOperation(),
    };
}
