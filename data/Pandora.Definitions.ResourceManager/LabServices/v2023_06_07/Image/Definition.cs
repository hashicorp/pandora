using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.Image;

internal class Definition : ResourceDefinition
{
    public string Name => "Image";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByLabPlanOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnableStateConstant),
        typeof(OsStateConstant),
        typeof(OsTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ImageModel),
        typeof(ImagePropertiesModel),
        typeof(ImageUpdateModel),
        typeof(ImageUpdatePropertiesModel),
    };
}
