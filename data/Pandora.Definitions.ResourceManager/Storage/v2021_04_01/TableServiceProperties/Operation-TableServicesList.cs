using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.TableServiceProperties;

internal class TableServicesListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type? ResponseObject() => typeof(ListTableServicesModel);

    public override string? UriSuffix() => "/tableServices";


}
