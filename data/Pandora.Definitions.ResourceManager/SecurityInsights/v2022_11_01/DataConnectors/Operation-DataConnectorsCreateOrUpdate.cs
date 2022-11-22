using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.DataConnectors;

internal class DataConnectorsCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(DataConnectorModel);

    public override ResourceID? ResourceId() => new DataConnectorId();

    public override Type? ResponseObject() => typeof(DataConnectorModel);


}
