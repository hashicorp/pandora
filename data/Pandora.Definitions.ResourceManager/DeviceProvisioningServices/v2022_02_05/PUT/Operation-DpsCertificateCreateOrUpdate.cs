using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PUT;

internal class DpsCertificateCreateOrUpdateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CertificateResponseModel);

    public override ResourceID? ResourceId() => new CertificateId();

    public override Type? ResponseObject() => typeof(CertificateResponseModel);

    public override Type? OptionsObject() => typeof(DpsCertificateCreateOrUpdateOperation.DpsCertificateCreateOrUpdateOptions);

    internal class DpsCertificateCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
