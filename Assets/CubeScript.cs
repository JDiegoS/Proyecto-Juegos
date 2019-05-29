using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject PlayerC;
    public GameObject Player;
    public float Distance;
    public float speed;
    public float allowedDistance = 5;
    public RaycastHit shot;
    public Animation anims;
    public Animation anima;
    public int Health = 4;
    public GameObject sold;
    bool dead = false;
    float deathtime;
    float t;
    float timeOfShot = 2;
    float chanceOfHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            transform.LookAt(Player.transform);
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            Distance = shot.distance;
            if ((Distance < allowedDistance) && (dead == false) && (Time.time - timeOfShot >1))
            {
                timeOfShot = Time.time;
                speed = 0f;
                anims.Play("shoot");
                chanceOfHit = Random.Range(0, 10);
                Debug.Log ("hola");
                if (chanceOfHit == 7)
                {
                    PlayerC.SendMessage("GotHit");
                }
                //yield return new WaitForSeconds(1);
            }
            if (Distance >= allowedDistance && dead == false)
            {
                speed = 0.02f;
   
                
                anims.Play("run");
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
                
                
            }
        }
        if (Health == 0 && dead == false)
        {
            anims.Play("death");
            dead = true;
            deathtime = Time.time;
        }
        if (dead == true)
        {
            t = Time.time - deathtime;
            if (t >= 3)
            {
                Destroy(sold);
            }

        }
        if (Health == 0 && dead == false)
        {
            anims.Play("death");
            dead = true;
            deathtime = Time.time;
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
    void GotHit()
    {
        Health -= 1;
    }
}

