using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreDataPlane;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(PacketCoreDataPlaneModel);

    public override ResourceID? ResourceId() => new PacketCoreDataPlaneId();

    public override Type? ResponseObject() => typeof(PacketCoreDataPlaneModel);


}
