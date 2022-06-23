using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireUi : MonoBehaviour
{

    public GameObject Help;
    public GameObject InfoPlanet;
    public UnityEngine.UI.Text ScoreText;
    public UnityEngine.UI.Button buttonHelp;
    private int score;
    private int combo;
    // Start is called before the first frame update
    void Start()
    {
        ResizeWithScreen();
        buttonHelp.onClick.AddListener(ClickOnHelp);
        Help.gameObject.SetActive(false);
        InfoPlanet.gameObject.SetActive(false);
        score = 0;
        updateText();
        combo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnHelp()
    {
        Help.gameObject.SetActive(true);
    }

    private void ResizeWithScreen()
    {
        float sizeX = Screen.width;
        int sizing = 12;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if(this.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Button>() != null)
            {
                if(this.transform.GetChild(i).gameObject != buttonHelp.gameObject)
                {
                    this.transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX / (sizing/2), sizeX / sizing);
                    this.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition *= new Vector3(sizeX/26, sizeX/26, 0);
                }
            }
        }
        buttonHelp.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX / sizing,sizeX/sizing);
        buttonHelp.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeX / 19, -sizeX / 19); // attention dois être < sizing x 2 ;
        ScoreText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX / sizing, sizeX / sizing);
        ScoreText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-sizeX / 19, -sizeX / 19);
    }

    private void updateText()
    {
        ScoreText.text = "Score : " + score +  "\n";
    }

    public void SetInfoPlanet(ObjectStelaire obj, ObjectStelaireScript script)
    {
        InfoPlanet.gameObject.SetActive(true);
        InfoPlanet.GetComponent<DataMenuScript>().setInfo(obj, script);
    }
    public void increaseScore()
    {
        score += 10 * combo;
        combo += 1;
        updateText();
    }

    public void decreaseScore()
    {
        score -= 10;
        combo = 1;
        updateText();
    }
}
