using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.Volumes;

internal class Definition : ResourceDefinition
{
    public string Name => "Volumes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByVolumeGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationalStatusConstant),
        typeof(ProvisioningStatesConstant),
        typeof(VolumeCreateOptionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IscsiTargetInfoModel),
        typeof(SourceCreationDataModel),
        typeof(VolumeModel),
        typeof(VolumePropertiesModel),
        typeof(VolumeUpdateModel),
        typeof(VolumeUpdatePropertiesModel),
    };
}
