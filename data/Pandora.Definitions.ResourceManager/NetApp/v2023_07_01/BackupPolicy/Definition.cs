using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.BackupPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupPolicy";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BackupPoliciesCreateOperation(),
        new BackupPoliciesDeleteOperation(),
        new BackupPoliciesGetOperation(),
        new BackupPoliciesListOperation(),
        new BackupPoliciesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupPoliciesListModel),
        typeof(BackupPolicyModel),
        typeof(BackupPolicyPatchModel),
        typeof(BackupPolicyPropertiesModel),
        typeof(VolumeBackupsModel),
    };
}
