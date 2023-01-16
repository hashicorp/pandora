using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.NotificationChannels;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(NotificationChannelModel);

    public override ResourceID? ResourceId() => new NotificationChannelId();

    public override Type? ResponseObject() => typeof(NotificationChannelModel);


}
