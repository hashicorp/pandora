// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package featureflags

// AllowConstantsWithoutXMSEnum specifies whether Constants should be parsed out without
// an x-ms-enum extension. This is intended to be a temporary stop-gap whilst the data
// issues are resolved - since the Swagger should define canonical names for these Enums.
const AllowConstantsWithoutXMSEnum = true

// ParseDataFactoryCustomTypesAsRegularObjectDefinitionTypes specifies whether the Custom Types
// used by Data Factory (defined as `"type": "object" and "format": "dfe-XXX"`) should be parsed
// into regular ObjectDefinitions, rather than left as Objects.
//
// @tombuildsstuff: this Feature Flag is currently disabled, since it requires loading Types
// from the Nested files first, which wants to be done post the ongoing refactor.
// As such I'll pick this up once https://github.com/hashicorp/pandora/issues/3754 is completed.
const ParseDataFactoryCustomTypesAsRegularObjectDefinitionTypes = false
