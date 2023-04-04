using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationStorageClassificationMappings;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationStorageClassificationMappings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationStorageClassificationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(StorageClassificationMappingModel),
        typeof(StorageClassificationMappingInputModel),
        typeof(StorageClassificationMappingPropertiesModel),
        typeof(StorageMappingInputPropertiesModel),
    };
}
