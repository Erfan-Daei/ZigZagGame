using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public AudioSource MasterSound;
    public Slider MasterSoundSlider;

    public Image OnOff;
    public Sprite OnBtn;
    public Sprite OffBtn;
    public Toggle SoundEffectToggle;
    public AudioManager SoundEffect;

    public Camera MainCamera;
    public Slider MainCameraSlider;

    public float MainCameraZoom = 4.5f;
    public float MasterSoundVolume = 1;
    public int SoundEf = 2;

    void Start()
    {
        SoundEffectToggle.image.sprite = OnBtn;
        SaveSoundCam();
    }

    public void ChangeMasterSoundVolume()
    {
        MasterSound.volume = MasterSoundSlider.value;
        PlayerPrefs.SetFloat("MasterVol", MasterSound.volume);
    }

    public void SoundEffectsOnOff()
    {
        if (OnOff.sprite == OnBtn)
        {
            SoundEffectToggle.isOn = false;
            OnOff.sprite = OffBtn;
            SoundEffect.audioSource.mute = true;
            PlayerPrefs.SetInt("SoundEf", 1);

        }
        else if (OnOff.sprite == OffBtn)
        {
            SoundEffectToggle.isOn = true;
            OnOff.sprite = OnBtn;
            SoundEffect.audioSource.mute = false;
            PlayerPrefs.SetInt("SoundEf", 2);
        }
    }

    public void ChangeCameraZoom()
    {
        MainCamera.orthographicSize = MainCameraSlider.value;
        PlayerPrefs.SetFloat("Camera", MainCamera.orthographicSize);
    }

    public void SaveSoundCam()
    {
        if (PlayerPrefs.GetFloat("MasterVol") != 0)
            MasterSoundVolume = PlayerPrefs.GetFloat("MasterVol");
        if (PlayerPrefs.GetFloat("Camera") != 0)
            MainCameraZoom = PlayerPrefs.GetFloat("Camera");
        if (PlayerPrefs.GetFloat("MasterVol") != 0)
            SoundEf = PlayerPrefs.GetInt("SoundEf");

        MasterSoundSlider.value = MasterSoundVolume;
        MainCameraSlider.value = MainCameraZoom;

        if (SoundEf == 1)
        {
            SoundEffectToggle.isOn = false;
            OnOff.sprite = OffBtn;
            SoundEffect.audioSource.mute = true;
        }
        if (SoundEf == 2)
        {
            SoundEffectToggle.isOn = true;
            OnOff.sprite = OnBtn;
            SoundEffect.audioSource.mute = false;
        }
    }
}
