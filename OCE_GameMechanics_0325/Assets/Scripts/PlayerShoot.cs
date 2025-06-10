using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform projectileSpawnpoint;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float shootCooldown;
    private float curShootCooldown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            if(curShootCooldown <= 0)
            {
                Shoot();
                curShootCooldown = shootCooldown;
            }
        }

        curShootCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        // shorthand:
        // Rigidbody2D projrb = Instantiate(projectilePrefab, projectileSpawnpoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();

        GameObject go = Instantiate(projectilePrefab, projectileSpawnpoint.position, Quaternion.identity);

        if (go == null)
            return;

        Destroy(go, 10);
        Rigidbody2D projrb = go.GetComponent<Rigidbody2D>();

        if (projrb == null)
            return;

        projrb.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
    }
}
