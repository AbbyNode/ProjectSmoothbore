using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour
{
    public PlayerManager playerM;
    void Start()
    {
        EventManager eventM = playerM.eventManager;
        eventM.GetEvent(PlayerEvents.EnergyChanged).AddListener((f) =>
        {
            Debug.Log("energychanged");
            if (playerM.energy.GetStatValue() >= 50)
            {
                Debug.Log("energy over 50");
                this.gameObject.SetActive(true);
            }
        });
    }

}
