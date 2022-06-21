using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.IntelligencePacks;

internal class ListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type? ResponseObject() => typeof(List<IntelligencePackModel>);

    public override string? UriSuffix() => "/intelligencePacks";


}
