using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.QueueServiceProperties;

internal class QueueServicesGetServicePropertiesOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new StorageAccountId();

\t\tpublic override Type? ResponseObject() => typeof(QueueServicePropertiesModel);

\t\tpublic override string? UriSuffix() => "/queueServices/default";


}
