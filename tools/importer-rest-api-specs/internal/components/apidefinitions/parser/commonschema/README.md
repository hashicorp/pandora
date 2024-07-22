## `./internal/components/apidefinitions/parser/commonschema`

This package contains logic used to identify when an Object Definition should be replaced by a Common Schema type.

Each Common Schema type implements the Matcher interface, which allows identifying if the SDKField in question matches the Common Schema type.
