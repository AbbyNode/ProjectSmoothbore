using System;
using UnityEngine;

public class GlobalManager {
	
	public static EventManager GetPlayerEventManager(Transform childTransform) {
		return GetPlayerComponent<EventManager>(childTransform) as EventManager;
	}
	
	public static Energy GetPlayerEnergy(Transform childTransform) {
		return GetPlayerComponent<Energy>(childTransform) as Energy;
	}
	
	/// <summary>
	/// Finds the closest parent with the "Player" tag, then returns the ComponentType component of that object.
	/// </summary>
	/// <typeparam name="ComponentType"></typeparam>
	/// <param name="childTransform"></param>
	/// <returns></returns>
	public static ComponentType GetPlayerComponent<ComponentType>(Transform childTransform) {
		GameObject player = FindParentWithTag(childTransform, "Player");
		if (player == null) {
			Debug.LogError("Could not find Player parent of " + childTransform.name);
			return default(ComponentType);
		}

		ComponentType c = player.GetComponent<ComponentType>();
		if (c == null) {
			Debug.LogError(childTransform.name + " parent Player does not have a " + typeof(ComponentType));
		}

		return c;
	}

	public static GameObject FindParentWithTag(Transform childTransform, string tag) {
		Transform parentTransform = childTransform.parent.transform;

		while (parentTransform != null) {
			if (parentTransform.tag == tag) {
				return parentTransform.gameObject;
			}
			parentTransform = parentTransform.parent;
		}

		return null;
	}
}

// http://answers.unity3d.com/questions/28581/traverse-up-the-hierarchy-to-find-first-parent-wit.html?childToView=990572#answer-990572
