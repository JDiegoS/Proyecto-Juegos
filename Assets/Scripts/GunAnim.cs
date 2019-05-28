using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunAnim : MonoBehaviour
{
    public AudioClip shot;
    bool auto = true;
    private float lastFired;
    public float fireRate = 6;
    private int currentAmmo;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
            if (Time.time - lastFired > 1 / fireRate)
            {
                lastFired = Time.time;

                //Remove 1 bullet from ammo
                currentAmmo -= 1;

                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();
                //gunsound.PlayOneShot(shot);

                GetComponent<Animation>().Play("Gunshot");

            }
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.name == "Target")
            {
               // Destroy(t1);
            }
            else if (hit.transform.name == "Target 2")
            {
               // Destroy(t2);
            }
            else if (hit.transform.name == "Target 3")
            {
               // Destroy(t3);
            }
            else if (hit.transform.name == "Target 4")
            {
                //Destroy(t4);
            }
            else if (hit.transform.name == "Target 5")
            {
                //Destroy(t5);
            }

        }
    }
}
