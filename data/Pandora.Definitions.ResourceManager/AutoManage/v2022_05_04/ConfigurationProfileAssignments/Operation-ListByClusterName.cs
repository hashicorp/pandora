using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AutoManage.v2022_05_04.ConfigurationProfileAssignments;

internal class ListByClusterNameOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ClusterId();

    public override Type? ResponseObject() => typeof(ConfigurationProfileAssignmentListModel);

    public override string? UriSuffix() => "/providers/Microsoft.AutoManage/configurationProfileAssignments";


}
