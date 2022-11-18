using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ContentTypeContentItem;

internal class ContentItemCreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new ContentItemId();

\t\tpublic override Type? ResponseObject() => typeof(ContentItemContractModel);

\t\tpublic override Type? OptionsObject() => typeof(ContentItemCreateOrUpdateOperation.ContentItemCreateOrUpdateOptions);

    internal class ContentItemCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
