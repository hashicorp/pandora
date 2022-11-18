using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.Fleets;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(FleetModel);

\t\tpublic override ResourceID? ResourceId() => new FleetId();

\t\tpublic override Type? ResponseObject() => typeof(FleetModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }

        [HeaderName("If-None-Match")]
        [Optional]
        public string IfNoneMatch { get; set; }
    }
}
