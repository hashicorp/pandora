using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_12_12.DpsCertificate;

internal class GenerateVerificationCodeOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new CertificateId();

    public override Type? ResponseObject() => typeof(VerificationCodeResponseModel);

    public override Type? OptionsObject() => typeof(GenerateVerificationCodeOperation.GenerateVerificationCodeOptions);

    public override string? UriSuffix() => "/generateVerificationCode";

    internal class GenerateVerificationCodeOptions
    {
        [QueryStringName("certificate.created")]
        [Optional]
        public string CertificateCreated { get; set; }

        [QueryStringName("certificate.hasPrivateKey")]
        [Optional]
        public bool CertificateHasPrivateKey { get; set; }

        [QueryStringName("certificate.isVerified")]
        [Optional]
        public bool CertificateIsVerified { get; set; }

        [QueryStringName("certificate.lastUpdated")]
        [Optional]
        public string CertificateLastUpdated { get; set; }

        [QueryStringName("certificate.name")]
        [Optional]
        public string CertificateName { get; set; }

        [QueryStringName("certificate.nonce")]
        [Optional]
        public string CertificateNonce { get; set; }

        [QueryStringName("certificate.purpose")]
        [Optional]
        public CertificatePurposeConstant CertificatePurpose { get; set; }

        [QueryStringName("certificate.rawBytes")]
        [Optional]
        public string CertificateRawBytes { get; set; }

        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
