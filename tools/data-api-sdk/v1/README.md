## `github.com/hashicorp/pandora/tools/data-api-sdk/v1`

This package contains the SDK for the V1 endpoints within [the Data API](../../data-api) - intended to be used by the other Pandora tooling.

The majority of the models used in this SDK come from [the `./models` package](./models) - however this package also contains a handful of models for 1:1 compatibility with the API.

Whilst the SDK contains all the supported endpoints, in the majority of cases the `LoadAllData` method should be sufficient, which can be used like so:

```go
package main

import (
	"context"
	"log"
	
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func main() {
	ctx := context.TODO()
	client := v1.NewClient("http://localhost:8888", models.ResourceManagerSourceDataType)
	
	// First check the Data API is available
	resp, err := client.Health(ctx)
	if err != nil {
		log.Fatalf("%+v", err)
	}
	log.Printf("Data API is available: %t", resp.Available)
	
	// Then retrieve all of the Services and all of their associated Data to work against..
	var servicesToLoad []string // this is a list of services to filter to, if empty/nil then every service is loaded
	servicesToLoad = []string{
		"Compute",
    }
	data, err := client.LoadAllData(ctx, servicesToLoad)
	if err != nil {
		log.Fatal(err.Error())
	}
	log.Printf("retrieved: %+v", data)
}
```

Finally [the `./helpers` package](./helpers) contains functions designed to work with each tool within the SDK, including:

* `GolangTypeForSDKObjectDefinition` - to obtain the Golang Type Name for an SDK Object Definition.
* `InnerMostSDKObjectDefinition` - to obtain the innermost SDK Object Definition.
