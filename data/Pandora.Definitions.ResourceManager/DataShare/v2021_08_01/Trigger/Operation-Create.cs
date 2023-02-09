using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Trigger;

internal class CreateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(TriggerModel);

    public override ResourceID? ResourceId() => new TriggerId();

    public override Type? ResponseObject() => typeof(TriggerModel);


}
