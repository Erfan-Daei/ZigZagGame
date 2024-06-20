using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Diamond;
    public TMP_Text DiamondTxt;

    public int Record;
    public int HighRecord;
    public TMP_Text RecordTxt;
    public TMP_Text HighRecordTxt;

    public BallMovement ballMovement;
    
    void Start()
    {
        GetValues();
    }

    void Update()
    {
        DiamondTxt.text = Diamond.ToString();
        if (ballMovement.StartGame)
            RecordTxt.text = Record.ToString();
    }

    public void SaveDiamond()
    {
        PlayerPrefs.SetInt("Diamond", Diamond);
    }

    public void SaveRecord()
    {
        if (HighRecord == 0 || Record > HighRecord)
        {
            PlayerPrefs.SetInt("HighRecord", Record);
            print("Best Record");
        }
    }

    public void GetValues()
    {
        Diamond = PlayerPrefs.GetInt("Diamond");
        HighRecord = PlayerPrefs.GetInt("HighRecord");
        HighRecordTxt.text = HighRecord.ToString();
        DiamondTxt.text = Diamond.ToString();
    }
}
