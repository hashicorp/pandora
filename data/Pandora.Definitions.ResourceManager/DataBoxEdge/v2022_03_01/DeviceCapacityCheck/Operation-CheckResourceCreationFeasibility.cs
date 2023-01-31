using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityCheck;

internal class CheckResourceCreationFeasibilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(DeviceCapacityRequestInfoModel);

    public override ResourceID? ResourceId() => new DataBoxEdgeDeviceId();

    public override Type? OptionsObject() => typeof(CheckResourceCreationFeasibilityOperation.CheckResourceCreationFeasibilityOptions);

    public override string? UriSuffix() => "/deviceCapacityCheck";

    internal class CheckResourceCreationFeasibilityOptions
    {
        [QueryStringName("capacityName")]
        [Optional]
        public string CapacityName { get; set; }
    }
}
