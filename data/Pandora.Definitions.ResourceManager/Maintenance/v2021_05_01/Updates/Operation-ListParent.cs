using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.Updates;

internal class ListParentOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupProviderId();

    public override Type? ResponseObject() => typeof(ListUpdatesResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Maintenance/updates";


}
