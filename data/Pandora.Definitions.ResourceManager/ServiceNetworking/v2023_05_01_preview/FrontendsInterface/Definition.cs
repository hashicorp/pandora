using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceNetworking.v2023_05_01_preview.FrontendsInterface;

internal class Definition : ResourceDefinition
{
    public string Name => "FrontendsInterface";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByTrafficControllerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FrontendModel),
        typeof(FrontendPropertiesModel),
        typeof(FrontendUpdateModel),
    };
}
