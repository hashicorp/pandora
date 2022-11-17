using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Scripts;

internal class ScriptExecutionsGetExecutionLogsOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(List<ScriptOutputStreamTypeConstant>);

    public override ResourceID? ResourceId() => new ScriptExecutionId();

    public override Type? ResponseObject() => typeof(ScriptExecutionModel);

    public override string? UriSuffix() => "/getExecutionLogs";


}
