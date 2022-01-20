using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.TrustedIdProviders;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TrustedIdProviderId();

    public override Type? ResponseObject() => typeof(TrustedIdProviderModel);


}
