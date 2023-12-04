using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.RunbookDraft;

internal class ReplaceContentOperation : Pandora.Definitions.Operations.PutOperation
{
    public override string? ContentType() => "text/powershell";

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(CustomTypes.RawFile);

    public override ResourceID? ResourceId() => new RunbookId();

    public override string? UriSuffix() => "/draft/content";


}
