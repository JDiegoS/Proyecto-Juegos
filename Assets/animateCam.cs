using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateCam : MonoBehaviour
{
    public Animation anim;
    float animtime = -11;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - animtime > 13)
        {
            animtime = Time.time; 
            anim.Play("victoryCam");
        }
    }

}
