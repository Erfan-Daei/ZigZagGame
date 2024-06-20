using UnityEngine;

public class DiamondCatcher : MonoBehaviour
{
    float DiammondTimer;
    public GameManager gameManager;
    public AudioManager audioManager;

    void Update()
    {
        DiammondTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            if (DiammondTimer > 1)
            {
                gameManager.Diamond++;
                gameManager.SaveDiamond();
                DiammondTimer = 0;
                audioManager.DiamondSound();
                Destroy(other.gameObject);
            }
        }
    }
}
