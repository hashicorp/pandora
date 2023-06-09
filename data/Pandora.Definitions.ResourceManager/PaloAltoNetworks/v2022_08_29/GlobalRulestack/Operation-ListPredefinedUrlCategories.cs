using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.GlobalRulestack;

internal class ListPredefinedUrlCategoriesOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new GlobalRulestackId();

    public override Type? ResponseObject() => typeof(PredefinedUrlCategoriesResponseModel);

    public override Type? OptionsObject() => typeof(ListPredefinedUrlCategoriesOperation.ListPredefinedUrlCategoriesOptions);

    public override string? UriSuffix() => "/listPredefinedUrlCategories";

    internal class ListPredefinedUrlCategoriesOptions
    {
        [QueryStringName("skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("top")]
        [Optional]
        public int Top { get; set; }
    }
}
