using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AccountFilters;

internal class AccountFiltersCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(AccountFilterModel);

    public override ResourceID? ResourceId() => new AccountFilterId();

    public override Type? ResponseObject() => typeof(AccountFilterModel);


}
