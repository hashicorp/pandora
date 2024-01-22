# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0



provider "azurerm" {
  features {}
}

resource "azurerm_kubernetes_cluster_trusted_access_role_binding" "test" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.test.id
  name                  = "acctestkctarb-${var.random_string}"
  roles                 = ["Microsoft.MachineLearningServices/workspaces/mlworkload"]
  source_resource_id    = azurerm_machine_learning_workspace.test.id
}

