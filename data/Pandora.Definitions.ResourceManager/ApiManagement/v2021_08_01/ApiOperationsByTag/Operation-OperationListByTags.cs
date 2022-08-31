using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiOperationsByTag;

internal class OperationListByTagsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ApiId();

    public override Type NestedItemType() => typeof(TagResourceContractModel);

    public override Type? OptionsObject() => typeof(OperationListByTagsOperation.OperationListByTagsOptions);

    public override string? UriSuffix() => "/operationsByTags";

    internal class OperationListByTagsOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("includeNotTaggedOperations")]
        [Optional]
        public bool IncludeNotTaggedOperations { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
