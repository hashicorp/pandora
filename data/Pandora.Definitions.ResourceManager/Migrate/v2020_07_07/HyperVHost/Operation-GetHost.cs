using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVHost;

internal class GetHostOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new HostId();

    public override Type? ResponseObject() => typeof(HyperVHostModel);


}
