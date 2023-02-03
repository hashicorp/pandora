using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVSites;

internal class PatchSiteOperation : Operations.PatchOperation
{
    public override Type? RequestObject() => typeof(HyperVSiteModel);

    public override ResourceID? ResourceId() => new HyperVSiteId();

    public override Type? ResponseObject() => typeof(HyperVSiteModel);


}
