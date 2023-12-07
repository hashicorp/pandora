using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.Location;

internal class Definition : ResourceDefinition
{
    public string Name => "Location";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetQuotasOperation(),
        new ListSupportedCloudServiceSkusOperation(),
        new ListSupportedVirtualMachineSkusOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BatchLocationQuotaModel),
        typeof(SkuCapabilityModel),
        typeof(SupportedSkuModel),
    };
}
