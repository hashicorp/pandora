using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;

internal class Definition : ResourceDefinition
{
    public string Name => "Job";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DistributionTypeConstant),
        typeof(EarlyTerminationPolicyTypeConstant),
        typeof(GoalConstant),
        typeof(IdentityConfigurationTypeConstant),
        typeof(InputDeliveryModeConstant),
        typeof(JobInputTypeConstant),
        typeof(JobLimitsTypeConstant),
        typeof(JobOutputTypeConstant),
        typeof(JobStatusConstant),
        typeof(JobTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(OutputDeliveryModeConstant),
        typeof(RandomSamplingAlgorithmRuleConstant),
        typeof(SamplingAlgorithmTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmlTokenModel),
        typeof(BanditPolicyModel),
        typeof(BayesianSamplingAlgorithmModel),
        typeof(CommandJobModel),
        typeof(CommandJobLimitsModel),
        typeof(CustomModelJobInputModel),
        typeof(CustomModelJobOutputModel),
        typeof(DistributionConfigurationModel),
        typeof(EarlyTerminationPolicyModel),
        typeof(GridSamplingAlgorithmModel),
        typeof(IdentityConfigurationModel),
        typeof(JobBaseModel),
        typeof(JobBaseResourceModel),
        typeof(JobInputModel),
        typeof(JobLimitsModel),
        typeof(JobOutputModel),
        typeof(JobServiceModel),
        typeof(LiteralJobInputModel),
        typeof(MLFlowModelJobInputModel),
        typeof(MLFlowModelJobOutputModel),
        typeof(MLTableJobInputModel),
        typeof(MLTableJobOutputModel),
        typeof(ManagedIdentityModel),
        typeof(MedianStoppingPolicyModel),
        typeof(MpiModel),
        typeof(ObjectiveModel),
        typeof(PipelineJobModel),
        typeof(PyTorchModel),
        typeof(RandomSamplingAlgorithmModel),
        typeof(ResourceConfigurationModel),
        typeof(SamplingAlgorithmModel),
        typeof(SweepJobModel),
        typeof(SweepJobLimitsModel),
        typeof(TensorFlowModel),
        typeof(TrialComponentModel),
        typeof(TritonModelJobInputModel),
        typeof(TritonModelJobOutputModel),
        typeof(TruncationSelectionPolicyModel),
        typeof(UriFileJobInputModel),
        typeof(UriFileJobOutputModel),
        typeof(UriFolderJobInputModel),
        typeof(UriFolderJobOutputModel),
        typeof(UserIdentityModel),
    };
}
