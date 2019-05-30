using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txt;
    public UnityEngine.UI.Text amm;
    public UnityEngine.UI.Text hp;
    private bool isPause = false;
    private int cont = 0;
    bool f1 = true;
    bool f2 = true;
    bool f3 = true;
    bool f4 = true;
    public AudioSource collect;
    float health = 15;
    int ammo = 60;
    private float masterVolume = 1;
    float h;


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
            h = (health / 15) * 100;
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
        transform.Find("PauseMenu").gameObject.SetActive(true);        
        isPause = true;

    }
    public void Continue()
    {
        transform.Find("PauseMenu").gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
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
        transform.Find("Defeat").gameObject.SetActive(true);

    }
    public void Restart()
    {

        SceneManager.LoadScene("Level1");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("GUI");
    }
    public void StartL()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Pre()
    {
        SceneManager.LoadScene("Preface");
    }


}

