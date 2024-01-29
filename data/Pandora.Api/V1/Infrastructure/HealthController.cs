// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Microsoft.AspNetCore.Mvc;

namespace Pandora.Api.V1.Infrastructure;

[ApiController]
public class HealthController : ControllerBase
{
    [Route("/v1/health")]
    public IActionResult ResourceManager()
    {
        return new OkResult();
    }
}