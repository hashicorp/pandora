using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AvailabilityGroupListenerId();

\t\tpublic override Type? ResponseObject() => typeof(AvailabilityGroupListenerModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
