package generator

import "fmt"

var _ stage = resourceDeleteStage{}

type resourceDeleteStage struct{}

func (r resourceDeleteStage) applicable(data *Data) bool {
	return data.IsResource && data.ResourceDeleteOperation != nil && data.ResourceDeleteOperation.Generate
}

func (r resourceDeleteStage) filePath(data Data) string {
	return fmt.Sprintf("%s_delete.go", data.fileNamePrefix)
}

func (r resourceDeleteStage) generate(data Data) (*string, error) {
	sdkMethodName := data.ResourceDeleteOperation.SDKMethodName
	isLongRunning := data.ResourceDeleteOperation.SDKMethodIsLongRunning
	timeoutInMinutes := defaultDeleteTimeout
	if data.ResourceDeleteOperation.CustomTimeoutInMinutes != nil {
		timeoutInMinutes = *data.ResourceDeleteOperation.CustomTimeoutInMinutes
	}

	if isLongRunning {
		sdkMethodName = fmt.Sprintf("%sThenPoll", sdkMethodName)
	}

	// TODO: we assume everything has an ID at this point which is _fine for now_ but needs fixing
	// TODO: we don't handle options objects but that's _fine_ for now

	contents := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"time"

	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
)

func (r %[2]sResource) Delete() tfsdk.ResourceFunc {
	return tfsdk.ResourceFunc{
		Func: func(ctx context.Context, metadata tfsdk.ResourceMetaData) error {
			client := metadata.Client.%[4]s

			id, err := gosdk.Parse%[5]sID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			metadata.Logger.Infof("Deleting %%s..", *id)
			if err := client.%[6]s(ctx, id); err != nil {
				return fmt.Errorf("deleting %%s: %%+v", *id, err)
			}
			metadata.Logger.Infof("Deleted %%s.", *id)

			return nil
		},
		Timeout: %[3]d * time.Minute,
	}
}
`, data.PackageName, data.ResourceName, timeoutInMinutes, data.ClientName, *data.ResourceIDTypeName, sdkMethodName)
	return &contents, nil
}
