using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoviing : MonoBehaviour
{
    public GameObject trigger;
    public AudioClip cop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        AudioSource gunsound = GetComponent<AudioSource>();
        gunsound.PlayOneShot(cop, .9f);
        if (other.gameObject.name == "Player")
        {
            Destroy(trigger);
        }
    }

    
}
