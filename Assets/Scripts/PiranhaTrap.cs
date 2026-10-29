using UnityEngine;

/* Planta piraña que sale y entra de la tuberia y muerde al jugador. */
public class PiranhaTrap : MonoBehaviour
{
    public float hiddenY;
    public float raisedY;
    public float hiddenTime = 1.1f;
    public float raisedTime = 1.3f;
    public float travelTime = 0.45f;

    private SpriteRenderer spriteRenderer;
    private float timer;
    private float phase;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = Random.Range(0f, hiddenTime);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (phase == 0f)
        {
            if (timer >= hiddenTime)
            {
                timer = 0f;
                phase = 1f;
            }
        }
        else if (phase == 1f)
        {
            float t = Mathf.Clamp01(timer / travelTime);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(hiddenY, raisedY, t), 0f);

            if (t >= 1f)
            {
                timer = 0f;
                phase = 2f;
            }
        }
        else if (phase == 2f)
        {
            if (timer >= raisedTime)
            {
                timer = 0f;
                phase = 3f;
            }
        }
        else
        {
            float t = Mathf.Clamp01(timer / travelTime);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(raisedY, hiddenY, t), 0f);

            if (t >= 1f)
            {
                timer = 0f;
                phase = 0f;
            }
        }

        if (spriteRenderer != null) {
            spriteRenderer.enabled = transform.position.y > hiddenY + 0.2f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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
