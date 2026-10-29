using UnityEngine;

/* Burbuja de lava que sube y cae en un arco fijo. Quema al jugador al tocarla. */
public class LavaBubble : MonoBehaviour
{
    public float baseY;
    public float jumpHeight = 5.5f;
    public float period = 3.4f;
    public float offset;

    private float timer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        timer = offset;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float phase = Mathf.Repeat(timer / period, 1f);
        float y = baseY + Mathf.Sin(phase * Mathf.PI) * jumpHeight;

        transform.position = new Vector3(transform.position.x, y, 0f);

        if (spriteRenderer != null) {
            spriteRenderer.flipY = phase > 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Touch(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Touch(other);
    }

    private void Touch(Collider2D other)
    {
        if (!other.CompareTag("Player")) {
            return;
        }

        Player player = other.GetComponent<Player>();

        if (player != null && !player.dead) {
            player.Hit();
        }
    }

}
