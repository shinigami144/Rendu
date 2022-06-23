using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Button MissionButton;
    public UnityEngine.UI.Button TempButton;
    public UnityEngine.UI.Button ViabilityButton;
    public UnityEngine.UI.Button MaterialButton;
    public UnityEngine.UI.Button PlaneteType;
    public UnityEngine.UI.Slider Musique;
    public UnityEngine.UI.Button MenuPrincipal;
    public UnityEngine.UI.Button back;
    public UnityEngine.UI.Image Tuto;
    public Sprite BaseBackGroundImage;
    public List<Sprite> MissionImage;
    public Sprite TempImage;
    public Sprite ViabilityImage;
    public Sprite MaterialImage;
    public Sprite PlaneteImage;
    private bool missionActif;
    private int indexMission;

    private void Awake()
    {
        setPositionObject();
        MenuPrincipal.onClick.AddListener(menu);
        Musique.onValueChanged.AddListener(musiqueModif);
        Tuto.gameObject.SetActive(false);
        this.GetComponent<UnityEngine.UI.Image>().sprite = BaseBackGroundImage;
        MissionButton.onClick.AddListener(MissionClick);
        TempButton.onClick.AddListener(TempClick);
        ViabilityButton.onClick.AddListener(ViablilityClick);
        MaterialButton.onClick.AddListener(MaterialClick);
        PlaneteType.onClick.AddListener(PlaneteClick);
        back.onClick.AddListener(gameBack);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameBack()
    {
        this.gameObject.SetActive(false);
    }
    public void TempClick(){ ButtonClick(TempImage); }
    public void ViablilityClick() { ButtonClick(ViabilityImage); }
    public void MaterialClick() { ButtonClick(MaterialImage); }
    public void PlaneteClick() { ButtonClick(PlaneteImage); }

    public void musiqueModif(float value)
    {
        FindObjectOfType<Camera>().GetComponent<AudioSource>().volume = value / 100;
    }

    public void menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void ButtonClick(Sprite image)
    {
        Tuto.sprite = image;
        missionActif = false;
        Tuto.gameObject.SetActive(true);
    }

    public void MissionClick()
    {
        indexMission = 0;
        missionActif = true;
        Tuto.sprite = MissionImage[indexMission];
        Tuto.gameObject.SetActive(true);
    }

    public void TutoClcik()
    {
        if (missionActif)
        {
            indexMission++;
            Debug.Log(indexMission + "/" + MissionImage.Count);
            if(indexMission <= MissionImage.Count-1)
            {
                Tuto.sprite = MissionImage[indexMission];
            }
            else
            {
                Tuto.gameObject.SetActive(false);
            }
        }
        else
        {
            Tuto.gameObject.SetActive(false);
        }
    }

    private void setPositionObject()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
        Tuto.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
        MissionButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(2*Screen.width/15, Screen.height / 9, 0);
        MissionButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        TempButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(3*Screen.width / 15, Screen.height/9, 0);
        TempButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        PlaneteType.GetComponent<RectTransform>().anchoredPosition = new Vector3(4 * Screen.width / 15, Screen.height / 9, 0);
        PlaneteType.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        MaterialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(5 * Screen.width / 15, Screen.height / 9, 0);
        MaterialButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        ViabilityButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(6 * Screen.width / 15, Screen.height / 9, 0);
        ViabilityButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        Musique.GetComponent<RectTransform>().anchoredPosition = new Vector3( 4*Screen.width / 20, -Screen.height / 9, 0);
        Musique.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 160);
        Musique.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        Musique.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(-Musique.GetComponent<RectTransform>().sizeDelta.x/2, 0, 0);
        MenuPrincipal.GetComponent<RectTransform>().anchoredPosition = new Vector3(6 * Screen.width / 20, -Screen.height / 9, 0);
        MenuPrincipal.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        back.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -Screen.height / 9, 0);

        // Image a droite
        // Le text sur la gauche 
        // Retour en haut a droite 
        // bouton valider vert en bas et rouge en 
    }
}
