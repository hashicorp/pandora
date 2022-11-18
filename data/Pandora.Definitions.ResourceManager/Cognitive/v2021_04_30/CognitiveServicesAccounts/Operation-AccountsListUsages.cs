using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;

internal class AccountsListUsagesOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AccountId();

\t\tpublic override Type? ResponseObject() => typeof(UsageListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(AccountsListUsagesOperation.AccountsListUsagesOptions);

\t\tpublic override string? UriSuffix() => "/usages";

    internal class AccountsListUsagesOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
