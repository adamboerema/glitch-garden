using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;

    private Animator animator;
    private Spawner laneSpawner;
    private static GameObject projectileParent;

    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles") as GameObject;
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
    }

    void Update()
    {
        animator.SetBool("isAttacking", IsAttackerAheadInLane());
    }

    private bool IsAttackerAheadInLane()
    {
        int childCount = laneSpawner.transform.childCount;

        if(childCount <= 0)
        {
            return false;
        }

        foreach (Transform child in laneSpawner.transform)
        {
            if(child.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    private void SetMyLaneSpawner ()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                laneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

	private void Fire()
    {
        GameObject projectileInstance = Instantiate(projectile) as GameObject;
        projectileInstance.transform.parent = projectileParent.transform;
        projectileInstance.transform.position = gun.transform.position;
    }
}
