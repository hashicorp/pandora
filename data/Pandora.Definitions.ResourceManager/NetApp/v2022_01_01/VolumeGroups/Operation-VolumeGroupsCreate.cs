using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.VolumeGroups;

internal class VolumeGroupsCreateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(VolumeGroupDetailsModel);

    public override ResourceID? ResourceId() => new VolumeGroupId();

    public override Type? ResponseObject() => typeof(VolumeGroupDetailsModel);


}
