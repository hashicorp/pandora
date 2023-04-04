using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Functions;

internal class Definition : ResourceDefinition
{
    public string Name => "Functions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrReplaceOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByStreamingJobOperation(),
        new RetrieveDefaultDefinitionOperation(),
        new TestOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UdfTypeConstant),
        typeof(UpdateModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AggregateFunctionPropertiesModel),
        typeof(AzureMachineLearningServiceFunctionBindingModel),
        typeof(AzureMachineLearningServiceFunctionBindingPropertiesModel),
        typeof(AzureMachineLearningServiceFunctionBindingRetrievalPropertiesModel),
        typeof(AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParametersModel),
        typeof(AzureMachineLearningServiceInputColumnModel),
        typeof(AzureMachineLearningServiceOutputColumnModel),
        typeof(AzureMachineLearningStudioFunctionBindingModel),
        typeof(AzureMachineLearningStudioFunctionBindingPropertiesModel),
        typeof(AzureMachineLearningStudioFunctionBindingRetrievalPropertiesModel),
        typeof(AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersModel),
        typeof(AzureMachineLearningStudioInputColumnModel),
        typeof(AzureMachineLearningStudioInputsModel),
        typeof(AzureMachineLearningStudioOutputColumnModel),
        typeof(CSharpFunctionBindingModel),
        typeof(CSharpFunctionBindingPropertiesModel),
        typeof(CSharpFunctionBindingRetrievalPropertiesModel),
        typeof(CSharpFunctionRetrieveDefaultDefinitionParametersModel),
        typeof(ErrorResponseModel),
        typeof(FunctionModel),
        typeof(FunctionBindingModel),
        typeof(FunctionConfigurationModel),
        typeof(FunctionInputModel),
        typeof(FunctionOutputModel),
        typeof(FunctionPropertiesModel),
        typeof(FunctionRetrieveDefaultDefinitionParametersModel),
        typeof(JavaScriptFunctionBindingModel),
        typeof(JavaScriptFunctionBindingPropertiesModel),
        typeof(JavaScriptFunctionBindingRetrievalPropertiesModel),
        typeof(JavaScriptFunctionRetrieveDefaultDefinitionParametersModel),
        typeof(ResourceTestStatusModel),
        typeof(ScalarFunctionPropertiesModel),
    };
}
