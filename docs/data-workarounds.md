## Guide: Adding a Data Workaround 

When generating `api-definitions`, unexpected behavior can occur that requires a data workaround to be added. This can be because a type is not what we expect, attributes like `Computed` need to be added, or whole attributes need to be hand defined.

These data workarounds live in `/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds` and this guide will walk through how to add a new one.

## Open an issue on github.com/Azure/azure-rest-api-specs/issues 

If there is an issue with the api-specs, open an issue on that repo as we'll use the issue number in our filename.

## Create a new workaround in `/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds`

The file should be called `workaround_servicepackage_issue#`. For this example, we'll create a file called `workaround_web_31682.go`

The following is boilerplate that uses the package and api issue number that this workaround applies to
```
var _ workaround = workaroundWeb31682{}

type workaroundWeb31682 struct {
}

// This checks that this workaround will only apply to a specific service/api version
func (workaroundWeb31682) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Web" && apiVersion.APIVersion == "2016-06-01"
}

func (workaroundWeb31682) Name() string {
	return "Web / 31682"
}
```

Now we can get into the meat and potatoes of how to override this specific issue. 

I'm using [31682](https://github.com/Azure/azure-rest-api-specs/issues/31682) in this example where we're unmarshalling Parameter Value incorrectly and we're seeing `Error: occurred unmarshalling JSON - Error = 'json: cannot unmarshal bool into Go struct field` in the provider.

First, we need to find where this information is incorrect in our `api-definitions` folder. For this issue, I've daisy chained my down to this [file](https://github.com/hashicorp/pandora/blob/main/api-definitions/resource-manager/Web/2016-06-01/Connections/Model-ApiConnectionDefinitionProperties.json) that holds the ParameterValue Models that we're looking for.

We're seeing this issue in the following models, `CustomParameterValues`, `NonSecretParameterValues`, and `ParameterValues`. The Azure API accepts any type but the way it's been defined in our `api-definition`, it only accepts strings. We can see that by looking at the [CustomParameterValues model](https://github.com/hashicorp/pandora/blob/main/api-definitions/resource-manager/Web/2016-06-01/Connections/Model-ApiConnectionDefinitionProperties.json#L54)

```
{
  "containsDiscriminatedTypeValue": false,
  "jsonName": "customParameterValues",
  "name": "CustomParameterValues",
  "objectDefinition": {
    "type": "Dictionary",
    "nullable": false,
    "referenceName": null,
    "referenceNameIsCommonType": null,
    "nestedItem": {
      "type": "String", // this piece is correct and should be `RawObject`
      "nullable": false,
      "referenceName": null,
      "referenceNameIsCommonType": null
    }
  },
  "optional": true,
  "readOnly": false,
  "required": false,
  "sensitive": false
},
```

There is a lot in that model but we're only focused on the piece that is wrong which is in the `nestedItem` block where the `type` is `String` and it should be `RawObject`.

Now that we know where our issue is, we can build out the `Process` method that will overwrite what is in that file with the correct information. Unfortunately, the way these models are presented in Pandora is a convoluted mess of objects and references to objects so we'll have to dig to get to the information we need. 

The normal route that most overrides go is finding the resource, then the model, then the field.

We'll start with the finding the resource:

```
// At the time this function is called, we know we have the information about the specific service and api version that we want to override.
// From the top level `api-definitions` folder, our `input` is the information contained in `api-definitions/resource-manager/Web/2016-06-01`
func (workaroundWeb31682) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
    // And then we need to grab the resource we want to override which for this issue is `Connections` or `api-definitions/resource-manager/Web/2016-06-01/Connections`
	resource, ok := input.Resources["Connections"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Connections` but didn't get one")
	}
	...
```

Once we've grabbed the Connections resource, we have to work our way to the specific model we want to change. For this issue, the file we want to override is [Model-ApiConnectionDefinitionProperties.json](https://github.com/hashicorp/pandora/blob/main/api-definitions/resource-manager/Web/2016-06-01/Connections/Model-ApiConnectionDefinitionProperties.json) which has the json Name of [ApiConnectionDefinitionProperties](https://github.com/hashicorp/pandora/blob/main/api-definitions/resource-manager/Web/2016-06-01/Connections/Model-ApiConnectionDefinitionProperties.json#L2). 

```
    ...
    model, ok := resource.Models["ApiConnectionDefinitionProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model ApiConnectionDefinitionProperties")
	}
    ...
```

After we've obtained the model, we need to grab the field and update it. The field we're trying to override which for this issue is [CustomParameterValues](https://github.com/hashicorp/pandora/blob/main/api-definitions/resource-manager/Web/2016-06-01/Connections/Model-ApiConnectionDefinitionProperties.json#L54)

```
    ...
    cpvField, ok := model.Fields["CustomParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model ApiConnectionDefinitionProperties")
	}
	
	// Once we've grabbed the field, we can navigate to the incorrect piece and fix it
	if cpvField.ObjectDefinition.NestedItem != nil {
		cpvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}
	...
```

Once we've overridden the incorrect field, we need to apply those changes back to all the models we touched like so:

```
    ...
    model.Fields["CustomParameterValues"] = cpvField
	resource.Models["ApiConnectionDefinitionProperties"] = model
	input.Resources["Connections"] = resource

	return &input, nil
}
```

The final Process method with all three fields changed looks like: 

```
func (workaroundWeb31682) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Connections"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Connections` but didn't get one")
	}
	model, ok := resource.Models["ApiConnectionDefinitionProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model ApiConnectionDefinitionProperties")
	}
	cpvField, ok := model.Fields["CustomParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model ApiConnectionDefinitionProperties")
	}
	if cpvField.ObjectDefinition.NestedItem != nil {
		cpvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}

	nspvField, ok := model.Fields["NonSecretParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model ApiConnectionDefinitionProperties")
	}
	if nspvField.ObjectDefinition.NestedItem != nil {
		nspvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}

	pvField, ok := model.Fields["ParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model ApiConnectionDefinitionProperties")
	}
	if pvField.ObjectDefinition.NestedItem != nil {
		pvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}
	model.Fields["CustomParameterValues"] = cpvField
	model.Fields["NonSecretParameterValues"] = nspvField
	model.Fields["ParameterValues"] = pvField
	resource.Models["ApiConnectionDefinitionProperties"] = model
	input.Resources["Connections"] = resource

	return &input, nil
}
```

Finally, we want to update `/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds/workarounds.go` with our workaround

```
// Add the workaround to the following list
var workarounds = []workaround{
    ...
	workaroundWeb31682{},
    ...
```

To confirm the override works as intended run `make import` from `tools/importer-rest-api-specs` and confirm the model has changed.

When opening the Pull Request for this override, don't commit any changes made to `api-definitions` as we have automated processes that will apply those overrides for us.
