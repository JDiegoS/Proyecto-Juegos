using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject PlayerC;
    public GameObject Player;
    public float Distance;
    public float speed;
    public int allowedDistance=5;
    public RaycastHit shot;
    public Animation anims;
    public Animation anima;
    public int Health = 4;
    public GameObject sold;
    bool dead = false;
    float deathtime;
    float t;
    float timeOfShot = 2;
    int chanceOfHit;
    public AudioClip fire;
    public AudioClip miss;
    public AudioClip miss2;
    public AudioClip miss3;
    float chance;
    public AudioClip scream;
    float volume;
    public GameObject trigger;
    int rangeD;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == null)
        {
            if (dead == false)
            {
                transform.LookAt(Player.transform);
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                if(shot.rigidbody != null)
                {
                    Distance = shot.distance;
                    if ((Distance < allowedDistance) && (dead == false) && (Time.time - timeOfShot > 1))
                    {
                        timeOfShot = Time.time;
                        speed = 0f;
                        anims.Play("shoot");
                        AudioSource gunsound = GetComponent<AudioSource>();
                        rangeD = allowedDistance / 10;
                        chanceOfHit = Random.Range(0, rangeD + 1);
                        volume = 20 / (Distance);
                        if (volume >= 1f)
                        {
                            gunsound.PlayOneShot(fire, volume);
                        }
                        else
                        {
                            while (volume > 1f)
                            {
                                volume = volume / 1.2f;
                            }
                            gunsound.PlayOneShot(fire, volume);
                        }
                        if (chanceOfHit == rangeD)
                        {
                            PlayerC.SendMessage("GotHit");
                        }

                    }
                    if (Distance >= allowedDistance && dead == false)
                    {
                        speed = 0.05f;


                        anims.Play("run");
                        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);

                    }


                }
                else if (shot.rigidbody == null && (Time.time - timeOfShot > 1.5f) && (Distance <= allowedDistance) && (Distance > 0))
                {
                    timeOfShot = Time.time;
                    chanceOfHit = Random.Range(1, 4);
                    AudioSource gunsound = GetComponent<AudioSource>();
                    if (chanceOfHit == 1)
                    {
                        gunsound.PlayOneShot(miss, .8f);
                    }
                    if (chanceOfHit == 2)
                    {
                        gunsound.PlayOneShot(miss2, .8f);
                    }
                    if (chanceOfHit == 3)
                    {
                        gunsound.PlayOneShot(miss3, .8f);
                    }
                }
            }
            if (Health <= 0 && dead == false)
            {
                volume = 20 / (Distance);
                AudioSource gunsound = GetComponent<AudioSource>();
                while (dead != true)
                {
                    if (volume <= 1f)
                    {
                        anims.Play("death");
                        gunsound.PlayOneShot(scream, volume);
                        dead = true;
                        deathtime = Time.time;
                    }
                    else
                    {
                        volume = volume / 1.2f;
                    }
                }

            }
            if (dead == true)
            {
                t = Time.time - deathtime;
                if (t >= 3)
                {
                    Destroy(sold);
                }

            }

            if (dead == true)
            {
                t = Time.time - deathtime;
                if (t >= 3)
                {
                    Destroy(sold);
                }

            }
        }
        
    }

    void GotHit()
    {
        Health -= 1;
    }
}

