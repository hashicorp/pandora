using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Product;

internal class DeleteOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new ProductId();

    public override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    internal class DeleteOptions
    {
        [QueryStringName("deleteSubscriptions")]
        [Optional]
        public bool DeleteSubscriptions { get; set; }

        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
