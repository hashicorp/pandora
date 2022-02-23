using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.TableService;

internal class TableGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TableId();

    public override Type? ResponseObject() => typeof(TableModel);


}
