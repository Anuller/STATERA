using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float larg;

    private float PlayPos;

    private Transform cam;

    public float ParallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        PlayPos = transform.position.x;
        larg = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);

        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3 (PlayPos + Distance, transform.position.y, transform.position.z);

        if (RePos > PlayPos + larg)
        {
            PlayPos += larg;
        }
        else if (RePos < PlayPos - larg)
        {
            PlayPos -= larg;
        }

    }
}
