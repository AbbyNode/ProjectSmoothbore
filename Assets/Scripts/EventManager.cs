using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventFloat : UnityEvent<float> { }

public class EventManager : MonoBehaviour {
	private Dictionary<string, UnityEventFloat> _events = new Dictionary<string, UnityEventFloat>();

	public UnityEventFloat GetEvent(string name) {
		UnityEventFloat e;

		_events.TryGetValue(name, out e);

		if (e == null) {
			e = new UnityEventFloat();
			_events.Add(name, e);
		}

		return e;
	}
}
