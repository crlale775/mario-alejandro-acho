using UnityEngine;

/* Toad celebrando el rescate al final del castillo. */
public class ToadRescue : MonoBehaviour
{
    public float amplitude = 0.22f;
    public float speed = 4f;

    private Vector3 basePosition;
    private float timer;

    private void Start()
    {
        basePosition = transform.position;

        if (AudioManager.Instance != null) {
            AudioManager.Instance.PlaySfx(Sfx.PowerUp);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float bounce = Mathf.Abs(Mathf.Sin(timer * speed)) * amplitude;
        transform.position = new Vector3(basePosition.x, basePosition.y + bounce, 0f);
    }

}
