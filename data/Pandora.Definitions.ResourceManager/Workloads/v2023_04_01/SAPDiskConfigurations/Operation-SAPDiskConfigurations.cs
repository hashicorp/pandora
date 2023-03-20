using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDiskConfigurations;

internal class SAPDiskConfigurationsOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SAPDiskConfigurationsRequestModel);

    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(SAPDiskConfigurationsResultModel);

    public override string? UriSuffix() => "/sapVirtualInstanceMetadata/default/getDiskConfigurations";


}
