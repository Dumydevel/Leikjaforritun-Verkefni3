using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
	private NavMeshAgent agent;
	private Player Player;

	public Slider HP_Slider;

	public int StrikeDamage;

	private float strikeCoolDown;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		Player = FindObjectOfType<Player>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		var other = collision.transform;
		if (other.tag == "Missile")
		{
			HP_Slider.value--;
			if (HP_Slider.value <= 0)
			{
				Destroy(gameObject);
			}
		}

		if (agent == null)
		{
			agent = gameObject.AddComponent<NavMeshAgent>();
			Destroy(gameObject.GetComponent<Rigidbody>());
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Player == null)
			return;

		if (strikeCoolDown > 0)
		{
			strikeCoolDown -= Time.deltaTime;
			agent.stoppingDistance = 2.5f;
			return;
		}

		if (agent != null && agent.isOnNavMesh)
		{
			var position = Player.transform.position;
			agent.SetDestination(position);

			var distanceToPlayer = Vector3.Distance(position, transform.position);
			if (distanceToPlayer < 3)
			{
				strikeCoolDown = 3;
				Player.DoDamage(StrikeDamage);
			}
		}
	}
}
