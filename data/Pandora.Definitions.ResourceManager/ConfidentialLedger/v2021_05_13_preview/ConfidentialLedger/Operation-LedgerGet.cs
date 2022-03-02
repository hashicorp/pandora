using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;

internal class LedgerGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LedgerId();

    public override Type? ResponseObject() => typeof(ConfidentialLedgerModel);


}
