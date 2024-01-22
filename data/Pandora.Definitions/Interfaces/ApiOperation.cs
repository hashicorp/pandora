// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Pandora.Definitions.Interfaces;

public interface ApiOperation
{
    string? ContentType();

    IEnumerable<HttpStatusCode> ExpectedStatusCodes();

    string? FieldContainingPaginationDetails();

    bool LongRunning();

    HttpMethod Method();

    Type? RequestObject();

    Type? ResponseObject();

    // OptionsObject describes the Options application to this Operation, for example filtering or sorting
    Type? OptionsObject();

    ResourceID? ResourceId();

    // UriSuffix is any suffix which should be applied to the URI, for example /start - to perform mutations
    // on a given object
    string? UriSuffix();
}