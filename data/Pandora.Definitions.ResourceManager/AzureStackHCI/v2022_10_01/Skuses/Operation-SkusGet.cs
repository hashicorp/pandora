using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Skuses;

internal class SkusGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SkuId();

\t\tpublic override Type? ResponseObject() => typeof(SkuModel);

\t\tpublic override Type? OptionsObject() => typeof(SkusGetOperation.SkusGetOptions);

    internal class SkusGetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
