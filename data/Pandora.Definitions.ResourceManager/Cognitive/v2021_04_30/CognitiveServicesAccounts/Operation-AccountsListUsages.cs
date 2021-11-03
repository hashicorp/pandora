using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{
    internal class AccountsListUsagesOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new AccountId();

        public override Type? ResponseObject() => typeof(UsageListResultModel);

        public override Type? OptionsObject() => typeof(AccountsListUsagesOperation.AccountsListUsagesOptions);

        public override string? UriSuffix() => "/usages";

        internal class AccountsListUsagesOptions
        {
            [QueryStringName("$filter")]
            [Optional]
            public string Filter { get; set; }
        }
    }
}
