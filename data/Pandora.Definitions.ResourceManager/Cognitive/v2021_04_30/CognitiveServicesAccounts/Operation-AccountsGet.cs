using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;

internal class AccountsGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AccountId();

    public override Type? ResponseObject() => typeof(AccountModel);


}
