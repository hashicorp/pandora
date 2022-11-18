using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.DefaultAccount;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override Type? ResponseObject() => typeof(DefaultAccountPayloadModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Purview/getDefaultAccount";

    internal class GetOptions
    {
        [QueryStringName("scope")]
        [Optional]
        public string Scope { get; set; }

        [QueryStringName("scopeTenantId")]
        public string ScopeTenantId { get; set; }

        [QueryStringName("scopeType")]
        public ScopeTypeConstant ScopeType { get; set; }
    }
}
