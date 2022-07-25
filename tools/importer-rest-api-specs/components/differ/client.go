package differ

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type Differ struct {
	client resourcemanager.Client
	logger hclog.Logger
}

func NewDiffer(dataApiEndpoint string, logger hclog.Logger) Differ {
	return Differ{
		client: resourcemanager.NewClient(dataApiEndpoint),
		logger: logger,
	}
}
