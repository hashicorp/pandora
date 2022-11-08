using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.DeploymentScripts;

internal class GetLogsDefaultOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DeploymentScriptId();

    public override Type? ResponseObject() => typeof(ScriptLogModel);

    public override Type? OptionsObject() => typeof(GetLogsDefaultOperation.GetLogsDefaultOptions);

    public override string? UriSuffix() => "/logs/default";

    internal class GetLogsDefaultOptions
    {
        [QueryStringName("tail")]
        [Optional]
        public int Tail { get; set; }
    }
}
