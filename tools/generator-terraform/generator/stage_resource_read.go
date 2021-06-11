package generator

import "fmt"

var _ stage = resourceReadStage{}

type resourceReadStage struct {
}

func (r resourceReadStage) applicable(data *Data) bool {
	return data.IsResource && data.ResourceReadOperation != nil && data.ResourceReadOperation.Generate
}

func (r resourceReadStage) filePath(data Data) string {
	return fmt.Sprintf("%s_read.go", data.fileNamePrefix)
}

func (r resourceReadStage) generate(data Data) (*string, error) {
	sdkMethodName := data.ResourceReadOperation.SDKMethodName
	isLongRunning := data.ResourceReadOperation.SDKMethodIsLongRunning
	timeoutInMinutes := defaultReadTimeout
	if data.ResourceReadOperation.CustomTimeoutInMinutes != nil {
		timeoutInMinutes = *data.ResourceReadOperation.CustomTimeoutInMinutes
	}

	if isLongRunning {
		return nil, fmt.Errorf("long running read operations are not supported")
	}

	// TODO: we assume everything has an ID at this point which is _fine for now_ but needs fixing
	// TODO: we don't handle options objects but that's _fine_ for now
	// TODO: support for List operations

	mapper := mappingData{
		typeAlias:  "r",
		typeName:   fmt.Sprintf("%sResource", data.ResourceName),
		methodName: "mapReadModelToSchema",
		modelName:  *data.ResourceReadOperation.SDKModelName,

		// TODO: mapping definitions
	}
	mappingCode, err := mapper.modelToSchemaCode()
	if err != nil {
		return nil, fmt.Errorf("generating mapping code: %+v", err)
	}

	// TODO: we also need to map the ID Segments back to the Schema fields, by inverting `data.SchemaFieldsToResourceIDMappings`

	contents := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"time"

	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
)

func (r %[2]sResource) Read() tfsdk.ResourceFunc {
	return tfsdk.ResourceFunc{
		Func: func(ctx context.Context, metadata tfsdk.ResourceMetaData) error {
			client := metadata.Client.%[4]s

			id, err := gosdk.Parse%[5]sID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			metadata.Logger.Infof("Retrieving %%s..", *id)
			resp, err := client.%[6]s(ctx, id)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %%s: %%+v", *id, err)
			}

			metadata.Logger.Infof("Decoding schema into model for %%s..", *id)
			var schema %[2]sResourceModel
			if err := metadata.Decode(&schema); err != nil {
				return fmt.Errorf("decoding schema into model: %%+v", err)
			}

			metadata.Logger.Infof("Mapping %%s..", *id)
			if err := r.mapReadModelToSchema(&model); err != nil {
				return fmt.Errorf("mapping response model to schema for %%s: %%+v", *id, err)
			}

			return metadata.Encode(&schema)
		},
		Timeout: %[3]d * time.Minute,
	}
}

%[7]s
`, data.PackageName, data.ResourceName, timeoutInMinutes, data.ClientName, *data.ResourceIDTypeName, sdkMethodName, *mappingCode)
	return &contents, nil
}
