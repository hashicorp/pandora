## `./tools/data-api-sdk`

This package provides a Go SDK (and thus common models) which allows querying the Data API. 

### Example Usage

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
	resp, err := client.Health(ctx)
	if err != nil {
		log.Fatalf("%+v", err)
    }
	log.Printf("Data API is available: %t", resp.Available)
}
```