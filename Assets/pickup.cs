using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public UnityEngine.UI.Text txt;
    public UnityEngine.UI.Image im;
    public UnityEngine.UI.Text amm;
    public UnityEngine.UI.RawImage ammo;
    public GameObject ak;
    public GameObject pistol;
    public GameObject trig;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        txt.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            ak.SetActive(true);
            pistol.SetActive(true);
            txt.gameObject.SetActive(false);
            im.gameObject.SetActive(true);
            amm.gameObject.SetActive(true);
            ammo.gameObject.SetActive(true);
            player.SendMessage("activateW");
            Destroy(trig);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        txt.gameObject.SetActive(false);
    }
}
