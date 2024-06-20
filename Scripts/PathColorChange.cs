using UnityEngine;

public class PathColorChange : MonoBehaviour
{
    public Material[] AllBoxMaterials;
    public Material BoxMaterial;
    public Material DfBoxMaterial;

    public Material[] ChangeBackColor;

    public GameManager gameManager;

    float ChangeBoxTimer;
    int RandomColor;

    void Start()
    {
        BoxMaterial.color = DfBoxMaterial.color;
    }

    void Update()
    {
        ChangeBoxTimer += Time.deltaTime;
        ChangeColor();
    }
    void ChangeColor()
    {
        if (gameManager.Record % 50 == 0 && gameManager.Record != 0 && ChangeBoxTimer > 2)
        {
            RandomNumber();
            if (BoxMaterial.color == AllBoxMaterials[RandomColor].color)
            {
                ChangeBoxTimer = 3;
                ChangeColor();
            }
            if (BoxMaterial.color != AllBoxMaterials[RandomColor].color)
            {
                BoxMaterial.color = AllBoxMaterials[RandomColor].color;
                Camera.main.backgroundColor = ChangeBackColor[RandomColor].color;
            }
            ChangeBoxTimer = 0;
        }
    }

    void RandomNumber()
    {
        RandomColor = Random.Range(0, 7);
    }
}
