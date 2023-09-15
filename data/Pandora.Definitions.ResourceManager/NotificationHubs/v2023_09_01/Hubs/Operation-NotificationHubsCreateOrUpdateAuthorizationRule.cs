using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Hubs;

internal class NotificationHubsCreateOrUpdateAuthorizationRuleOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SharedAccessAuthorizationRuleResourceModel);

    public override ResourceID? ResourceId() => new NotificationHubAuthorizationRuleId();

    public override Type? ResponseObject() => typeof(SharedAccessAuthorizationRuleResourceModel);


}
