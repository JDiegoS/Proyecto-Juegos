using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public Animation anim;
    float animReset;
    bool reset = true;
    bool sono = false;
    public AudioClip clip;

    public UnityEngine.UI.Text txt;

    // Start is called before the first frame update
    void Start()
    {
        animReset = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(sono == false)
        {
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.PlayOneShot(clip, .9f);
            sono = true;
        }
        
        txt.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.H))
        {
            if (Time.time - animReset >= 5)
            {
                animReset = Time.time;
                anim.Play("Hint");

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        txt.gameObject.SetActive(false);
    }
}
