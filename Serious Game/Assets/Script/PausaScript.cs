using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaScript : MonoBehaviour
{
    public GameObject menuPausa;

    public static bool inPausa;
    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inPausa)
            {
                Riprendi();
            }
            else
            {
                Pausa();
            }
        }

        if (inPausa && menuPausa != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else { 
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

    public void Pausa()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        inPausa = true;
    }

    public void Riprendi()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        inPausa = false;
    }

    public void TornaAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        inPausa = false;
        
    }

    public void EsciDalGioco()
    {
        Application.Quit();
    }
}
