using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.DiskEncryptionSets;

internal class Definition : ResourceDefinition
{
    public string Name => "DiskEncryptionSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAssociatedResourcesOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiskEncryptionSetTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiErrorModel),
        typeof(ApiErrorBaseModel),
        typeof(DiskEncryptionSetModel),
        typeof(DiskEncryptionSetUpdateModel),
        typeof(DiskEncryptionSetUpdatePropertiesModel),
        typeof(EncryptionSetPropertiesModel),
        typeof(InnerErrorModel),
        typeof(KeyForDiskEncryptionSetModel),
        typeof(SourceVaultModel),
    };
}
