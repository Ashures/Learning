using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    public bool inRange = false;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            player = collision.gameObject;
            player.GetComponent<PlayerMovement>().inRangeObject = this.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            player.GetComponent<PlayerMovement>().inRangeObject = null;
            player = null;
        }
    }
}