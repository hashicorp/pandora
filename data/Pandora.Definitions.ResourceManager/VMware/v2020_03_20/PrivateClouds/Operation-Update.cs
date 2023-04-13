using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(PrivateCloudUpdateModel);

    public override ResourceID? ResourceId() => new PrivateCloudId();

    public override Type? ResponseObject() => typeof(PrivateCloudModel);


}
