package testing

type testDependencies struct {
	variables testVariables

	// NOTE: use the Set methods
	needsClientConfig         bool
	needsEdgeZone             bool
	needsKeyVault             bool
	needsKeyVaultKey          bool
	needsNetworkInterface     bool
	needsPublicIP             bool
	needsResourceGroup        bool
	needsSubnet               bool
	needsUserAssignedIdentity bool
	needsVirtualNetwork       bool

	// TODO: this obviously isn't going to scale, so we should:
	//
	//   1. In the medium-term, look these up using a struct which
	//      defines it's dependencies so this is manageable.
	//
	//   2. In the longer-term, can we infer the dependencies from
	//      the reference name, for example `virtual_network.test`
	//      and find the matching `basic` test and reference that?
}

func (d *testDependencies) setNeedsClientConfig() {
	d.needsClientConfig = true
}

func (d *testDependencies) setNeedsEdgeZones() {
	d.needsEdgeZone = true

	d.variables.needsPrimaryLocation = true
}

func (d *testDependencies) setNeedsKeyVault() {
	d.setNeedsResourceGroup()
	d.setNeedsClientConfig()
	d.needsKeyVault = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsKeyVaultKey() {
	d.setNeedsKeyVault()
	d.needsKeyVaultKey = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsNetworkInterface() {
	d.setNeedsSubnet()

	d.needsNetworkInterface = true
}

func (d *testDependencies) setNeedsPublicIP() {
	d.setNeedsVirtualNetwork()
	d.needsPublicIP = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsResourceGroup() {
	d.needsResourceGroup = true

	d.variables.needsRandomInteger = true
	d.variables.needsPrimaryLocation = true
}

func (d *testDependencies) setNeedsSubnet() {
	d.setNeedsVirtualNetwork()
	d.needsSubnet = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsUserAssignedIdentity() {
	d.setNeedsResourceGroup()
	d.needsUserAssignedIdentity = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsVirtualNetwork() {
	d.setNeedsResourceGroup()
	d.needsVirtualNetwork = true

	d.variables.needsPrimaryLocation = true
	d.variables.needsRandomInteger = true
}
