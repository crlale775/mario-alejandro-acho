using UnityEngine;

/* Bala de cañon: daña al jugador y se destruye al chocar o al agotar su vida. */
public class Cannonball : MonoBehaviour
{
    public float life = 3.2f;

    private void Update()
    {
        life -= Time.deltaTime;

        if (life <= 0f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                Destroy(gameObject);
            }

            return;
        }

        Player player = other.GetComponent<Player>();

        if (player != null && !player.dead) {
            player.Hit();
        }

        Destroy(gameObject);
    }

}
