using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedDatabaseSensitivityLabels;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SensitivityLabelModel);

    public override ResourceID? ResourceId() => new TableColumnId();

    public override Type? ResponseObject() => typeof(SensitivityLabelModel);

    public override string? UriSuffix() => "/sensitivityLabels/current";


}
