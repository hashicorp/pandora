# Internals: Types of Object Definitions

An Object Definition defines a Type of Thing - for example a String, a List of a String, a List of a List of a List of an Object. Different types of Object Definition exist within Pandora, these are:

1. Options Object Definition - defines values that can be sent as part of an HTTP Request (Headers/QueryString).
2. ObjectDefinition - defines the type of a Field within a Model.
3. Terraform Schema Field Type - to define the type of a Field in Terraform.

## Options Object Definition

HTTP Operations can support Options, which are values sent at Request time, either in the HTTP Headers and/or the QueryString.

At this point in time these support the following Basic types:

* Booleans
* CSVs
* Float (the Swagger defines Double/Decimal/Number - which we normalize into a Float)
* Integers
* List
* Strings

Examples:

* A Boolean
* A CSV of a String
* A List of a String
* A String

Limitations:

* A List cannot contain a List

Notes:

* At present the Object Definition type is reused, but shouldn't be, as we'll want to extend this in the future when we parse Data Plane (which has way more possible values for types).

## Object Definition (for a Field within a Model)

This Object Definition is used to describe the type used in the payload from the API, which is then surfaced in the SDK.

This can either be a Basic Type:

* Boolean
* DateTime
* Float
* Integer
* RawFile (e.g. `[]byte`)
* RawObject (e.g. `interface{}`)
* Reference (to either a Constant or a Model)
* String

A Common Type:

* EdgeZone
* Location
* SystemAssignedIdentity
* SystemAndUserAssignedIdentityList
* SystemAndUserAssignedIdentityMap
* LegacySystemAndUserAssignedIdentityList
* LegacySystemAndUserAssignedIdentityMap
* SystemOrUserAssignedIdentityList
* SystemOrUserAssignedIdentityMap
* UserAssignedIdentityList
* UserAssignedIdentityMap
* Tags
* SystemData
* Zone
* Zones

This can also be a Type which contains a Type, for example:

* A Dictionary of a Basic Type (the Key is assumed to be a String, the Value being the Nested Object Definition)
* A List of a Basic Type (the Item Type being the Nested Object Definition)

Examples:

* A Boolean
* A List of a List of a String
* A Reference (to a Constant)
* A Reference (to a Model)
* A List of a List of a Reference (to a Constant)
* A List of a List of a Reference (to a Model)
* A Dictionary of a Dictionary to a String
* A SystemOrUserAssignedIdentityList

Notes:

* In retrospect this should probably be named `SDKObjectDefinition`

## Terraform Schema Field Type

Terraform's Schema uses different types to the SDK/API types, as such this Field Type is used to outline how a given Schema Field should look in the Terraform Schema.

This has the same constraints as Terraform, and can be one of:

* Boolean
* DateTime
* Dictionary
* EdgeZone
* Float
* IdentitySystemAssigned
* IdentitySystemAndUserAssigned
* IdentitySystemOrUserAssigned
* IdentityUserAssigned
* Integer
* List
* Location
* Reference
* ResourceGroup (Name)
* Set
* Sku
* String
* Tags
* Zone
* Zones

Examples:

* A String
* A Resource Group
* A List of String
* A List of a Reference
* A Set of String