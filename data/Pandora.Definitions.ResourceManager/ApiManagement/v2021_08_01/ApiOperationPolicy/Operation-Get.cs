using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiOperationPolicy;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new OperationId();

\t\tpublic override Type? ResponseObject() => typeof(PolicyContractModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

\t\tpublic override string? UriSuffix() => "/policies/policy";

    internal class GetOptions
    {
        [QueryStringName("format")]
        [Optional]
        public PolicyExportFormatConstant Format { get; set; }
    }
}
