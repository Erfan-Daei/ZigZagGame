using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioSource MasterAudio;
    public BallMovement ballMovement;
    public CameraMovement cameraMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallDrop"))
        {
            audioManager.GameOverSound();
            DropAllPath();
            MasterAudio.mute = true;
            ballMovement.GameIsOver = true;
            cameraMovement.GameIsOver = true;
        }
    }

    public void DropAllPath()
    {
        GameObject[] allBoxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject AlBx in allBoxes)
        {
            Rigidbody BRgdBd = AlBx.GetComponent<Rigidbody>();
            BRgdBd.isKinematic = false;
        }
        GameObject[] allDiamonds = GameObject.FindGameObjectsWithTag("Diamond");
        foreach (GameObject AlDia in allDiamonds)
        {
            Rigidbody DRgdBd = AlDia.GetComponent<Rigidbody>();
            DRgdBd.isKinematic = false;
        }
    }
}
