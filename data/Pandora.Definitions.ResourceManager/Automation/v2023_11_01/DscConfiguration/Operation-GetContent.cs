using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.DscConfiguration;

internal class GetContentOperation : Pandora.Definitions.Operations.GetOperation
{
    public override string? ContentType() => "text/powershell";

    public override ResourceID? ResourceId() => new ConfigurationId();

    public override Type? ResponseObject() => typeof(CustomTypes.RawFile);

    public override string? UriSuffix() => "/content";


}
