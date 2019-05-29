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
    public AudioClip heavybreathing;
    public AudioClip heartbeat;
    public AudioClip scream;
    public Animation animAK;
    public Animation animP;
    public Animation animPlayer;
    public GameObject pistol;
    public GameObject ak;
    public int Health = 1;
    bool muerto = false;
    float regenTime;
    float healthT=-15;
    bool reg = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Switch();
        if (Health <= 0 && muerto == false)
        {
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Stop();
            gunsound.PlayOneShot(scream);
            animPlayer.Play("deathP");
            muerto = true;
        }
        if(Health <= 3 && muerto == false && (Time.time - healthT >= 12))
        {
            healthT = Time.time;
            if(reg == false)
            {
                regenTime = Time.time;
                reg = true;
            }
            
            Debug.Log(regenTime);
            Debug.Log(healthT);
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.PlayOneShot(heavybreathing, .9f);
            gunsound.PlayOneShot(heartbeat, 1f);
            if (Time.time - regenTime >= 11.9)
            {
                Debug.Log(regenTime);
                Health += 3;
                gunsound.Stop();
                reg = false;

            }
        }

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
                gunsound.PlayOneShot(shot);

                animP.Play("GunshotP");

                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
                {
                    Debug.Log(hit.transform.name);

                    if (hit.transform.tag == "Enemy")
                    {
                        
                        hit.transform.SendMessage("GotHit");
                    }
                }

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

                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
                {


                    if (hit.transform.tag == "Enemy")
                    {

                        hit.transform.SendMessage("GotHit");
                    }
                }
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
    void GotHit()
    {
        Health -= 1;
    }
}

    
