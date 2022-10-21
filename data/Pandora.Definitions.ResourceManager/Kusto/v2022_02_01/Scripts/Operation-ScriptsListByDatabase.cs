using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.Scripts;

internal class ScriptsListByDatabaseOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DatabaseId();

    public override Type? ResponseObject() => typeof(ScriptListResultModel);

    public override string? UriSuffix() => "/scripts";


}
