using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour {

    public GameObject tank;

    private Slider slider;
    private Energy tankEnergy;

    void Start () {
        slider = this.GetComponent<Slider>();
        tank.GetComponent<EventManager>().GetEvent("increaseEnergy").AddListener(increaseEnergy);
        tankEnergy = tank.GetComponent<Energy>();
	}

    private void increaseEnergy()
    {
        slider.value = tankEnergy.getEnergyPercent();
    }
}
