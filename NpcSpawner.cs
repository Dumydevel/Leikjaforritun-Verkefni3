using UnityEngine;

namespace Assets
{
	public class NpcSpawner : MonoBehaviour
	{
		public GameObject NpcToSpawn;

		public float MaxCoolDown = 5f;
		private float _cooldown;
		public void Update()
		{
			if (_cooldown > 0)
			{
				_cooldown -= Time.deltaTime;
				return;
			}
			_cooldown = MaxCoolDown;
			Instantiate(NpcToSpawn, new Vector3(Random.Range(0, 100), 100, Random.Range(0, 100)), Quaternion.identity);
		}

	}
}
