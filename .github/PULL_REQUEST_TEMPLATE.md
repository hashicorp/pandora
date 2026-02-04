<!--  All Submissions -->

## Community Note
<!-- Please leave the community note as is. -->
* Please vote on this PR by adding a :thumbsup: [reaction](https://blog.github.com/2016-03-10-add-reactions-to-pull-requests-issues-and-comments/) to the original PR to help the community and maintainers prioritize for review
* Please do not leave comments along the lines of "+1", "me too" or "any updates", they generate extra noise for PR followers and do not help prioritize for review


## Description

<!-- Please include a description below with the reason for the PR, what it is doing, what it is trying to accomplish, and anything relevant for a reviewer to know. -->


## PR Checklist

- [ ] I have checked to ensure there aren't other open [Pull Requests](../pulls) for the same update/change.
- [ ] I have checked if my changes close any open issues. If so, please include appropriate [closing keywords](https://docs.github.com/en/issues/tracking-your-work-with-issues/linking-a-pull-request-to-an-issue#linking-a-pull-request-to-an-issue-using-a-keyword) below.
- [ ] I have used a meaningful PR title to help maintainers and other users understand this change and help prevent duplicate work.


## What is this PR for?

- [ ] This PR is for the **Terraform Azure Provider** (`hashicorp/terraform-provider-azurerm`)
- [ ] This PR is for another downstream project

<!-- If this is NOT for the Terraform Azure Provider, please explain what this change is for: -->


<!-- You can erase any parts of this template below this point that are not applicable to your Pull Request. -->


## Adding New API Version

<!-- Complete this section if adding a new Service or API Version. Otherwise, delete it. -->

- [ ] I have verified the Service/API Version exists in the Azure REST API Specs.
- [ ] I have followed the [Service Import Guide](../blob/main/docs/resource-manager-service-import.md).

### Preview API Version

<!-- If you are adding a preview API version, please answer the following questions. Otherwise, delete this subsection. -->

> [!IMPORTANT]
> We generally do not add preview API versions to `go-azure-sdk`, and we rarely support preview features in the provider. Exceptions require strong justification, such as when preview features have no GA date and or stable API version exists for a service. Please ensure you have thoroughly considered whether a preview API is truly necessary before proceeding.

- [ ] This PR adds a **preview** API version

1. **Is there a stable (GA) version available?**
   <!-- If a stable version exists, explain why the preview version is being used instead. -->

2. **Why should we support this preview API?**
   <!-- Explain the value/necessity of supporting this preview API, e.g., new feature availability, customer demand, etc. -->

3. **Do existing resources already use a preview API?**
   <!-- List any existing resources that currently use a preview API version. -->

4. **What is the expected timeline for GA?**
   <!-- If known, provide the expected date or timeframe for when this API will become stable. -->


## Changes to Tooling

<!-- Complete this section if modifying any tools. Otherwise, delete it. -->

- [ ] I have added an explanation of what my changes do and why I'd like you to include them.
- [ ] I have written new tests for my changes & updated any relevant documentation.
- [ ] I have successfully run tests with my changes locally. If not, please provide details on testing challenges.

**Testing Command(s) Used:**
```shell
# e.g., go test ./tools/generator-go-sdk/...
```

**Testing Evidence:**

<!-- Please include testing logs or evidence here, or an explanation on why no testing evidence can be provided. -->


## Changes to Resource Config

<!-- Complete this section if modifying resource configuration. Otherwise, delete it. -->

- [ ] I have followed the [Resource Generation Guide](../blob/main/docs/resource-manager-generate-new-resource.md).
- [ ] I have verified the required SDK is available in `hashicorp/go-azure-sdk`.


## Related Issue(s)

<!-- Use closing keywords if applicable, e.g., "Fixes #123" -->


## AI Assistance Disclosure

<!-- 
If you are using any kind of AI/LLM assistance to contribute, this must be disclosed in the pull request.

If this is the case, please check the box below and describe the extent of AI usage (e.g., documentation only, code generation, etc.)
-->

- [ ] AI Assisted - This contribution was made by, or with the assistance of, AI/LLMs

<!-- extent of AI usage can be described here -->


> [!NOTE] 
> If this PR changes meaningfully during the course of review, please update the title and description as required.
