service "Compute" {
  api "2021-11-01" {
    package "VirtualMachines" {
      definition "virtual_machine" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}"
        display_name = "Virtual Machine"
      }
    }

    package "VirtualMachineScaleSets" {
      definition "virtual_machine_scale_set" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachinesScaleSets/{virtualMachineScaleSetName}"
        display_name = "Virtual Machine Scale Set"
      }
    }
  }
}
