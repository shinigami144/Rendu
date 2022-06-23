using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStelaireScript : MonoBehaviour
{

    public ObjectStelaire scriptObject;
    private GestionnaireUi GUI;
    private bool complet;
    // Start is called before the first frame update
    public bool Complet{
        get { return complet; }
        set { complet = value; }
    }
    private void Awake()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ClickOnButton);
        GUI = FindObjectOfType<GestionnaireUi>();
        this.GetComponent<UnityEngine.UI.Image>().sprite = scriptObject.spritePlanet;
    }
    void Start()
    {
        complet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnButton()
    {
        GUI.SetInfoPlanet(this.scriptObject, this);
    }

    
}