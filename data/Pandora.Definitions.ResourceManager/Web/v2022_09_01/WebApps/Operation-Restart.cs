using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

internal class RestartOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new AppServiceId();

    public override Type? OptionsObject() => typeof(RestartOperation.RestartOptions);

    public override string? UriSuffix() => "/restart";

    internal class RestartOptions
    {
        [QueryStringName("softRestart")]
        [Optional]
        public bool SoftRestart { get; set; }

        [QueryStringName("synchronous")]
        [Optional]
        public bool Synchronous { get; set; }
    }
}
