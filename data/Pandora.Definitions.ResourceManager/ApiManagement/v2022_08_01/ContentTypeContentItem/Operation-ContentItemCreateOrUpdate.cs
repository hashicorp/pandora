using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ContentTypeContentItem;

internal class ContentItemCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ContentItemContractModel);

    public override ResourceID? ResourceId() => new ContentItemId();

    public override Type? ResponseObject() => typeof(ContentItemContractModel);

    public override Type? OptionsObject() => typeof(ContentItemCreateOrUpdateOperation.ContentItemCreateOrUpdateOptions);

    internal class ContentItemCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
