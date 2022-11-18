using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SignalR.v2022_02_01.SignalR;

internal class SharedPrivateLinkResourcesCreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SharedPrivateLinkResourceModel);

\t\tpublic override ResourceID? ResourceId() => new SharedPrivateLinkResourceId();

\t\tpublic override Type? ResponseObject() => typeof(SharedPrivateLinkResourceModel);


}
