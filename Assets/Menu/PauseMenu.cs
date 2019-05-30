using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txt;
    public UnityEngine.UI.Text amm;
    public UnityEngine.UI.Text hp;
    public UnityEngine.UI.Image aim;
    private bool isPause = false;
    private int cont = 0;
    bool f1 = true;
    bool f2 = true;
    bool f3 = true;
    bool f4 = true;
    public AudioSource collect;
    float health = 20;
    int ammo = 60;
    private float masterVolume = 1;
    float h;
    public AudioClip loss;
    public GameObject pl;
    public GameObject panel;
    public GameObject defeat;
    public GameObject pause;
    public GameObject contr;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject cam;
    public GameObject camp;
    public GameObject caml;
    public GameObject camc;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //collect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //isPause = (isPause) ? Continue() : Pause();
            if (isPause)
            {
                Continue();

            }
            else
                Pause();


        }
        if (health <= 0)
        {
            hp.text = "0%";
        }
        if(health> 0)
        {
            h = (health / 20) * 100;
            hp.text = "" + h + "%";
        }
        if (health <= 0)
        {
            amm.text = "0";
        }
        if (health > 0)
        {
            amm.text = "" + ammo + "";
        }
        
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        cam.SetActive(false);
        caml.SetActive(false);
        
        camc.SetActive(false);

        panel.SetActive(false);
        contr.SetActive(false);
        g1.SetActive(false);
        g2.SetActive(false);
        aim.gameObject.SetActive(false);

        pause.SetActive(true);
        camp.SetActive(true);
        isPause = true;

    }
    public void Continue()
    {
        camc.SetActive(false);
        cam.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        
        caml.SetActive(false);
        camp.SetActive(false);
        contr.SetActive(false);

        
        g1.SetActive(false);
        g2.SetActive(false);
        
        pause.SetActive(false);

        
        aim.gameObject.SetActive(true);
        panel.SetActive(true);

        isPause = false;
    }
    public void ContadorA()
    {
        ammo -= 1;
    }
    public void ContadorHP()
    {
        health = health - 1;
        
    }
    public void SumarHP()
    {
        health += 3;
        
    }
    public void Victory()
    {
        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        transform.Find("Victory").gameObject.SetActive(true);

    }
    public void Defeat()
    {
        Time.timeScale = 0.0f;
        Destroy(pl);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        collect.Stop();
        cam.SetActive(false);
        caml.SetActive(true);
        camp.SetActive(false);
        camc.SetActive(false);
        panel.SetActive(false);
        contr.SetActive(false);
        g1.SetActive(false);
        g2.SetActive(false);
        aim.gameObject.SetActive(false);
        collect.PlayOneShot(loss, 1f);
        defeat.SetActive(true);

    }
    public void Controls()
    {
        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.SetActive(false);
        caml.SetActive(false);
        camp.SetActive(false);
        
        panel.SetActive(false);
        g1.SetActive(false);
        g2.SetActive(false);
        aim.gameObject.SetActive(false);
        defeat.SetActive(false);
        
        pause.SetActive(false);

        contr.SetActive(true);
        camc.SetActive(true);

        isPause = true;
    }
    public void Restart()
    {

        SceneManager.LoadScene("Level 1");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("GUI");
    }
    public void StartL()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Pre()
    {
        SceneManager.LoadScene("Preface");
    }


}

