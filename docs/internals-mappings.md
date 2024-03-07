# Internals: Mappings

Each Pandora-generated Terraform Resource is associated with a single version of the API - and the Terraform Schema Model(s) for this Resource are based on the API Version.

Mappings define how to map each Field within each Terraform Schema Model onto each Field within the associated SDK Models (located in `hashicorp/go-azure-sdk`).

> **Note:** Mappings are bidirectional - meaning we're mapping the Terraform Schema Field onto an SDK Field (in Terraform's Create/Update functions) and the SDK Field onto the Terraform Schema Field (in Terraform's Read function).

There are three different types of Mappings:

1. Field Mappings.
2. Model to Model Mappings.
3. Resource ID (Segment) Mappings.

In each case, these map the fields in the Terraform Schema onto either the SDK Models - or the Resource ID for a given Resource.

Whilst Mappings define how to map a Type of Field from the Schema to another Field, mapping the value of those fields is left to the Terraform Generator, for example where one field is Required and another is Optional - the Terraform Generator should handle passing either a reference/the value as needed.

## 1: Field Mappings

Each Field within a Terraform Schema Model has a Field Mapping which defines how to map the value from the Schema Field onto the associated SDK Field.

The Type of Field Mapping that this is determines how the two values should be mapped onto one another - of which there are three possible Types:

1. `DirectAssignment` - which specifies that these values should be directly assigned (e.g. `a = b`) onto one-another - doing any transformation necessary (e.g. `flatten` functions, handling one being Optional the other being Required etc).
2. `ModelToModel` - which specifies that this Schema Field should be mapped onto another Model. This happens when the Fields `ObjectDefinition` is either a `Reference`, `Dictionary[string, Reference]`, `List[Reference]` or `Set[Reference]`.
3. `Manual` - specifies that this Field must be manually mapped (for example due to complex behaviour).

> _Future thought:_ additional Field Mapping types could be added to support additional use-cases. For example, transforming values (e.g. such as having an `Integer` used in the Terraform Schema, but a `String` exposed in the SDK - or to support handling `SkuName` etc). 

### a. `DirectAssignment` Field Mappings

A `DirectAssignment` mapping specifies that the value of a Field within the Terraform Schema should be mapped onto the value of a Field within the related (Go) SDK Model - and vica-versa.

This requires that the `TerraformObjectDefinitionType` used in the Terraform Schema Field and the `ObjectDefinitionType` used in the Field within the SDK Model are compatible - for example mapping a `String` (Schema) onto a `String` (SDK).

Mappings between the two different Object Definitions are defined within the Terraform Generator, both [for simple types](https://github.com/hashicorp/pandora/blob/d893d8c6533bbfc3feab00dea5fcf58f880897df/tools/generator-terraform/generator/mappings/assignment_direct.go#L10-L22) and [complex types requiring some form of transformation](https://github.com/hashicorp/pandora/blob/d893d8c6533bbfc3feab00dea5fcf58f880897df/tools/generator-terraform/generator/mappings/assignment_direct_transform.go#L5-L14).

Conversions between Object Definition Types (for example the Schema containing an Integer but the SDK containing a String value) are not supported at this time - but if needed would likely be supported as a new type of Mapping.

Direct Assignment Mappings support the following properties:

* `schemaModelName` - specifies the name of the Terraform Schema Model where this value should be mapped from.
* `schemaFieldPath` - specifies the path to the Field within the Terraform Schema Model defined in `schemaModelName` which this should be mapped from.
* `sdkModelName` - specifies the name of the SDK Model where this value should be mapped onto.
* `sdkFieldPath` - specifies the Path to the Field within the SdkModel where the Schema Field should be mapped onto.

> **Note:** Whilst `schemaFieldPath` and `sdkFieldPath` are named `Path` to allow supporting indexed keys in the future (for example using `AppSettings.SomeSetting` to retrieve the value for the key `SomeSetting` within the Dictionary defined in the `AppSettings` property) - at this point in time these only support top-level fields (e.g. `Name`).

An example of a Direct Assignment Mapping can be seen below:

> **Note:** A more complete example can be seen under `Examples` below.

```json
{
  "fieldMappings": [
    {
      "type": "DirectAssignment",
      "directAssignment": {
        "schemaModelName": "SolarSystemResourceSchema",
        "schemaFieldPath": "Name",
        "sdkModelName": "SolarSystem",
        "sdkFieldPath": "Name"
      }
    }
  ]
}
```

### b. `ModelToModel` Field Mappings

ModelToModel Field Mappings - not to be confused with ModelToModel Mappings (below) - allow mapping a Terraform Schema Model onto a field within an SDK Model.

The best example of this is allowing the top-level Terraform Schema Model for a given Terraform Resource to map onto the `properties` object that exists in most payloads in Azure Resource Manager - allowing for fields which exist at the root of the Terraform Schema to be mapped to a nested object.

Each ModelToModel Field Mapping must have an associated ModelToModel mapping, these are used together:

* A ModelToModel Field Mapping is used to output the call to the mapping function itself.
* A ModelToModel Mapping is used to output the mapping function, the fields which should be mapped are then inferred from the ModelToModel Field Mappings.

> **Note:** A complete end-to-end example can be found below under `Example`.

Model to Model Field Mappings support the following properties:

* `schemaModelName` - specifies the name of the Terraform Schema Model that should be mapped onto the Field within the SDK Model.
* `sdkModelName` - specifies the name of the SDK Model containing the SDK Field that the Terraform Schema Model should be mapped onto.
* `sdkFieldPath` - specifies the Path to the Field within the SDK Model where the Terraform Schema Model should be mapped onto.

An example of a Model to Model Field Mapping can be seen below: 

```json
{
  "fieldMappings": [
    {
      "type": "ModelToModel",
      "modelToModel": {
        "schemaModelName": "SolarSystemResourceSchema",
        "sdkModelName": "SolarSystem",
        "sdkFieldName": "Properties"
      }
    }
  ]
}
```

This would allow the Terraform Generator to output:

```go
func (r VirtualMachineResource) mapVirtualMachineResourceSchemaToVirtualMachineProperties(input VirtualMachineResourceSchema, output *virtualmachines.VirtualMachine) error {
    if output.Properties == nil {
        output.Properties = &virtualmachines.VirtualMachineProperties{}
    }
    if err := r.mapVirtualMachineResourceSchemaToVirtualMachineProperties(input, output.Properties); err != nil {
        return fmt.Errorf("mapping Schema to SDK Field %q / Model %q: %+v", "Properties", "SolarSystemProperties", err)
    }
    
    return nil
}
```

As mentioned above, this implies the presence of an associated ModelToModel Mapping, which would then generate the mapping for the Model itself:

```go
func (r VirtualMachineResource) mapVirtualMachineResourceSchemaToVirtualMachineProperties(input VirtualMachineResourceSchema, output *virtualmachines.VirtualMachineProperties) error {
    // ...
    // DirectAssignment Field Mappings would be output here
    // ...
    
    return nil
}
```

### c. `Manual` Field Mappings

> **Note:** At this point in time Manual Mappings are only partially configured and **need reworking** - as such this section explains the intention this type of Mapping, so that we can fix this in the future.

Manual Field Mappings allow the use of custom logic to map the value of a Field within the Terraform Schema onto a Field within an SDK Model.

As such Manual Field Mappings likely need to be structured similarly to the other types of Field Mapping, but also allow for two mapping functions to be defined (to map bidirectionally) - as a hypothetical example:

```json
{
  "type": "Manual",
  "manualMapping": {
    "schemaModelName": "VirtualMachineResourceSchema",
    "schemaFieldPath": "SomeComplexProperty",
    "schemaToSdkMethodName": "mapSomeComplexPropertyToSomePayloadProperty",
    "sdkModelName": "VirtualMachineProperties",
    "sdkFieldPath": "SomePayloadProperty",
    "sdkToSchemaMethodName": "mapSomePayloadPropertyToSomeComplexProperty"
  }
}
```

In this example the following properties would exist:

* `schemaModelName` - specifies the name of the Terraform Schema Model where the Field that should be mapped to/from exists.
* `schemaFieldPath` - specifies the path to the Field within the Terraform Schema Model that should be mapped to/from the Field within the SDK.
* `schemaToSdkMethodName` - specifies the name of a function that should be assumed to exist within the Terraform Provider, which maps the value of the Terraform Schema Field onto the SDK Field.
* `sdkModelName` - specifies the name of the SDK Model where the SDK Field defined in `sdkFieldPath` exists.
* `sdkFieldPath`- specifies the path to the Field within the SDK Model where the Schema Field should be mapped to/from.
* `sdkToSchemaMethodName` - specifies the name of a function that should be assumed to exist within the Terraform Provider, which maps the value of the SDK Field onto the Terraform Schema Field.

> **Note:** The current implementation that exists exposed only `methodName` - as such is only useful for one-way value transformations.

## 2: Model to Model Mappings

A ModelToModel mapping defines that a Terraform Schema Model should be mapped onto an SDK Model.

> **Note:** A ModelToModel Mapping and a ModelToModel Field Mapping are related but different - a ModelToModel Field Mapping _must_ have an associated ModelToModel Mapping - however a ModelToModel mapping can exist without a ModelToModel Field Mapping.

Model to Model Mappings support the following properties:

* `schemaModelName` - specifies the name of the Terraform Schema Model that the SDK Model should be mapped to/from.
* `sdkModelName` - specifies the name of the SDK Model that the Terraform Schema Model should be mapped to/from.

An example of a Model to Model mapping can be seen below:

```json
{
  "modelToModelMappings": [
    {
      "schemaModelName": "VirtualMachineResourceSchema",
      "sdkModelName": "VirtualMachine"
    }
  ]
}
```

> **Note:** An end-to-end example can be found under `Example` below.

## 3: Resource ID Segment Mapping

Resource ID Segment Mappings allow mapping values from the Resource ID into a field within the Terraform Schema.

Segments can be parsed either from the Resource ID for the Terraform Resource - or in the cases where a Resource is nested under another, Segments can also be sourced from the Parent Resource ID.

A Resource ID Segment Mapping contains the following properties:

* `parsedFromParentId` - specifies whether this Segment is from the Resource ID for the Terraform Resource, or from the Parent Terraform Resource (for example, the Virtual Machine Extension ID or the Virtual Machine ID).
* `schemaFieldName` - specifies the Field within the (top-level) Terraform Schema Model for this Resource that this segment should be mapped to/from.
* `segmentName` - specifies the Name of the Resource ID Segment which should be mapped to/from the Terraform Schema Field defined in `schemaFieldName`.

An example of a Resource ID Segment Mapping can be seen below:

```json
{
  "resourceIdMappings": [
    {
      "parsedFromParentId": false,
      "schemaFieldName": "Name",
      "segmentName": "ExtensionName"
    },
    {
      "parsedFromParentId": true,
      "schemaFieldName": "VirtualMachineId",
      "segmentName": "virtualMachineName"
    },
    {
      "parsedFromParentId": true,
      "schemaFieldName": "VirtualMachineId",
      "segmentName": "resourceGroupName"
    }
  ]
}
```

Where the following Typed Model exists representing the Terraform Schema:

```go
type VirtualMachineExtensionResourceSchema struct {
	Name string `tfschema:"name"`
	VirtualMachineId string `tfschema:"virtual_machine_id"`
}
```

### Example of Mappings

This example highlights a hypothetical Terraform Resource, `SolarSystemResource`, which has an SDK Model `SolarSystemResourceSchema` - and maps onto the SDK Model `solarsystem.SolarSystem`.

In this example, let's assume that the following SDK Models exist and are available within `hashicorp/go-azure-sdk`:

```go
type solarsystems

type SolarSystem struct {
    Name string
	Properties SolarSystemProperties
}

type SolarSystemProperties struct {
	Description string
	Planets []Planet
}

type Planet struct {
	Name string
}
```

The associated Terraform Schema for this would then look like:

```go
type SolarSystemResource struct {}

func (r SolarSystemResource) Arguments() map[string]*pluginsdk.Schema {
    return map[string]*pluginsdk.Schema{
        "name": {
            Type:     pluginsdk.TypeString,
            Required: true,
        },
        "description": {
            Type:     pluginsdk.TypeString,
            Required: true,
        },
        "planets": {
            Type:     pluginsdk.TypeList,
            Required: true,
            Elem: &pluginsdk.Resource{
                Schema: map[string]*pluginsdk.Schema{
                    "name": {
                        Type:     pluginsdk.TypeString,
                        Required: true,
                    },
                },
            },
        },
    }
}

func (r SolarSystemResource) Arguments() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{}
}
```

Finally, the Typed Model for this Resource looks like:

```go
type SolarSystemResourceSchema struct {
	Name string `tfschema:"name"`
	Description string `tfschema:"description"`
	Planets []SolarSystemResourcePlanetSchema `tfschema:"planets"`
}

type SolarSystemResourcePlanetSchema struct {
	Name string `tfschema:"name"`
}
```

In this scenario, the following Mappings would define how to map the Schema Fields `Name`, `Description` and `Planets` (from `SolarSystemResourceSchema`) onto the SDK Fields `Name`, `Description` and `Planets` (within `solarsystems.SolarSystem`):

```json
{
  "fieldMappings": [
    {
      "type": "DirectAssignment",
      "directAssignment": {
        "schemaModelName": "SolarSystemResourceSchema",
        "schemaFieldPath": "Name",
        "sdkModelName": "SolarSystem",
        "sdkFieldPath": "Name"
      }
    },
    {
      "type": "DirectAssignment",
      "directAssignment": {
        "schemaModelName": "SolarSystemResourceSchema",
        "schemaFieldPath": "Description",
        "sdkModelName": "SolarSystemProperties",
        "sdkFieldPath": "Description"
      }
    },
    {
      "type": "DirectAssignment",
      "directAssignment": {
        "schemaModelName": "SolarSystemResourceSchema",
        "schemaFieldPath": "Planets",
        "sdkModelName": "SolarSystemProperties",
        "sdkFieldPath": "Planets"
      }
    },
    {
      "type": "DirectAssignment",
      "directAssignment": {
        "schemaModelName": "SolarSystemResourcePlanetSchema",
        "schemaFieldPath": "Name",
        "sdkModelName": "Planet",
        "sdkFieldPath": "Name"
      }
    },
    {
      "type": "ModelToModel",
      "modelToModel": {
        "schemaModelName": "SolarSystemResourceSchema",
        "sdkModelName": "SolarSystem",
        "sdkFieldName": "Properties"
      }
    }
  ],
  "modelToModelMappings": [
    {
      "schemaModelName": "SolarSystemResourceSchema",
      "sdkModelName": "SolarSystem"
    },
    {
      "schemaModelName": "SolarSystemResourceSchema",
      "sdkModelName": "SolarSystemProperties"
    },
    {
      "schemaModelName": "SolarSystemResourcePlanetSchema",
      "sdkModelName": "Planet"
    }
  ],
  "resourceIdMappings": []
}
```

To explain these mappings in-turn:

* `modelToModelMappings[0]` and `modelToModelMappings[1]` - The Terraform Schema Model `SolarSystemResourceSchema` should be mapped onto both the SDK Models `SolarSystem` and `SolarSystemProperties` - allowing the `name`, `description` and `planets` fields to be mapped across onto these models as defined below.
* `modelToModelMappings[2]` - The Terraform Schema Model `SolarSystemResourceSchema` should be mapped onto the SDK Model `Planet`. This allows `name` within `planet` in the Terraform Schema to be mapped to/from the Planets model.
* `fieldMappings[0]` - The Terraform Schema Field `name` (represented by the field `Name` within the Schema Model `SolarSystemResourceSchema`) gets mapped onto the SDK Field `Name` within the SDK Model `SolarSystem`.
* `fieldMappings[1]` - The Terraform Schema Field `description` (represented by the field `Description` within the Schema Model `SolarSystemResourceSchema`) gets mapped onto the SDK Field `Description` within the SDK Model `SolarSystemProperties`.
* `fieldMappings[2]` - The Terraform Schema Field `planets` (represented by the field `Planets` within the Schema Model `SolarSystemResourceSchema`) gets mapped onto the SDK Field `Planets` within the SDK Model `SolarSystemProperties`. Since this is a list, each item will be mapped across in-turn.``
* `fieldMappings[3]` - The Terraform Schema Field `name` within `planets` (represented by the field `Name` within the Schema Model `SolarSystemResourcePlanetSchema`) gets mapped onto the SDK Field `Name` within the SDK Model `Planet`.

> **Note:** In this (simplified) example there are no `resourceIdMappings` - however examples of this can be seen above.

This would allow the Terraform Generator to output mapping functions similar to below:

> Whilst mappings are bidirectional (that is Schema Model -> SDK Model and SDK Model -> Schema Model) - to reduce the amount of output only the Schema Model -> SDK Model mappings are shown below - but the inverse can be implied.

```go
func (r SolarSystemResource) mapSolarSystemResourceSchemaToSolarSystem(input SolarSystemResourceSchema, output *solarsystems.SolarSystem) error {
    output.Name = input.Name
    
    if output.Properties == nil {
        output.Properties = &solarsystem.SolarSystemProperties{}
    }
    if err := r.mapSolarSystemResourceSchemaToSolarSystemProperties(input, output.Properties); err != nil {
        return fmt.Errorf("mapping Schema to SDK Field %q / Model %q: %+v", "Properties", "SolarSystemProperties", err)
    }
    
    return nil
}

func (r SolarSystemResource) mapSolarSystemResourceSchemaToSolarSystemProperties(input SolarSystemResourceSchema, output *solarsystems.SolarSystemProperties) error {
    output.Description = input.Description

    planets := make([]Planet, 0)
    for _, v := range input.Roles {
        item := solarsystems.Planet{}
        if err := r.mapSolarSystemResourcePlanetSchemaToPlanet(v, &item); err != nil {
            return fmt.Errorf("mapping SolarSystemResourcePlanetSchema item %d to Planet: %+v", i, err)
        }
        planets = append(planets, item)
    }
    output.Planets = planets
    
    return nil
}

func (r SolarSystemResource) mapSolarSystemResourcePlanetSchemaToPlanet(input SolarSystemResourcePlanetSchema, output *solarsystems.Planet) error {
    output.Name = input.Name
	
    return nil
}
```
