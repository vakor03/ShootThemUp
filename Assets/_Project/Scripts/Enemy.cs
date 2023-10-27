namespace ShootThemUp
{
    public class Enemy : Plane
    {
        protected override void Die()
        {
            Destroy(gameObject);
            // GameManager.Instance.AddScore(1);
        }
    }
}