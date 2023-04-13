using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_01_01.DppFeatureSupport;

internal class DataProtectionCheckFeatureSupportOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(FeatureValidationRequestBaseModel);

    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(FeatureValidationResponseBaseModel);

    public override string? UriSuffix() => "/checkFeatureSupport";


}
