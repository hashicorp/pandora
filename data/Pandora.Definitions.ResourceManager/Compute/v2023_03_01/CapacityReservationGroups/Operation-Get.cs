using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.CapacityReservationGroups;

internal class GetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new CapacityReservationGroupId();

    public override Type? ResponseObject() => typeof(CapacityReservationGroupModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public CapacityReservationGroupInstanceViewTypesConstant Expand { get; set; }
    }
}
