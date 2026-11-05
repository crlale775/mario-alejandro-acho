using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject item;
    public Sprite emptyBlock;
    public int maxHits = -1;
    public bool breakable;
    private bool animating;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up)) {
                Hit(collision.gameObject.GetComponent<Player>());
            }
        }
    }

    private void Hit(Player player)
    {
        // Mario grande rompe el ladrillo de un solo golpe
        if (breakable && player != null && player.big) {
            Break();
            return;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true; // show if hidden

        maxHits--;

        if (maxHits == 0) {
            spriteRenderer.sprite = emptyBlock;
        }

        if (item != null) {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        if (AudioManager.Instance != null) {
            AudioManager.Instance.PlaySfx(Sfx.Bump);
        }

        BumpEnemies();
        StartCoroutine(Animate());
    }

    /* Los enemigos que estan encima del bloque salen despedidos. */
    private void BumpEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)transform.position + Vector2.up, new Vector2(1.1f, 0.7f), 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit.isTrigger || hit.gameObject.layer != LayerMask.NameToLayer("Enemy")) {
                continue;
            }

            Goomba goomba = hit.GetComponent<Goomba>();

            if (goomba != null) {
                goomba.Bump();
                continue;
            }

            Koopa koopa = hit.GetComponent<Koopa>();

            if (koopa != null) {
                koopa.Bump();
            }
        }
    }

    /* El bloque se parte en cuatro pedazos que caen fuera del nivel. */
    private void Break()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer != null ? spriteRenderer.sprite : null;
        int sortingOrder = spriteRenderer != null ? spriteRenderer.sortingOrder : 0;

        for (int i = 0; i < 4; i++)
        {
            GameObject piece = new GameObject("Debris");
            piece.transform.position = transform.position + new Vector3(i % 2 == 0 ? -0.25f : 0.25f, i < 2 ? 0.25f : -0.25f, 0f);
            piece.transform.localScale = Vector3.one * 0.5f;

            SpriteRenderer pieceRenderer = piece.AddComponent<SpriteRenderer>();
            pieceRenderer.sprite = sprite;
            pieceRenderer.sortingOrder = sortingOrder;

            BoxCollider2D pieceCollider = piece.AddComponent<BoxCollider2D>();
            pieceCollider.size = Vector2.one;

            BlockDebris debris = piece.AddComponent<BlockDebris>();
            debris.velocity = new Vector2(i % 2 == 0 ? -4.5f : 4.5f, i < 2 ? 12f : 9f);
        }

        if (AudioManager.Instance != null) {
            AudioManager.Instance.PlaySfx(Sfx.Bump);
        }

        BumpEnemies();

        if (GameManager.Instance != null) {
            GameManager.Instance.AddScore(50);
        }

        Destroy(gameObject);
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

}
