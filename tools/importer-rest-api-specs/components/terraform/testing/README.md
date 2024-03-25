## Acceptance Test Generation

This package handles the generation of Terraform Acceptance Tests based on the Schema Models for a given Terraform Resource.

By iterating over the top-level model, and then propagating through the fields present within it, we can build up an ordered list of Attributes and Blocks (ordered Required Attributes, Required Blocks, Optional Attributes, Optional Blocks - alphabetically within each grouping).

The dependencies needed for the Acceptance Tests are identified based on the fields present within _all_ of the Terraform test configurations - meaning that we may provision dependencies for a Basic test when these are only used within a Complete test, but for now this is sufficient.

### Notes / Limitations

* The Random Variables at this point in time are output as Terraform Variables, ideally these would be a `locals` block to make this simpler, however the Terraform Generator needs to be updated to dynamically output the relevant variables.
* At this point in time the `commonschema` Identity types are output as Blocks and not Attributes - this will likely need to change for `terraform-plugin-framework` / Terraform Protocol v6 support (and there's TODO's to track this).
