using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject projectileParent;
    public GameObject gun;

	private void Fire()
    {
        GameObject projectileInstance = Instantiate(projectile) as GameObject;
        projectileInstance.transform.parent = projectileInstance.transform;
        projectileInstance.transform.position = gun.transform.position;
    }
}
