using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txt;
    private bool isPause = false;
    private int cont = 0;
    bool f1 = true;
    bool f2 = true;
    bool f3 = true;
    bool f4 = true;
    public AudioSource collect;
    private float masterVolume = 1;


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
        if (GameObject.Find("Ficha 1") == null && f1 == true)
        {
            //collect.Play();
            cont += 1;
            Contador();
            f1 = false;
        }
        if (GameObject.Find("Ficha 2") == null && f2 == true)
        {
            //collect.Play();
            cont += 1;
            Contador();
            f2 = false;
        }
        if (GameObject.Find("Ficha 3") == null && f3 == true)
        {
            //collect.Play();
            cont += 1;
            Contador();
            f3 = false;
        }
        if (GameObject.Find("Ficha 4") == null && f4 == true)
        {
            //collect.Play();
            cont += 1;
            Contador();
            f4 = false;
        }
        if (cont == 5)
        {
            Victory();
        }
        if (GameObject.Find("Player") == null)
        {
            Defeat();
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
    public void Contador()
    {
        txt.text = "Coins: " + cont;
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

        SceneManager.LoadScene("Maze");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

