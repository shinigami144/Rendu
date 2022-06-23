using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMenuScript : MonoBehaviour
{
    public UnityEngine.UI.Image imagePlanet;
    public UnityEngine.UI.Text textPlanet;
    public UnityEngine.UI.Button Viable;
    public UnityEngine.UI.Button NonViable;
    public UnityEngine.UI.Button Retour;
    private bool viablilite;
    private GestionnaireUi GUI;
    private ObjectStelaireScript selectedObject;
    private bool infiniteMode;
    private void Awake()
    {
        setPositionObject();
        SetOnClicklistner();
        if(PlayerPrefs.GetInt("InfiniteMode") == 1)
        {
            infiniteMode = true;
        }
        else
        {
            infiniteMode = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GUI = FindObjectOfType<GestionnaireUi>();

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        this.gameObject.SetActive(false);
    }

    public void FViable()
    {
        selectedObject.Complet = true ;
        if(viablilite == true)
        {
            GUI.increaseScore();
        }
        else
        {
            GUI.decreaseScore();
        }
        Back();
    }
    public void FNonViable()
    {
        selectedObject.Complet = true;
        if (viablilite == false)
        {
            GUI.increaseScore();
        }
        else
        {
            GUI.decreaseScore();
        }
        Back();
    }   

    private void SetOnClicklistner()
    {
        this.Retour.onClick.AddListener(Back);
        this.Viable.onClick.AddListener(FViable);
        this.NonViable.onClick.AddListener(FNonViable);
    }

    private void setPositionObject()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2, Screen.height/2);
        imagePlanet.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 5, Screen.height / 3);
        imagePlanet.GetComponent<RectTransform>().position = new Vector3(Screen.width/4, Screen.height/(1.8f), 0);
        textPlanet.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 5, Screen.height / 3);
        textPlanet.GetComponent<RectTransform>().position = new Vector3(3 * Screen.width / 4, Screen.height /(1.8f),0);
        Viable.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 10, Screen.height / 9);
        Viable.GetComponent<RectTransform>().position = new Vector3(Screen.width / 4, Screen.height / 9,0);
        NonViable.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 10, Screen.height / 9);
        NonViable.GetComponent<RectTransform>().position = new Vector3(3 * Screen.width / 4, Screen.height / 9,0);
        Retour.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/20, Screen.height/20);
        Retour.GetComponent<RectTransform>().position = new Vector3(18 * Screen.width / 20, 18 * Screen.height / 20, 0);
        // Image a droite
        // Le text sur la gauche 
        // Retour en haut a droite 
        // bouton valider vert en bas et rouge en 
    }

    public void setInfo(ObjectStelaire obj, ObjectStelaireScript script)
    {
        selectedObject = script;
        Debug.Log("Info");
        this.viablilite = obj.viable;
        this.imagePlanet.sprite = obj.spritePlanet;
        string textInformation = StructuredText(obj);
        this.textPlanet.text = textInformation;
        if(script.Complet == true && !infiniteMode)
        {
            Viable.gameObject.SetActive(false);
            NonViable.gameObject.SetActive(false);
        }
        else
        {
            Viable.gameObject.SetActive(true);
            NonViable.gameObject.SetActive(true);
        }

    }

    private string textFromMaterial(bool b)
    {
        if (b)
        {
            return "| V ";
        }
        else
        {
            return "| X ";
        }
    }

    private string StructuredText(ObjectStelaire obj)
    {
        string txt = "";
        txt += (obj.Name + " : " + obj.Information) + "\n";
        if(obj.Rayon != "")
        {
            txt += "Rayon : " + obj.Rayon + " Km\n";
        }
        if( obj.Masse != "")
        {
            txt += "Masse : " + obj.Masse + " KG\n";
        }
        if (obj.distanceDuSoleil != "")
        {
            txt += "Dist with Sol : " + obj.distanceDuSoleil + " KM\n";
        }
        if( obj.temperature != "")
        {
            if (obj.celcuice)
            {
                txt += "Temperature moyenne : " + obj.temperature + "\n";
            }
            else
            {
                txt += "Temperature moyenne : " + obj.temperature + " °K\n";
            }
        }
        if(obj.type != "")
        {
            txt += "Type de planet : " + obj.type + "\n";
        }
        if( obj.Gravite  != "")
        {
            txt += "Gravite : " + obj.Gravite + " Newton\n";
        }
        txt += "| O | N | C | H |\n";
        bool[] l = { obj.Oxygene, obj.Azote, obj.Carbone, obj.Oxygene };
        for (int i = 0; i < l.Length; i++)
        {
            txt += textFromMaterial(l[i]);
            if( i == 0)
            {
                txt += " ";
            }
        }
        txt += "|\n";
        return txt;
    }

}
