using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject moveTarget;
    public GameObject monster;

    public GameObject SpawnMonster()
    {
        GameObject newMonster = Instantiate(monster);
        newMonster.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        newMonster.GetComponent<Monster>().moveTarget = moveTarget;

        return newMonster;
    }
}
