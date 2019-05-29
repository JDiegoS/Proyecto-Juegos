using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public Animation anim;
    float animReset;
    bool reset = true;
    // Start is called before the first frame update
    void Start()
    {
        animReset = Time.time;
        anim.Play("Hint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H)){
            if (Time.time - animReset >= 5){
                animReset = Time.time;
                anim.Play("Hint");
                
            }
        }
    }
}
