using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlowCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Bank");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
