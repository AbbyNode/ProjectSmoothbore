using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHp : MonoBehaviour {
	public PlayerManager playerM;
	public float maxEmission = 6;

	private ParticleSystem particles;

	void Start() {
		particles = this.GetComponent<ParticleSystem>();

		playerM.eventManager.GetEvent(PlayerEvents.HealthChanged).AddListener((health) => {
			ParticleSystem.EmissionModule em = particles.emission;
			em.rateOverTime = ((100 - health) / 100 * maxEmission);
		});
	}
}
