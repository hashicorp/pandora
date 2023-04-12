using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductPolicy;

internal class GetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ProductId();

    public override Type? ResponseObject() => typeof(PolicyContractModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    public override string? UriSuffix() => "/policies/policy";

    internal class GetOptions
    {
        [QueryStringName("format")]
        [Optional]
        public PolicyExportFormatConstant Format { get; set; }
    }
}
