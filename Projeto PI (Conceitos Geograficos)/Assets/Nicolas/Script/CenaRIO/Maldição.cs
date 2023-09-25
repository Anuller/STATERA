using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maldição : MonoBehaviour
{

    public SliderJoint2D slider;

    public JointMotor2D temp;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        temp = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        //if(slider.limitState == JointLimitState2D.LowerLimit)
        //{
            //temp.motorSpeed = 1;
            //slider.motor = temp;
        //}
        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            temp.motorSpeed = -1;
            slider.motor = temp;
        }
    }
}
