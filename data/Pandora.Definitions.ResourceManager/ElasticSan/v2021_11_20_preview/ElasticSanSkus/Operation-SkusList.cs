using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.ElasticSanSkus;

internal class SkusListOperation : Operations.GetOperation
{
    public override Type? ResponseObject() => typeof(SkuInformationListModel);

    public override Type? OptionsObject() => typeof(SkusListOperation.SkusListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.ElasticSan/skus";

    internal class SkusListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
