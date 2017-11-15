namespace Nihilism {
	public static class NihilismAPI {
		public static NihilismConfigData GetModSettings() {
			return NihilismMod.Instance.Config.Data;
		}
	}
}
