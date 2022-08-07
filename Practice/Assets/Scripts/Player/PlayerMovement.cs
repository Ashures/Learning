using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerMove;
    private Vector3 playerRotation;

    public float speed = 5f;
    public float sensitivity = 30f;

    public GameObject inRangeObject;
    public bool hasObject = false;
    public GameObject currentObject;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ProcessMove(Vector2 input)
    {
        playerMove = Vector2.zero;
        playerMove += new Vector2(input.x * speed, input.y * speed);
        rb.velocity = playerMove;
    }

    public void ProcessLook(Vector2 input)
    {
        playerRotation.z += input.x * sensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(playerRotation);
    }

    public void Interact()
    {
        if (currentObject != null)
        {
            currentObject.GetComponent<Interact>().RunInteraction(this.gameObject, currentObject);
        }
        else
        {
            if (inRangeObject != null) {
                if (inRangeObject.GetComponent<Interact>() != null)
                {
                    inRangeObject.GetComponent<Interact>().RunInteraction(this.gameObject, null);
                }
            }
        }
    }
}
