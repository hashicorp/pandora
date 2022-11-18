using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;

internal class UpdateOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SessionHostPatchModel);

\t\tpublic override ResourceID? ResourceId() => new SessionHostId();

\t\tpublic override Type? ResponseObject() => typeof(SessionHostModel);

\t\tpublic override Type? OptionsObject() => typeof(UpdateOperation.UpdateOptions);

    internal class UpdateOptions
    {
        [QueryStringName("force")]
        [Optional]
        public bool Force { get; set; }
    }
}
