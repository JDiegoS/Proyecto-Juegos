using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunAnim : MonoBehaviour
{
    public AudioClip shot;
    bool auto = true;
    private float lastFired;
    private float lastSwitch;
    public float fireRate = 6;
    private int currentAmmo;
    private int weaponSelected = 1;
    public Camera cam;
    public AudioClip fire;
    public AudioClip switchW;
    public AudioClip reload;
    public Animation animAK;
    public Animation animP;
    public GameObject pistol;
    public GameObject ak;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Switch();
    }
    private void Shoot()
    {
        if (Input.GetButton("Fire1") && weaponSelected == 1)
            if (Time.time - lastFired > 0.55)
            {
                lastFired = Time.time;

                //Remove 1 bullet from ammo
                currentAmmo -= 1;

                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.PlayOneShot(fire);

                animP.Play("GunshotP");
                
            }
        if (Input.GetButton("Fire1") && weaponSelected == 2)
            if (Time.time - lastFired > 0.15)
            {
                lastFired = Time.time;

                //Remove 1 bullet from ammo
                currentAmmo -= 1;

                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.PlayOneShot(fire);

                animAK.Play("GunshotAK");

            }

    }

    private void Switch()
    {

    
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponSelected == 1)
            if (Time.time - lastSwitch > 0.7)
            {
                lastSwitch = Time.time;
                pistol.SetActive(false);
                ak.SetActive(true);
                //Switch to AK
                weaponSelected = 2;

                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.PlayOneShot(switchW);


                animAK.Play("TakeoutAK");


            }
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponSelected == 2)
            if (Time.time - lastSwitch > 0.7)
            {
                lastSwitch = Time.time;
                pistol.SetActive(true);
                ak.SetActive(false);

                //Switch to Pistol
                weaponSelected = 1;

                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.PlayOneShot(switchW);


                animP.Play("TakeoutP");

            }
    }
}

    
