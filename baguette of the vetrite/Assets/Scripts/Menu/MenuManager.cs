 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private float volume;
    private void Start()
    {
    }
    public void OpenOption()
    { 
        volume = PlayerPrefs.GetFloat("Volume", 0);
        GameObject.Find("SliderVolume").GetComponent<Slider>().value = volume;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Save()
    {
        volume = GameObject.Find("SliderVolume").GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
