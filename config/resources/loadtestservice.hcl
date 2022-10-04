/*
service "LoadTestService" {
  terraform_package = "loadtestservice"

  api "2021-12-01-preview" {
    package "LoadTests" {
      definition "load_test" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LoadTestService/loadTests/{loadTestName}"
        display_name = "Load Test"
        website_subcategory = "Load Test"
        description = "Manages a Load Test Service"
      }
    }
  }
}
*/