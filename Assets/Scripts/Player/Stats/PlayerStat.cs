using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {
	private static string NotInitError = "PlayerStat not initialized";

	public PlayerManager playerM;

	private UnityEventFloat _changedEvent;
	private float _maxValue;
	private float _currentValue;

	private bool _isInit;

	private void Start() {
		_isInit = false;
		_currentValue = 0;
	}

	protected void Init(UnityEventFloat changedEvent, float maxValue) {
		_changedEvent = changedEvent;
		_maxValue = maxValue;
		_isInit = true;
	}

	public void AdjustStatValue(float amt) {
		if (!_isInit) {
			Debug.LogError(NotInitError);
			return;
		}

		float _oldValue = _currentValue; // Store previous value
		_currentValue = Mathf.Clamp(_currentValue + amt, 0, _maxValue); // Set new value (clamp at 0-max)
		if (_currentValue != _oldValue) { // If new value is different
			_changedEvent.Invoke(GetStatPercent()); // Invoke event with percentage
		}
	}

	public void SetStatValue(float amt) {
		if (!_isInit) {
			Debug.LogError(NotInitError);
			return;
		}

		if (_currentValue != amt) {
			_currentValue = amt;
			_changedEvent.Invoke(GetStatPercent());
		}
	}
    public void SetStatPercent(float percent)
    {
        if (!_isInit)
        {
            Debug.LogError(NotInitError);
            return;
        }

        float amt = percent * (_maxValue / 100);

        if (_currentValue != amt)
        {
            _currentValue = amt;
            _changedEvent.Invoke(GetStatPercent());
        }
    }
    public float GetStatValue() {
		return _currentValue;
	}

	public float GetStatPercent() {
		if (!_isInit) {
			Debug.LogError(NotInitError);
			return -1;
		}

		return _currentValue / _maxValue * 100;
	}
}
