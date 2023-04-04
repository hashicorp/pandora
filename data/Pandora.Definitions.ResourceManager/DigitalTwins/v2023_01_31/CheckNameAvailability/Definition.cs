using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.CheckNameAvailability;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckNameAvailability";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DigitalTwinsCheckNameAvailabilityOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReasonConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameRequestModel),
        typeof(CheckNameResultModel),
    };
}
