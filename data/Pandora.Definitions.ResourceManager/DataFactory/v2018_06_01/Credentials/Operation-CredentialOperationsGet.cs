using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Credentials;

internal class CredentialOperationsGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new CredentialId();

    public override Type? ResponseObject() => typeof(ManagedIdentityCredentialResourceModel);

    public override Type? OptionsObject() => typeof(CredentialOperationsGetOperation.CredentialOperationsGetOptions);

    internal class CredentialOperationsGetOptions
    {
        [HeaderName("If-None-Match")]
        [Optional]
        public string IfNoneMatch { get; set; }
    }
}
