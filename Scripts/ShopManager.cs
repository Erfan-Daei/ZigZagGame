using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public string Mat = "Black";
    int Price;
    public Image[] locks;
    public Toggle[] toggles;
    public Image[] diamond;
    public TMP_Text[] color;
    public int whichColor;
    public GameObject WarnPnl;
    public GameObject BuyPnl;

    public GameManager gameManager;

    public Material[] BallMaterials;
    public Material BallDefaultMat;
    public Texture[] BallTextures;

    public bool[] ActiveBalls;

    void Start()
    {
        ChangeBallColor(PlayerPrefs.GetString("Mat"));
        GetActiveBalls();
    }

    public void Black()
    {
        Mat = "Black";
        PlayerPrefs.SetString("Mat", Mat);
        ChangeBallColor(Mat);
    }

    public void Red()
    {
        Mat = "Red";
        whichColor = 0;
        Price = 20;
        Bought();
    }

    public void Green()
    {
        Mat = "Green";
        whichColor = 1;
        Price = 30;
        Bought();
    }

    public void Blue()
    {
        Mat = "Blue";
        whichColor = 2;
        Price = 20;
        Bought();
    }

    public void Purple()
    {
        Mat = "Purple";
        whichColor = 3;
        Price = 50;
        Bought();
    }

    public void White()
    {
        Mat = "White";
        whichColor = 4;
        Price = 10;
        Bought();
    }

    public void Bought()
    {
        if (ActiveBalls[whichColor] == true)
        {
            ChangeBallColor(Mat);
            toggles[whichColor].isOn = true;
            PlayerPrefs.SetString("Mat", Mat);
        }
        else
        {
            BuyPnl.SetActive(true);
        }
    }

    public void Buy()
    {
        if (gameManager.Diamond >= Price)
        {
            gameManager.Diamond -= Price;
            ChangeBallColor(Mat);
            locks[whichColor].gameObject.SetActive(false);
            diamond[whichColor].gameObject.SetActive(false);
            color[whichColor].text = Mat.ToUpper();
            ActiveBalls[whichColor] = true;
            PlayerPrefs.SetString("Mat", Mat);
            PlayerPrefs.SetInt(Mat, 1);
        }
        else
        {
            WarnPnl.SetActive(true);
        }
    }

    public void ChangeBallColor(string Mat)
    {
        switch (Mat)
        {
            case "Black":
                BallDefaultMat.color = BallMaterials[0].color;
                toggles[5].isOn = true;
                break;
            case "Red":
                BallDefaultMat.color = BallMaterials[1].color;
                BallDefaultMat.mainTexture = BallTextures[0];
                toggles[0].isOn = true;
                break;
            case "Green":
                BallDefaultMat.color = BallMaterials[2].color;
                BallDefaultMat.mainTexture = BallTextures[1];
                toggles[1].isOn = true;
                break;
            case "Blue":
                BallDefaultMat.color = BallMaterials[3].color;
                BallDefaultMat.mainTexture = BallTextures[2];
                toggles[2].isOn = true;
                break;
            case "Purple":
                BallDefaultMat.color = BallMaterials[4].color;
                BallDefaultMat.mainTexture = BallTextures[3];
                toggles[3].isOn = true;
                break;
            case "White":
                BallDefaultMat.color = BallMaterials[5].color;
                BallDefaultMat.mainTexture = BallTextures[4];
                toggles[4].isOn = true;
                break;
        }
    }

    void GetActiveBalls()
    {
        if (PlayerPrefs.GetInt("Red") == 1)
        {
            ActiveBalls[0] = true;
            locks[0].gameObject.SetActive(false);
            diamond[0].gameObject.SetActive(false);
            color[0].text = "RED";
        }
        if (PlayerPrefs.GetInt("Green") == 1)
        {
            ActiveBalls[1] = true;
            locks[1].gameObject.SetActive(false);
            diamond[1].gameObject.SetActive(false);
            color[1].text = "GREEN";
        }
        if (PlayerPrefs.GetInt("Blue") == 1)
        {
            ActiveBalls[2] = true;
            locks[2].gameObject.SetActive(false);
            diamond[2].gameObject.SetActive(false);
            color[2].text = "BLUE";
        }
        if (PlayerPrefs.GetInt("Purple") == 1)
        {
            ActiveBalls[3] = true;
            locks[3].gameObject.SetActive(false);
            diamond[3].gameObject.SetActive(false);
            color[3].text = "PURPLE";
        }
        if (PlayerPrefs.GetInt("White") == 1)
        {
            ActiveBalls[4] = true;
            locks[4].gameObject.SetActive(false);
            diamond[4].gameObject.SetActive(false);
            color[4].text = "WHITE";
        }
    }
}
