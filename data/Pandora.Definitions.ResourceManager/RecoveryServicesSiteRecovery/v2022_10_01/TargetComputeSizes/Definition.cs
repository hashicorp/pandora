using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.TargetComputeSizes;

internal class Definition : ResourceDefinition
{
    public string Name => "TargetComputeSizes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByReplicationProtectedItemsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ComputeSizeErrorDetailsModel),
        typeof(TargetComputeSizeModel),
        typeof(TargetComputeSizePropertiesModel),
    };
}
