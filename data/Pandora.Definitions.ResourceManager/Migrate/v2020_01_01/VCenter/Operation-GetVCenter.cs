using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.VCenter;

internal class GetVCenterOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new VCenterId();

    public override Type? ResponseObject() => typeof(VCenterModel);


}
