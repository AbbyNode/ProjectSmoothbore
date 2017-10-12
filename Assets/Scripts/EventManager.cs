using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

	private Dictionary<string, UnityEvent> _events = new Dictionary<string, UnityEvent>();

	public UnityEvent GetEvent(string name) {
		UnityEvent e;

		_events.TryGetValue(name, out e);

		if (e == null) {
			e = new UnityEvent();
			_events.Add(name, e);
		}

		return e;
	}
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
