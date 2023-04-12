using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Providers;

internal class GetAtTenantScopeOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ProviderId();

    public override Type? ResponseObject() => typeof(ProviderModel);

    public override Type? OptionsObject() => typeof(GetAtTenantScopeOperation.GetAtTenantScopeOptions);

    internal class GetAtTenantScopeOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
