service "Compute" {
  terraform_package = "compute"
  
  api "2021-11-01" {
    package "VirtualMachines" {
      definition "virtual_machine" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}"
        display_name = "Virtual Machine"
      }
    }

    package "VirtualMachineScaleSets" {
      definition "virtual_machine_scale_set" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}"
        display_name = "Virtual Machine Scale Set"
      }
    }
  }
}
