## `./internal/components/apidefinitions/parser/dataworkarounds`

This package is used to define Data Workarounds, which applies workarounds/fixes to the parsed API Definitions.

This is typically done to workaround a correctness issue (for example a Field being defined as an Integer rather than a String), but could also be to add constant values, discriminated types/implementations etc.

These are intended purely as a short-term workaround (and clearly aren't ideal) - so ultimately we want the data issues fixed upstream - and so each workaround should have an accompanying pull request in [the `Azure/azure-rest-api-specs` repository](https://github.com/Azure/azure-rest-api-specs).

