using UnityEngine;

/* Hacha del castillo: al tocarla se derrumba el puente. */
public class AxeGoal : MonoBehaviour
{
    public BridgeCollapse bridge;

    private bool used;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (used || !other.CompareTag("Player")) {
            return;
        }

        Player player = other.GetComponent<Player>();

        if (player != null && player.dead) {
            return;
        }

        used = true;

        if (AudioManager.Instance != null) {
            AudioManager.Instance.PlaySfx(Sfx.Axe);
        }

        if (bridge != null) {
            bridge.Collapse();
        }

        RescueToad();

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (renderer != null) {
            renderer.enabled = false;
        }
    }

    /* Toad sale de la jaula del castillo mientras el puente se derrumba. */
    private void RescueToad()
    {
        GameObject toad = new GameObject("Toad rescatado");
        toad.transform.position = transform.position + new Vector3(1.7f, -0.6f, 0f);

        SpriteRenderer renderer = toad.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("Sprites/Toad");
        renderer.sortingOrder = 6;

        toad.AddComponent<ToadRescue>();

        if (HUD.Instance != null) {
            HUD.Instance.ShowLevelBanner("TOAD RESCATADO", "El castillo se derrumba");
        }
    }

}
