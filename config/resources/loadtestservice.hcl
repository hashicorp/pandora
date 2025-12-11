# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0

/*
service "LoadTestService" {
  terraform_package = "loadtestservice"

  api "2022-12-01" {
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