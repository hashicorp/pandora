using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.IdentityProvider;

internal class ListByServiceOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ServiceId();

    public override Type NestedItemType() => typeof(IdentityProviderContractModel);

    public override string? UriSuffix() => "/identityProviders";


}
