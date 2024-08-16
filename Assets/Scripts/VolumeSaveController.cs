using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Text volTextUI= null;


    private void Start()
    {
        LoadValues();
    }
    public void VolumeSlider (float volume)
    {
        volTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {

        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();

    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }


}
