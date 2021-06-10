package generator

import (
	"fmt"
	"strings"
)

var _ stage = dataSourceReadStage{}

type dataSourceReadStage struct{}

func (d dataSourceReadStage) applicable(data *Data) bool {
	return !data.IsResource && data.DataSourceReadOperation != nil && data.DataSourceReadOperation.Generate
}

func (d dataSourceReadStage) filePath(data Data) string {
	return fmt.Sprintf("%s_read.go", data.fileNamePrefix)
}

func (d dataSourceReadStage) generate(data Data) (*string, error) {
	sdkMethodName := data.DataSourceReadOperation.SDKMethodName
	isLongRunning := data.DataSourceReadOperation.SDKMethodIsLongRunning
	timeoutInMinutes := defaultReadTimeout
	if data.DataSourceReadOperation.CustomTimeoutInMinutes != nil {
		timeoutInMinutes = *data.DataSourceReadOperation.CustomTimeoutInMinutes
	}

	if isLongRunning {
		return nil, fmt.Errorf("long running read operations are not supported")
	}

	// TODO: we assume everything has an ID at this point which is _fine for now_ but needs fixing
	// TODO: we don't handle options objects but that's _fine_ for now
	// TODO: support for List operations

	idConstructor := "r.IDFromSchema(config)" // which requires someone creates this by hand at present
	if data.SchemaFieldsToResourceIDMappings != nil && len(*data.SchemaFieldsToResourceIDMappings) > 0 {
		segments := make([]string, 0)
		for _, v := range *data.SchemaFieldsToResourceIDMappings {
			segments = append(segments, fmt.Sprintf("model.%s", v))
		}
		idConstructor = fmt.Sprintf("gosdk.New%sID(subscriptionId, %s)", *data.ResourceIDTypeName, strings.Join(segments, ", "))
	}

	mapper := mappingData{
		typeAlias:  "ds",
		typeName:   fmt.Sprintf("%sDataSource", data.ResourceName),
		methodName: "mapReadModelToSchema",
		modelName:  *data.DataSourceReadOperation.SDKModelName,

		// TODO: mapping definitions
	}
	mappingCode, err := mapper.modelToSchemaCode()
	if err != nil {
		return nil, fmt.Errorf("generating mapping code: %+v", err)
	}

	contents := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"time"

	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
)

func (ds %[2]sDataSource) Read() tfsdk.ResourceFunc {
	return tfsdk.ResourceFunc{
		Func: func(ctx context.Context, metadata tfsdk.ResourceMetaData) error {
			client := metadata.Client.%[4]s

			id := %[5]s
			metadata.Logger.Infof("Retrieving %%s..", id)
			resp, err := client.%[6]s(ctx, id)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return fmt.Errorf("%%s was not found", id)
				}
				return fmt.Errorf("retrieving %%s: %%+v", id, err)
			}

			metadata.Logger.Infof("Decoding schema into model for %%s..", id)
			var schema %[2]sDataSourceModel
			metadata.Logger.Infof("Mapping %%s..", id)
			if err := ds.mapReadModelToSchema(&model); err != nil {
				return fmt.Errorf("mapping response model to schema for %%s: %%+v", id, err)
			}

			metadata.SetID(id)
			return metadata.Encode(&schema)
		},
		Timeout: %[3]d * time.Minute,
	}
}

%[7]s
`, data.PackageName, data.ResourceName, timeoutInMinutes, data.ClientName, idConstructor, sdkMethodName, *mappingCode)
	return &contents, nil
}
