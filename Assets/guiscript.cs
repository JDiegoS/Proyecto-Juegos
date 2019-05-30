using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guiscript : MonoBehaviour
{
    public GameObject cam;
    public GameObject cam2;
    public GameObject mainm;
    public GameObject pref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartL()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Return()
    {
        cam2.SetActive(false);
        cam.SetActive(true);
        mainm.SetActive(true);
        pref.SetActive(false);
    }
    public void Preface()
    {
        cam2.SetActive(true);
        cam.SetActive(false);
        mainm.SetActive(false);
        pref.SetActive(true);
    }
}
