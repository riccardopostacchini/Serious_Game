using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuonoManagerScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volumeMusica"))
        {
            PlayerPrefs.SetFloat("volumeMusica", 1);
            Carica();
        }

        else
        {
            Carica();
        }
    }

    public void CambiaVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Salva();
    }

    private void Carica()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeMusica");
    }

    private void Salva()
    {
        PlayerPrefs.SetFloat("volumeMusica", volumeSlider.value);
    }
}
