using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ShareId();

    public override Type? ResponseObject() => typeof(FileShareModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }

        [HeaderName("x-ms-snapshot")]
        [Optional]
        public string XMsSnapshot { get; set; }
    }
}
