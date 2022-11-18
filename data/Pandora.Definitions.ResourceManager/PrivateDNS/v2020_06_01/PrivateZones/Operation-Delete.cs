using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2020_06_01.PrivateZones;

internal class DeleteOperation : Operations.DeleteOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

\t\tpublic override ResourceID? ResourceId() => new PrivateDnsZoneId();

\t\tpublic override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    internal class DeleteOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
