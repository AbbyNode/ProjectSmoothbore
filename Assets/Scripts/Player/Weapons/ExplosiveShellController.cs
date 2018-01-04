using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveShellController : ShellController {
	public GameObject shellExplosion;
	
	void OnCollisionEnter2D(Collision2D collision) {
		GameObject explosionInst = Instantiate(shellExplosion, this.transform.position, this.transform.rotation);
		
		ShellController shellC = explosionInst.GetComponent<ShellController>();
		shellC.playerM = playerM;
		shellC.Init(BalanceTweaks.GlobalInstance.explosiveGun.shellDamage, 0, 1.1f);
	}
}
