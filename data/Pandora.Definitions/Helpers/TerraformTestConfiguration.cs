// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.Helpers;

public static class TerraformTestConfiguration
{
    public static string AsTerraformTestConfig(this string input)
    {
        return input.Replace("'", "\"");
    }
}