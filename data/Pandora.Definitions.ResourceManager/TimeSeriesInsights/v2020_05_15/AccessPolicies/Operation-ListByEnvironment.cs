using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.AccessPolicies;

internal class ListByEnvironmentOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new EnvironmentId();

    public override Type? ResponseObject() => typeof(AccessPolicyListResponseModel);

    public override string? UriSuffix() => "/accessPolicies";


}
