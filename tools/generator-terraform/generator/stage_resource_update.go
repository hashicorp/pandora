package generator

import (
	"fmt"
	"strings"
)

var _ stage = resourceUpdateStage{}

type resourceUpdateStage struct{}

func (r resourceUpdateStage) applicable(data *Data) bool {
	return data.IsResource && data.ResourceUpdateOperation != nil && data.ResourceUpdateOperation.Generate
}

func (r resourceUpdateStage) filePath(data Data) string {
	return fmt.Sprintf("%s_update.go", data.fileNamePrefix)
}

func (r resourceUpdateStage) generate(data Data) (*string, error) {
	if data.ResourceReadOperation == nil {
		return nil, fmt.Errorf("Updates require a ReadOperation is defined for mapping updates across")
	}

	sdkReadMethodName := data.ResourceReadOperation.SDKMethodName
	sdkReadModelName := data.ResourceReadOperation.SDKModelName
	sdkUpdateMethodName := data.ResourceUpdateOperation.SDKMethodName
	sdkUpdateModelName := data.ResourceUpdateOperation.SDKModelName
	isLongRunning := data.ResourceUpdateOperation.SDKMethodIsLongRunning
	timeoutInMinutes := defaultUpdateTimeout
	if data.ResourceUpdateOperation.CustomTimeoutInMinutes != nil {
		timeoutInMinutes = *data.ResourceUpdateOperation.CustomTimeoutInMinutes
	}

	if isLongRunning {
		sdkUpdateMethodName = fmt.Sprintf("%sThenPoll", sdkUpdateMethodName)
	}

	mappings := make([]string, 0)

	// map the read object onto the update object
	mapper := mappingData{
		typeAlias:       "r",
		typeName:        fmt.Sprintf("%sResource", data.ResourceName),
		methodName:      "mapReadObjectToUpdateObject",
		modelName:       *sdkUpdateModelName,
		originModelName: sdkReadModelName,

		// TODO: mapping definitions from Read -> Update
	}
	mappingCode, err := mapper.modelToModelCode()
	if err != nil {
		return nil, fmt.Errorf("generating mapping code for Read -> Update obj: %+v", err)
	}
	mappings = append(mappings, *mappingCode)

	// then conditionally map (only) the changed schema fields onto the update object
	mapper = mappingData{
		typeAlias:  "r",
		typeName:   fmt.Sprintf("%sResource", data.ResourceName),
		methodName: "mapChangedSchemaFieldsToUpdateObject",
		modelName:  *sdkUpdateModelName,

		// TODO: mapping definitions from Schema -> Update
	}
	mappingCode, err = mapper.schemaToModelCode(true)
	if err != nil {
		return nil, fmt.Errorf("generating mapping code for Schema -> Update obj: %+v", err)
	}
	mappings = append(mappings, *mappingCode)

	contents := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"time"

	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
)

var _ tfsdk.ResourceWithUpdate = %[2]sResource{} 

func (r %[2]sResource) Update() tfsdk.ResourceFunc {
	return tfsdk.ResourceFunc{
		Func: func(ctx context.Context, metadata tfsdk.ResourceMetaData) error {
			client := metadata.Client.%[4]s

			id, err := gosdk.Parse%[5]sID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			metadata.Logger.Infof("Decoding model from the config %%s..", *id)
			var config %[2]sResourceModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %%+v", err)
			}

			metadata.Logger.Infof("Retrieving existing %%s..", *id)
			resp, err := client.%[6]s(ctx, *id)
			if err != nil {
				return fmt.Errorf("retrieving existing %%s: %%+v", *id, err)
			}

			metadata.Logger.Infof("Mapping response object onto update object for %%s..", *id)
			var updateObj sdk.%[8]s
			if err := r.mapReadObjectToUpdateObject(resp.Model, &updateObj); err != nil {
				return fmt.Errorf("mapping read response to update object %%s: %%+v", *id, err)
			}

			metadata.Logger.Infof("Mapping changed fields onto update object for %%s..", *id)
			if err := r.mapChangedSchemaFieldsToUpdateObject(config, &updateObj); err != nil {
				return fmt.Errorf("mapping changed fields onto update object %%s: %%+v", *id, err)
			}

			metadata.Logger.Infof("Updating %%s..", *id)
			if err := client.%[7]s(ctx, id); err != nil {
				return fmt.Errorf("updating %%s: %%+v", *id, err)
			}
			metadata.Logger.Infof("Updated %%s.", *id)

			return nil
		},
		Timeout: %[3]d * time.Minute,
	}
}
%[9]s
`, data.PackageName, data.ResourceName, timeoutInMinutes, data.ClientName, *data.ResourceIDTypeName, sdkReadMethodName, sdkUpdateMethodName, *sdkUpdateModelName, strings.Join(mappings, "\n"))
	return &contents, nil
}
