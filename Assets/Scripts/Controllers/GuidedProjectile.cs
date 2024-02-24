public class GuidedProjectile : ProjectileBase
{
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Move();
    }

    private void Move()
    {
        var translation = Target.transform.position - transform.position;
        if (translation.magnitude > m_speed)
        {
            translation = translation.normalized * m_speed;
        }
        transform.Translate(translation);
    }
}
