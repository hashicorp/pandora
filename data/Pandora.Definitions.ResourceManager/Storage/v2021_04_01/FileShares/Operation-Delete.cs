using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;

internal class DeleteOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new ShareId();

    public override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    internal class DeleteOptions
    {
        [QueryStringName("$include")]
        [Optional]
        public string Include { get; set; }

        [HeaderName("x-ms-snapshot")]
        [Optional]
        public string XMsSnapshot { get; set; }
    }
}
