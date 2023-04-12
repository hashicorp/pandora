using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

internal class UpdateExtendedInformationOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(DataBoxEdgeDeviceExtendedInfoPatchModel);

    public override ResourceID? ResourceId() => new DataBoxEdgeDeviceId();

    public override Type? ResponseObject() => typeof(DataBoxEdgeDeviceExtendedInfoModel);

    public override string? UriSuffix() => "/updateExtendedInformation";


}
