using UnityEngine;

/* Cañon del castillo: dispara balas hacia el pasillo cada cierto tiempo. */
public class Cannon : MonoBehaviour
{
    public float direction = -1f;
    public float interval = 2.6f;
    public float ballSpeed = 7f;
    public Sprite ballSprite;

    private float timer;
    private float distanceToPlayer = 99f;
    private Transform player;

    private void Start()
    {
        timer = Random.Range(0.4f, interval);
    }

    private void Update()
    {
        if (player == null)
        {
            Player found = FindFirstObjectByType<Player>();
            player = found != null ? found.transform : null;
        }

        if (player != null) {
            distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);
        }

        if (distanceToPlayer > 16f) {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = interval;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject ball = new GameObject("Cannonball");
        ball.transform.position = new Vector2(transform.position.x + direction * 0.9f, transform.position.y);
        ball.layer = LayerMask.NameToLayer("Enemy");

        SpriteRenderer renderer = ball.AddComponent<SpriteRenderer>();
        renderer.sprite = ballSprite;
        renderer.sortingOrder = 4;

        Rigidbody2D body = ball.AddComponent<Rigidbody2D>();
        body.gravityScale = 0f;
        body.linearVelocity = new Vector2(direction * ballSpeed, 0f);

        CircleCollider2D collider = ball.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = 0.35f;

        Cannonball shot = ball.AddComponent<Cannonball>();
        shot.life = 3.2f;

        if (AudioManager.Instance != null) {
            AudioManager.Instance.PlaySfx(Sfx.Fireball);
        }
    }

}
