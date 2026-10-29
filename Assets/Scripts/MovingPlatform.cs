using UnityEngine;

/* Plataforma que recorre un tramo y transporta al jugador que va encima. */
public class MovingPlatform : MonoBehaviour
{
    public Vector2 pointA;
    public Vector2 pointB;
    public float speed = 1.6f;
    public float width = 3f;
    public float height = 0.6f;

    private Rigidbody2D body;
    private Transform player;
    private PlayerMovement movement;
    private int playerLayer = -1;
    private float progress;
    private int direction = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(pointA, pointB);

        if (distance < 0.01f) {
            return;
        }

        progress += direction * (speed / distance) * Time.fixedDeltaTime;

        if (progress >= 1f) {
            progress = 1f;
            direction = -1;
        } else if (progress <= 0f) {
            progress = 0f;
            direction = 1;
        }

        Vector2 target = Vector2.Lerp(pointA, pointB, progress);
        Vector2 origin = body != null ? body.position : (Vector2)transform.position;
        Vector2 delta = target - origin;

        if (body != null) {
            body.MovePosition(target);
        } else {
            transform.position = target;
        }

        Carry(delta);
        transform.rotation = Quaternion.identity;
    }

    private void Carry(Vector2 delta)
    {
        if (player == null)
        {
            Player found = FindFirstObjectByType<Player>();

            if (found == null) {
                return;
            }

            player = found.transform;
            movement = found.GetComponent<PlayerMovement>();
        }

        if (movement == null || playerLayer < 0) {
            return;
        }

        Vector2 top = new Vector2(transform.position.x, transform.position.y + height * 0.5f + 0.25f);
        Collider2D rider = Physics2D.OverlapBox(top, new Vector2(width * 0.9f, 0.5f), 0f, 1 << playerLayer);

        if (rider != null) {
            movement.AddExternalDisplacement(delta);
        }
    }

}
