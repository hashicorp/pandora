using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveEvents;

internal class CreateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(LiveEventModel);

\t\tpublic override ResourceID? ResourceId() => new LiveEventId();

\t\tpublic override Type? ResponseObject() => typeof(LiveEventModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [QueryStringName("autoStart")]
        [Optional]
        public bool AutoStart { get; set; }
    }
}
