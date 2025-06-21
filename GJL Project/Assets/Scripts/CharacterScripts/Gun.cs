using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool canShoot = false;
    [SerializeField] GameObject projectile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (canShoot)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
