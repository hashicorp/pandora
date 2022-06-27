using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

internal class DeleteImmutabilityPolicyOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new ContainerId();

    public override Type? ResponseObject() => typeof(ImmutabilityPolicyModel);

    public override Type? OptionsObject() => typeof(DeleteImmutabilityPolicyOperation.DeleteImmutabilityPolicyOptions);

    public override string? UriSuffix() => "/immutabilityPolicies/default";

    internal class DeleteImmutabilityPolicyOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
