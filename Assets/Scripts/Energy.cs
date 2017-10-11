using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //Oct 7 ,2017

public class Energy : MonoBehaviour
{

    //Oct 7 ,2017..........
    public float maxEnergy = 100;
    public float currentEnergy;
    public float energyNormalSpeed = 1.0f;

    public Slider energybar;

    // Use this for initialization
    void Start()
    {
        currentEnergy = 0;

        energybar.value = calculateEnergy();
    }

    // Update is called once per frame
    void Update()
    {
        //Oct 7 ,2017..........
        currentEnergy += energyNormalSpeed;
        energybar.value = calculateEnergy();
    }

    float calculateEnergy()
    {
        return currentEnergy / maxEnergy;
    }
}
