// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Api.V1.Helpers;

public class Reference
{
    public static string? ObjectReference(object? input)
    {
        return input?.GetType().Name;
    }
}