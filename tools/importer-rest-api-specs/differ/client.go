package differ

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

type Differ struct {
	client resourcemanager.Client
}

func NewDiffer(dataApiEndpoint string) Differ {
	return Differ{
		client: resourcemanager.NewClient(dataApiEndpoint),
	}
}
