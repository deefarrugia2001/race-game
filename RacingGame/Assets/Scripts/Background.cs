using UnityEngine;

public class Background : MonoBehaviour
{
    Material material;
    Vector2 offset;
    static float moveSpeed = Car.MoveSpeed;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0, moveSpeed);
    }

    void Update()
    {
        material.mainTextureOffset += Time.deltaTime * moveSpeed * offset;
    }
}
