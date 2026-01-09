// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package featureflags

// AllowConstantsWithoutXMSEnum specifies whether Constants should be parsed out without
// an x-ms-enum extension. This is intended to be a temporary stop-gap whilst the data
// issues are resolved - since the Swagger should define canonical names for these Enums.
const AllowConstantsWithoutXMSEnum = true

// ParseDataFactoryListsOfReferencesAsRegularObjectDefinitionTypes specifies whether the Custom Types
// used by Data Factory (defined as `"type": "object" and "format": "dfe-XXX"`) should be parsed
// into regular ObjectDefinitions, rather than left as Objects - when these contain a Reference to
// a List of Objects.
//
// This feature-toggle is specific to the List of a Reference option, with the other Object Definition
// Types being enabled. However enabling this requires shifting the loading of nested types around which
// wants to be done post the ongoing refactor is completed (https://github.com/hashicorp/pandora/issues/3754).
const ParseDataFactoryListsOfReferencesAsRegularObjectDefinitionTypes = false
