using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

internal class TransformsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "@odata.nextLink";

    public override ResourceID? ResourceId() => new MediaServiceId();

    public override Type NestedItemType() => typeof(TransformModel);

    public override Type? OptionsObject() => typeof(TransformsListOperation.TransformsListOptions);

    public override string? UriSuffix() => "/transforms";

    internal class TransformsListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }
    }
}
