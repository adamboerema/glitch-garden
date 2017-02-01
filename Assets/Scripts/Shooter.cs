using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;
    private static GameObject projectileParent;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles") as GameObject;
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

	private void Fire()
    {
        GameObject projectileInstance = Instantiate(projectile) as GameObject;
        projectileInstance.transform.parent = projectileParent.transform;
        projectileInstance.transform.position = gun.transform.position;
    }
}
