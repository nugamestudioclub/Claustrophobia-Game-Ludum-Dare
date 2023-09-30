using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorComponent : MonoBehaviour
{
    private SensorTrigger[] triggers;
    public bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        triggers = this.GetComponentsInChildren<SensorTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        triggered = false;
        foreach(SensorTrigger trigger in triggers)
        {
            triggered = triggered || trigger.IsTriggered;
        }
        
    }
}
