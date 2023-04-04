using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.LoadTests;

internal class Definition : ResourceDefinition
{
    public string Name => "LoadTests";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ResourceStateConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EncryptionPropertiesModel),
        typeof(EncryptionPropertiesIdentityModel),
        typeof(LoadTestPropertiesModel),
        typeof(LoadTestResourceModel),
        typeof(LoadTestResourcePatchRequestBodyModel),
        typeof(LoadTestResourcePatchRequestBodyPropertiesModel),
    };
}
