using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.BatchManagements;

internal class Definition : ResourceDefinition
{
    public string Name => "BatchManagements";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BatchAccountGetDetectorOperation(),
        new BatchAccountListDetectorsOperation(),
        new LocationCheckNameAvailabilityOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NameAvailabilityReasonConstant),
        typeof(ResourceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityParametersModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(DetectorResponseModel),
        typeof(DetectorResponsePropertiesModel),
    };
}
