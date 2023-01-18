using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;

internal class GetSchemaJsonOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TriggerId();

    public override Type? ResponseObject() => typeof(JsonSchemaModel);

    public override string? UriSuffix() => "/schemas/json";


}
