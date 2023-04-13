using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.Spacecraft;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SpacecraftModel);

    public override ResourceID? ResourceId() => new SpacecraftId();

    public override Type? ResponseObject() => typeof(SpacecraftModel);


}
