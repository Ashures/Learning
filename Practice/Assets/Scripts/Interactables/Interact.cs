using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private RangeCheck rangeCheck;
    private PlayerMovement playerMovement;
    private WeaponActions weaponActions;
    private CircleCollider2D objectCollider;

    public bool isWeapon;
    public bool reload;
    private bool inRange;

    public Vector2 offset;
    public float dropDistance;

    private void Awake()
    {
        rangeCheck = GetComponent<RangeCheck>();
        weaponActions = GetComponent<WeaponActions>();
        objectCollider = GetComponent<CircleCollider2D>();
    }

    public void RunInteraction(GameObject player)
    {
        inRange = rangeCheck.inRange;
        playerMovement = player.GetComponent<PlayerMovement>();

        if (!reload)
        {
            if (playerMovement.currentObject == this.gameObject)
            {
                transform.SetParent(null);
                transform.Translate(new Vector2(dropDistance, 0));

                playerMovement.hasObject = false;
                playerMovement.currentObject = null;

                GetComponent<SpriteRenderer>().sortingOrder = 0;

                objectCollider.enabled = true;

                weaponActions.enabled = false;
            }
            else if (inRange)
            {
                playerMovement.currentObject = this.gameObject;
                transform.SetParent(player.transform);
                player.GetComponent<PlayerMovement>().hasObject = true;

                GetComponent<SpriteRenderer>().sortingOrder = 2;

                transform.localPosition = Vector2.zero;
                transform.Translate(offset);

                objectCollider.enabled = false;

                if (isWeapon)
                {
                    weaponActions.enabled = true;
                }
            }
        }
    }

    


}
