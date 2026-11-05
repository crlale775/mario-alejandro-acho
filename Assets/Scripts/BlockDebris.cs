using UnityEngine;

/* Pedazo de bloque que sale volando cuando Mario rompe un ladrillo. */
public class BlockDebris : MonoBehaviour
{
    public Vector2 velocity;
    public float gravity = -38f;
    public float lifetime = 0.7f;
    public float spin = 220f;

    private void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        transform.position += (Vector3)velocity * Time.deltaTime;
        transform.Rotate(0f, 0f, velocity.x * spin * Time.deltaTime);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0f) {
            Destroy(gameObject);
        }
    }

}
