using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.Compute;

internal class RestorePointsGetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RestorePointId();

    public override Type? ResponseObject() => typeof(RestorePointModel);

    public override Type? OptionsObject() => typeof(RestorePointsGetOperation.RestorePointsGetOptions);

    internal class RestorePointsGetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public RestorePointExpandOptionsConstant Expand { get; set; }
    }
}
