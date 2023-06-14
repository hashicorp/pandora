using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.SensitivityLabels;

internal class GetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ColumnId();

    public override Type? ResponseObject() => typeof(SensitivityLabelModel);

    public override string? UriSuffix() => "/sensitivityLabels/current";


}
