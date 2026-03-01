using UnityEngine;

public class move5 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftLimit = 0f;
    public float rightLimit = 8f;

    private float direction = 1f;

    void Update()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        if (transform.position.x > rightLimit)
            direction = -1f;
        else if (transform.position.x < leftLimit)
            direction = 1f;
    }
}