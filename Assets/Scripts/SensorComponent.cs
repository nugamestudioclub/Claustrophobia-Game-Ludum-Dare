using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorComponent : MonoBehaviour
{
    private SensorTrigger[] triggers;
    // Start is called before the first frame update
    void Start()
    {
        triggers = this.GetComponentsInChildren<SensorTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        bool triggered = false;
        foreach(SensorTrigger trigger in triggers)
        {
            triggered = trigger || trigger.IsTriggered;
        }
        if (triggered)
        {
            foreach (SensorTrigger trigger in triggers)
            {
                
                trigger.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
            }
        }
    }
}
