using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.RunbookDraft;

internal class GetContentOperation : Operations.GetOperation
{
    public override string? ContentType() => "text/powershell";

    public override ResourceID? ResourceId() => new RunbookId();

    public override Type? ResponseObject() => typeof(string);

    public override string? UriSuffix() => "/draft/content";


}
