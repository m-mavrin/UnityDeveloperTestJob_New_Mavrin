using UnityEngine;

public class GuidedProjectile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public int damage;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var translation = target.transform.position - transform.position;
        if (translation.magnitude > speed)
        {
            translation = translation.normalized * speed;
        }
        transform.Translate(translation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<Monster>(out var monster))
            return;

        monster.HP -= damage;
        Destroy(gameObject);
    }
}
