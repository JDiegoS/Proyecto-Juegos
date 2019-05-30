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

    private int weaponSelected = 0;
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
    public GameObject hint;
    public int Health = 1;
    bool muerto = false;
    float regenTime;
    float healthT=-15;
    int ammo = 60;
    bool reg = false;
    public GameObject menu;
    float deathTime;

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
            deathTime = Time.time;
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Stop();
            gunsound.PlayOneShot(scream);
            Time.timeScale = .50f;
            animPlayer.Play("deathP");
            muerto = true;
            menu.SendMessage("Defeat");
        }
        if (Health <= 3 && muerto == false && (Time.time - healthT >= 12))
        {
            healthT = Time.time;
            if (reg == false)
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
                menu.SendMessage("SumarHP");
                gunsound.Stop();
                reg = false;

            }
        }
        if (Input.GetKey(KeyCode.H))
        {
            hint.SetActive(true);
        }
    }
    private void Shoot()
    {
        if (muerto != true)
        {


            if (Input.GetButton("Fire1") && weaponSelected == 1)
                if (Time.time - lastFired > 0.55)
                {
                    lastFired = Time.time;


                    //No gasta ammo nunca

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
            if (Input.GetButton("Fire1") && weaponSelected == 2 && ammo > 0)
                if (Time.time - lastFired > 0.15)
                {
                    lastFired = Time.time;

                    menu.SendMessage("ContadorA");
                    ammo -= 1;

                    AudioSource gunsound = GetComponent<AudioSource>();
                    gunsound.PlayOneShot(fire);

                    animAK.Play("GunshotAK");

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
        }
        

    }

    private void Switch()
    {
        if (muerto != true)
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
    void GotHit()
    {
        menu.SendMessage("ContadorHP");
        Health -= 1;

    }
    void activateW()
    {
        weaponSelected = 1;
    }
}

    
