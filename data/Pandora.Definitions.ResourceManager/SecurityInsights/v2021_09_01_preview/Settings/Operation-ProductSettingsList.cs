using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Settings;

internal class ProductSettingsListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type? ResponseObject() => typeof(SettingListModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/settings";


}
