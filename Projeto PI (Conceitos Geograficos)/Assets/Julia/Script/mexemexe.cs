using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class mexemexe : MonoBehaviour
{
    public SliderJoint2D slider; 
    public JointMotor2D temp;

    void Start()
    {
        temp = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            temp.motorSpeed = 1;
            slider.motor = temp;
        }
        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            temp.motorSpeed = -1;
            slider.motor = temp;
        }
    }
}
