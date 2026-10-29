using UnityEngine;

/* Montura del castillo: Toad va encima de una bola de fuego gigante que rueda
   sobre la lava. El jugador se sube encima y la conduce con izquierda/derecha. */
public class ToadFireballRide : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float speed = 5f;
    public float width = 2.1f;
    public float height = 2.4f;

    public Transform fireball;
    public SpriteRenderer fireballRenderer;
    public Transform toad;

    private Transform player;
    private PlayerMovement movement;
    private int playerLayer = -1;
    private float roll;
    private bool riding;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");

        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (body == null) {
            body = gameObject.AddComponent<Rigidbody2D>();
        }

        body.bodyType = RigidbodyType2D.Kinematic;
        body.gravityScale = 0f;

        // la bola de fuego y Toad tienen colliders separados para que el jugador
        // pueda subirse a la cabeza de Toad
        BoxCollider2D ballCollider = gameObject.AddComponent<BoxCollider2D>();
        ballCollider.size = new Vector2(width, 1.9f);
        ballCollider.offset = new Vector2(0f, -0.05f);

        BoxCollider2D toadCollider = gameObject.AddComponent<BoxCollider2D>();
        toadCollider.size = new Vector2(0.85f, 1.5f);
        toadCollider.offset = new Vector2(0f, 1.6f);
    }

    private void FixedUpdate()
    {
        riding = RiderOnTop();

        float input = riding ? Input.GetAxisRaw("Horizontal") : 0f;
        float step = input * speed * Time.fixedDeltaTime;
        float x = Mathf.Clamp(transform.position.x + step, minX, maxX);
        Vector2 target = new Vector2(x, transform.position.y);
        Vector2 delta = target - (Vector2)transform.position;

        transform.position = target;

        if (riding && delta.sqrMagnitude > 0f)
        {
            if (movement == null) {
                FindPlayer();
            }

            if (movement != null) {
                movement.AddExternalDisplacement(delta);
            }
        }

        roll -= step * 190f;

        if (fireball != null) {
            fireball.localRotation = Quaternion.Euler(0f, 0f, roll);
        }
    }

    private void Update()
    {
        if (toad != null) {
            float bob = Mathf.Sin(Time.time * 5f) * 0.05f;
            toad.localPosition = new Vector3(0f, 1.6f + bob, 0f);
        }

        if (fireballRenderer != null) {
            float pulse = 1f + Mathf.Sin(Time.time * 9f) * 0.04f;
            fireballRenderer.transform.localScale = new Vector3(pulse, pulse, 1f);
        }
    }

    private bool RiderOnTop()
    {
        if (playerLayer < 0) {
            return false;
        }

        Vector2 top = new Vector2(transform.position.x, transform.position.y + height - 0.1f);
        Collider2D rider = Physics2D.OverlapBox(top, new Vector2(1.1f, 0.6f), 0f, 1 << playerLayer);

        if (rider != null)
        {
            FindPlayer();
            return true;
        }

        return false;
    }

    private void FindPlayer()
    {
        Player found = FindFirstObjectByType<Player>();

        if (found != null) {
            player = found.transform;
            movement = found.GetComponent<PlayerMovement>();
        }
    }

}
