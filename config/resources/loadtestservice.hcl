service "LoadTestService" {
  terraform_package = "loadtest"

  api "2021-12-01-preview" {
    package "LoadTests" {
      definition "load_test" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LoadTestService/loadTests/{loadTestName}"
        display_name = "Load Test"
      }
    }
  }
}
