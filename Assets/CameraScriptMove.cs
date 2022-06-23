using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptMove : MonoBehaviour
{
    int widthCamera;
    int heightCamera;
    public bool CamMoving;
    private int numberX;
    private int numberY;
    public GameObject background;
    public UnityEngine.UI.Image EspaceBackgroundOne;
    public UnityEngine.UI.Image EspaceBackgroundTwo;

    private enum Zone{Up,Left,Right,Down};
    

    private void Awake()
    {
        widthCamera = (int)background.GetComponent<RectTransform>().sizeDelta.x/3;
        heightCamera = (int)background.GetComponent<RectTransform>().sizeDelta.y / 3;
        CamMoving = false;
        numberX = 0;
        numberY = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Move Camera Start -----------------------------------------------------------------------------------------------------------------------------------------------------------
    
    private float CalculateDecal(float ArrivePoint, float axe,float speed)
    {
        float decal = 0;
        if(ArrivePoint < axe)
        {
            decal = speed * Time.deltaTime;
            if(decal+axe < ArrivePoint)
            {
                decal = (ArrivePoint - axe);
            }
        }
        else if (ArrivePoint > axe)
        {
            decal = speed * Time.deltaTime;
            if(decal + axe > ArrivePoint)
            {
                decal = ArrivePoint - axe;
            }
        }
        return decal;
    }
    

    IEnumerator MoveCam(float arriverX, float arriverY, float speedX, float speedY)
    {
        while (CamMoving)
        {
            float decalX =CalculateDecal(arriverX,transform.position.x, speedX);
            float decalY = CalculateDecal(arriverY, transform.position.y, speedY);
            this.transform.position = this.transform.position + new Vector3(decalX, decalY, 0);

            if (decalY == 0 && decalX == 0)
            {
                CamMoving = false;

            }
            yield return new WaitForEndOfFrame();
        }
        
    }

    public void CameraMoveUp()
    {
        Debug.Log("UP");
        if( !(numberY <=-1) || CamMoving == true)
        {
            SetPositionSpaceBackgroundSecond(Zone.Up);
            numberY -= 1;
            this.CameraMove(0, heightCamera);
        }
    }

    public void CameraMoveDown()
    {
        Debug.Log(numberY);
        Debug.Log("DOWN");
        if (!(numberY >= 1) || CamMoving == true)
        {
            SetPositionSpaceBackgroundSecond(Zone.Down);
            numberY += 1;
            this.CameraMove(0, -heightCamera);
        }
    }

    public void CameraMoveLeft()
    {
        Debug.Log("LEFT");
        if (!(numberX <= -1) || CamMoving == true)
        {
            SetPositionSpaceBackgroundSecond(Zone.Left);
            numberX -= 1;
            this.CameraMove(-widthCamera, 0);
        }
    }

    public void CameraMoveRight()
    {
        Debug.Log("RIGHT");
        if (!(numberX >= 1) || CamMoving == true)
        {
            SetPositionSpaceBackgroundSecond(Zone.Right);
            numberX += 1;
            this.CameraMove(widthCamera, 0);
        }
    }

    private void CameraMove(int x, int y)
    {
        if(CamMoving == false)
        {
            CamMoving = true;
            StopAllCoroutines();
            StartCoroutine(MoveCam(this.transform.position.x + x, this.transform.position.y + y,x,y));
        } 

    }

    private void MoveBackground(int moveX, int moveY, UnityEngine.UI.Image theBackground , UnityEngine.UI.Image theOtherBackground)
    {
        Vector2 sizedeltaBackground = theBackground.GetComponent<RectTransform>().sizeDelta;
        if(moveX != 0)
        {
            if( moveX > 0)
            {
                if(theBackground.transform.position.x + sizedeltaBackground.x < this.transform.position.x)
                {
                    theBackground.transform.position = theOtherBackground.transform.position + new Vector3(sizedeltaBackground.x, 0, 0);
                }
            }
            else
            {
                if (theBackground.transform.position.x - sizedeltaBackground.x > this.transform.position.x)
                {
                    theBackground.transform.position = theOtherBackground.transform.position - new Vector3(sizedeltaBackground.x, 0, 0);
                }
            }
        }
        else
        {
            if (moveY > 0)
            {
                if (theBackground.transform.position.y + sizedeltaBackground.y < this.transform.position.y)
                {
                    theBackground.transform.position = theOtherBackground.transform.position + new Vector3(sizedeltaBackground.y, 0, 0);
                }
            }
            else
            {
                if (theBackground.transform.position.y - sizedeltaBackground.y > this.transform.position.y)
                {
                    theBackground.transform.position = theOtherBackground.transform.position - new Vector3(sizedeltaBackground.y, 0, 0);
                }
            }
        }
    }

    private void SetPositionSpaceBackgroundSecond(Zone zone)
    {
        switch (zone)
        {
            case Zone.Up:
                //EspaceBackgroundTwo.transform.position = new Vector3(this.transform.position.x, EspaceBackgroundOne.GetComponent<RectTransform>().sizeDelta.y, 0);
                break;
            case Zone.Down:
                //EspaceBackgroundTwo.transform.position = new Vector3(this.transform.position.x, -EspaceBackgroundOne.GetComponent<RectTransform>().sizeDelta.y, 0);
                break;
            case Zone.Left:
                //EspaceBackgroundTwo.transform.position = new Vector3(-EspaceBackgroundOne.GetComponent<RectTransform>().sizeDelta.x,this.transform.position.y, 0);
                break;
            case Zone.Right:
                //EspaceBackgroundTwo.transform.position = new Vector3(EspaceBackgroundOne.GetComponent<RectTransform>().sizeDelta.x, this.transform.position.y, 0);
                break;
            default:
                break;

        }
    }

    // Move Camera End -----------------------------------------------------------------------------------------------------------------------------------------------
}
