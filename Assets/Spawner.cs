using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject attacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
    }

    bool isTimeToSpawn(GameObject attacker)
    {
        Attacker attackerInstance = attacker.GetComponent<Attacker>();
        float meanSpawnDelay = attackerInstance.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        return Random.value < threshold;
    }

    void Spawn(GameObject attacker)
    {
        GameObject attackerInstance = Instantiate(attacker) as GameObject;
        attackerInstance.transform.parent = transform;
        attackerInstance.transform.position = transform.position;
    }
}
