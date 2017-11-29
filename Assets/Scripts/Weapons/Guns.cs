using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Guns {

	public static List<GunDefinition> gunDefinitions;

	static Guns() {
		gunDefinitions = new List<GunDefinition>();

	}
}

public abstract class GunDefinition {
	public Sprite gunSprite;
	public FireGun fireGunDeligate;

	public GunDefinition(Sprite gunSprite, FireGun fireGunDeligate) {
		this.gunSprite = gunSprite;
		this.fireGunDeligate = fireGunDeligate;
	}

	public delegate void FireGun();
}
