using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanevasGestionnaire : MonoBehaviour
{
    public UnityEngine.UI.Button modeSalon;
    public UnityEngine.UI.Button modePlayer;
    public UnityEngine.UI.Button quit;
    public UnityEngine.UI.Image back;

    public UnityEngine.UI.Text titre;

    private void Awake()
    {
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        quit.onClick.AddListener(AppQuit);
        quit.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width/4, -Screen.height / 3, 0);
        quit.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/4, Screen.height/6);
        modePlayer.onClick.AddListener(modeNormal);
        modePlayer.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width/4, Screen.height / 3, 0);
        modePlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 4, Screen.height / 6);
        modeSalon.onClick.AddListener(modeInfini);
        modeSalon.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width/4, 0, 0);
        modeSalon.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 4, Screen.height / 6);
        titre.GetComponent<RectTransform>().anchoredPosition = new Vector3(-Screen.width / 4, 0, 0);
        titre.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2, Screen.height / 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void modeInfini() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("InfiniteMode", 1);
    }

    public void modeNormal()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("InfiniteMode", 0);
    }

    public void AppQuit()
    {
        Application.Quit();
    }

}
