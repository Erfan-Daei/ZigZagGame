using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameManager gameManager;

    public SettingManager settingManager;
    
    public ShopManager shopManager;

    public void ResetAll()
    {
        PlayerPrefs.SetInt("HighRecord", 0);
        gameManager.Diamond = 0;
        gameManager.SaveDiamond();
        gameManager.SaveRecord();
        gameManager.GetValues();

        
        settingManager.MainCamera.orthographicSize = settingManager.MainCameraSlider.value = 4.5f;
        settingManager.MasterSound.volume = settingManager.MasterSoundSlider.value = 1;
        settingManager.ChangeCameraZoom();
        settingManager.ChangeMasterSoundVolume();
        settingManager.SoundEffectToggle.isOn = true;
        settingManager.OnOff.sprite = settingManager.OnBtn;
        settingManager.SoundEffect.audioSource.mute = false;
        PlayerPrefs.SetInt("SoundEf", 2);
        settingManager.SaveSoundCam();

        shopManager.ChangeBallColor("Black");
        for (int i = 0; i < shopManager.ActiveBalls.Length; i++)
            shopManager.ActiveBalls[i] = false;
        for (int i = 0; i < shopManager.locks.Length; i++)
            shopManager.locks[i].gameObject.SetActive(true);
        for (int i = 0; i < shopManager.diamond.Length; i++)
            shopManager.diamond[i].gameObject.SetActive(true);
        for (int i = 0; i < shopManager.toggles.Length; i++)
            shopManager.toggles[i].isOn = false;
        shopManager.color[0].text = "RED   -   20";
        shopManager.color[1].text = "GREEN   -   30";
        shopManager.color[2].text = "BLUE   -   20";
        shopManager.color[3].text = "PURPLE   -   50";
        shopManager.color[4].text = "WHITE   -   10";
        shopManager.Mat = "Black";
        shopManager.ChangeBallColor(shopManager.Mat);
        PlayerPrefs.SetString("Mat", shopManager.Mat);
        PlayerPrefs.SetInt("Red", 0);
        PlayerPrefs.SetInt("Green", 0);
        PlayerPrefs.SetInt("Blue", 0);
        PlayerPrefs.SetInt("Purple", 0);
        PlayerPrefs.SetInt("White", 0);
    }
}
