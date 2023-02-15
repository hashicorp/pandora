using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.UserConfirmationPasswordSend;

internal class UserConfirmationPasswordSendOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new UserId();

    public override Type? OptionsObject() => typeof(UserConfirmationPasswordSendOperation.UserConfirmationPasswordSendOptions);

    public override string? UriSuffix() => "/confirmations/password/send";

    internal class UserConfirmationPasswordSendOptions
    {
        [QueryStringName("appType")]
        [Optional]
        public AppTypeConstant AppType { get; set; }
    }
}
