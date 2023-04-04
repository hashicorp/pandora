using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPAvailabilityZoneDetails;

internal class Definition : ResourceDefinition
{
    public string Name => "SAPAvailabilityZoneDetails";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SAPAvailabilityZoneDetailsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SAPDatabaseTypeConstant),
        typeof(SAPProductTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SAPAvailabilityZoneDetailsRequestModel),
        typeof(SAPAvailabilityZoneDetailsResultModel),
        typeof(SAPAvailabilityZonePairModel),
    };
}
