using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.SubVolumes;

internal class Definition : ResourceDefinition
{
    public string Name => "SubVolumes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetMetadataOperation(),
        new ListByVolumeOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SubvolumeInfoModel),
        typeof(SubvolumeModelModel),
        typeof(SubvolumeModelPropertiesModel),
        typeof(SubvolumePatchParamsModel),
        typeof(SubvolumePatchRequestModel),
        typeof(SubvolumePropertiesModel),
    };
}
