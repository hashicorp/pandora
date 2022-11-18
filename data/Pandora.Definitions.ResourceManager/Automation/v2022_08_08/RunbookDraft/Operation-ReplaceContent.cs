using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.RunbookDraft;

internal class ReplaceContentOperation : Operations.PutOperation
{
\t\tpublic override string? ContentType() => "text/powershell";

\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(object);

\t\tpublic override ResourceID? ResourceId() => new RunbookId();

\t\tpublic override Type? ResponseObject() => typeof(CustomTypes.RawFile);

\t\tpublic override string? UriSuffix() => "/draft/content";


}
