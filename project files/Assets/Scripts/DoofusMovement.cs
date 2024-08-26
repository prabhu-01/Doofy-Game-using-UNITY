using UnityEngine;

public class DoofusMovement : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
