using UnityEngine;

public class Interact : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private RangeCheck rangeCheck;
    private PlayerMovement playerMovement;
    
    private bool inRange;
    private GameObject player;

    public Vector2 offset;
    public float dropDistance;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        rangeCheck = GetComponent<RangeCheck>();
    }

    public void RunInteraction(GameObject player)
    {
        inRange = rangeCheck.inRange;
        playerMovement = player.GetComponent<PlayerMovement>();
        
        if (playerMovement.currentObject == this.gameObject)
        {
            transform.SetParent(null);
            transform.Translate(new Vector2(dropDistance, 0));
            playerMovement.hasObject = false;
            playerMovement.currentObject = null;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else if (inRange)
        {
            playerMovement.currentObject = this.gameObject;
            transform.SetParent(player.transform);
            player.GetComponent<PlayerMovement>().hasObject = true;
            
            GetComponent<SpriteRenderer>().sortingOrder = 2;

            transform.localPosition = Vector2.zero;
            transform.Translate(offset);
        }
    }
}
