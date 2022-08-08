using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    private PlayerInput.OnFootActions onFoot;
    private Interact objectInteract;
    
    public GameObject firePoint;
    public GameObject bullet;

    public float damage;
    public float shootCooldown;
    public float reloadCooldown;
    public bool isReloadable;
    public int maxAmmo;
    public int currentAmmo;

    public void Awake()
    {
        

        //currentAmmo = maxAmmo;
    }

    public void OnEnable()
    {
        onFoot = GetComponentInParent<InputManager>().onFoot;
        objectInteract = GetComponent<Interact>();

        onFoot.Attack.Enable();
        onFoot.Use.Enable();

        onFoot.Attack.performed += ctx => Attack();
        onFoot.Use.performed += ctx => Use();
    }

    public void OnDisable()
    {
        onFoot.Attack.Disable();
        onFoot.Use.Disable();
    }

    public void Use()
    {
        if (isReloadable)
        {
            if (currentAmmo < maxAmmo)
            {
                objectInteract.reload = true;
                    
                Invoke("RunReload", reloadCooldown);
            }
        }
    }

    public void RunReload()
    {
        currentAmmo = maxAmmo;
        objectInteract.reload = false;
    }

    public void Attack()
    {   
        if (isReloadable)
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
        }
        else
        {

        }   
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
        currentAmmo -= 1;
    }
}
