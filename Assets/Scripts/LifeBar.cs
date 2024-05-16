using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LifeBar : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxLife(float maxLife)
    {
        slider.maxValue = maxLife; 
    }
    
    public void ChangeActualLife(float actualLife)
    {
        slider.value = actualLife;
    }

    public void StartLifeBar(float actualLife)
    {
        ChangeActualLife(actualLife);
        ChangeMaxLife(actualLife);
    }
}
