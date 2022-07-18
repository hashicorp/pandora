using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2022_05_31.Endpoints;

internal class DigitalTwinsEndpointCreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(DigitalTwinsEndpointResourceModel);

    public override ResourceID? ResourceId() => new EndpointId();

    public override Type? ResponseObject() => typeof(DigitalTwinsEndpointResourceModel);


}
