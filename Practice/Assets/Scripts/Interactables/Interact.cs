using UnityEngine;

public class Interact : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private RangeCheck rangeCheck;
    private PlayerMovement playerMovement;
    
    private bool inRange;
    private GameObject player;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        rangeCheck = GetComponent<RangeCheck>();
    }

    public void RunInteraction(GameObject player, GameObject current)
    {
        inRange = rangeCheck.inRange;
        playerMovement = player.GetComponent<PlayerMovement>();
        
        if (current != null)
        {
            if (current == this.gameObject)
            {
                transform.SetParent(null);
                transform.Translate(new Vector2(2.5f, 0));
                playerMovement.hasObject = false;
                playerMovement.currentObject = null;
            }
        }
        else
        {
            if (inRange)
            {
                playerMovement.currentObject = this.gameObject;
                transform.SetParent(player.transform);
                player.GetComponent<PlayerMovement>().hasObject = true;
            }
        } 
    }
}
