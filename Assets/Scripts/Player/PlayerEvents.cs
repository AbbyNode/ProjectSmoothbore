using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvents {
	public static readonly string Move = "move";
	public static readonly string EnergyChanged = "energyChanged";
	public static readonly string BreakCrate = "BreakCreate";
	public static readonly string HitPlayer = "HitPlayer";
	public static readonly string KilledPlayer = "KilledPlayer";
}

/* ===============================
 * Known Event Names
 * 
 * move				Player moves
 * energyChanged	Player's energy increases or decrease
 * breakCrate		Player breaks a crate
 * hitPlayer		Player hits another player
 * killPlayer		Player hits another player, resulting in a kill
 * =============================== */
