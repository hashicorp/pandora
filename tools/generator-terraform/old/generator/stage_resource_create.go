package generator

import (
	"fmt"
	"strings"
)

var _ stage = resourceCreateStage{}

type resourceCreateStage struct{}

func (r resourceCreateStage) applicable(data *Data) bool {
	return data.IsResource && data.ResourceCreateOperation != nil && data.ResourceCreateOperation.Generate
}

func (r resourceCreateStage) filePath(data Data) string {
	return fmt.Sprintf("%s_create.go", data.fileNamePrefix)
}

func (r resourceCreateStage) generate(data Data) (*string, error) {
	if data.ResourceReadOperation == nil {
		return nil, fmt.Errorf("Create requires that a ReadOperation is defined to be able to generate Requires Import")
	}

	sdkCreateMethodName := data.ResourceCreateOperation.SDKMethodName
	isLongRunning := data.ResourceCreateOperation.SDKMethodIsLongRunning
	timeoutInMinutes := defaultCreateTimeout
	if data.ResourceCreateOperation.CustomTimeoutInMinutes != nil {
		timeoutInMinutes = *data.ResourceCreateOperation.CustomTimeoutInMinutes
	}

	if isLongRunning {
		sdkCreateMethodName = fmt.Sprintf("%sThenPoll", sdkCreateMethodName)
	}

	sdkReadMethodName := data.ResourceReadOperation.SDKMethodName

	// TODO: we assume everything has an ID at this point which is _fine for now_ but needs fixing
	// TODO: we don't handle options objects but that's _fine_ for now

	idConstructor := "r.IDFromSchema(config)" // which requires someone creates this by hand at present
	if data.SchemaFieldsToResourceIDMappings != nil && len(*data.SchemaFieldsToResourceIDMappings) > 0 {
		segments := make([]string, 0)
		for _, v := range *data.SchemaFieldsToResourceIDMappings {
			segments = append(segments, fmt.Sprintf("model.%s", v))
		}
		idConstructor = fmt.Sprintf("gosdk.New%sID(subscriptionId, %s)", *data.ResourceIDTypeName, strings.Join(segments, ", "))
	}

	mapper := mappingData{
		typeAlias:  "r",
		typeName:   fmt.Sprintf("%sResource", data.ResourceName),
		methodName: "mapSchemaToCreateModel",
		modelName:  *data.ResourceCreateOperation.SDKModelName,

		// TODO: mapping definitions
	}
	mappingCode, err := mapper.schemaToModelCode(false)
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

func (r %[2]sResource) Create() tfsdk.ResourceFunc {
	return tfsdk.ResourceFunc{
		Func: func(ctx context.Context, metadata tfsdk.ResourceMetaData) error {
			client := metadata.Client.%[4]s
			subscriptionId := metadata.Client.Account.SubscriptionId

			var config %[2]sResourceModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %%+v", err)
			}

			id := %[5]s
			metadata.Logger.Infof("Checking for the presence of an existing %%s..", *id)
			existing, err := client.%[7]s(ctx, id)
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %%s: %%+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}

			metadata.Logger.Infof("Mapping create model for %%s..", *id)
			if err := r.mapSchemaToCreateModel(config, &model); err != nil {
				return fmt.Errorf("building model for creation of %%s: %%+v", id, err)
			}

			metadata.Logger.Infof("Creating %%s..", *id)
			if err := client.%[6]s(ctx, id, *model); err != nil {
				return fmt.Errorf("creating %%s: %%+v", *id, err)
			}
			metadata.Logger.Infof("Created %%s.", *id)

			metadata.SetID(id)
			return nil
		},
		Timeout: %[3]d * time.Minute,
	}
}

%[8]s
`, data.PackageName, data.ResourceName, timeoutInMinutes, data.ClientName, idConstructor, sdkCreateMethodName, sdkReadMethodName, *mappingCode)
	return &contents, nil
}
