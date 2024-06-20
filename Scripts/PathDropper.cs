using UnityEngine;

public class PathDropper : MonoBehaviour
{
    Rigidbody BoxRB;

    public GameManager gameManager;
    public AudioManager audioManager;

    void Start()
    {
        BoxRB = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BoxRB.isKinematic = false;
            gameManager.Record++; ;
            gameManager.SaveRecord();
            audioManager.BoxDroppSound();
            Destroy(gameObject, 3);
        }
    }
}
