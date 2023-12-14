using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Extensions;

internal class GetAzureMonitorStatusOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new HDInsightClusterId();

    public override Type? ResponseObject() => typeof(AzureMonitorResponseModel);

    public override string? UriSuffix() => "/extensions/azureMonitor";


}
