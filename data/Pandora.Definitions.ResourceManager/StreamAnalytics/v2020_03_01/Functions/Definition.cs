using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Functions;

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
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AggregateFunctionPropertiesModel),
        typeof(AzureMachineLearningWebServiceFunctionBindingModel),
        typeof(AzureMachineLearningWebServiceFunctionBindingPropertiesModel),
        typeof(AzureMachineLearningWebServiceFunctionBindingRetrievalPropertiesModel),
        typeof(AzureMachineLearningWebServiceFunctionRetrieveDefaultDefinitionParametersModel),
        typeof(AzureMachineLearningWebServiceInputColumnModel),
        typeof(AzureMachineLearningWebServiceInputsModel),
        typeof(AzureMachineLearningWebServiceOutputColumnModel),
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
