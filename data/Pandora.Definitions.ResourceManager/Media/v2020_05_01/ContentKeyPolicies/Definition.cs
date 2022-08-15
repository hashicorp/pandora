using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.ContentKeyPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ContentKeyPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContentKeyPoliciesCreateOrUpdateOperation(),
        new ContentKeyPoliciesDeleteOperation(),
        new ContentKeyPoliciesGetOperation(),
        new ContentKeyPoliciesGetPolicyPropertiesWithSecretsOperation(),
        new ContentKeyPoliciesListOperation(),
        new ContentKeyPoliciesUpdateOperation(),
    };
}
