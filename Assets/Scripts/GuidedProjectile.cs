using UnityEngine;

public class GuidedProjectile : MonoBehaviour
{
    public GameObject target;
    public float speed = 0.2f;
    public int damage = 10;

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
