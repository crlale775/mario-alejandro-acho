using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                if (AudioManager.Instance != null) {
                    AudioManager.Instance.PlaySfx(Sfx.Coin);
                }

                if (GameManager.Instance != null) {
                    GameManager.Instance.AddCoin();
                }
                break;

            case Type.ExtraLife:
                if (GameManager.Instance != null) {
                    GameManager.Instance.AddLife();
                }

                if (HUD.Instance != null) {
                    HUD.Instance.ShowToast("¡VIDA EXTRA!  +1");
                }
                break;

            case Type.MagicMushroom:
                if (AudioManager.Instance != null) {
                    AudioManager.Instance.PlaySfx(Sfx.PowerUp);
                }

                if (GameManager.Instance != null) {
                    GameManager.Instance.AddScore(1000);
                }

                player.GetComponent<Player>().Grow();

                if (HUD.Instance != null) {
                    HUD.Instance.ShowToast("¡MARIO GRANDE!");
                }
                break;

            case Type.Starpower:
                if (AudioManager.Instance != null) {
                    AudioManager.Instance.PlaySfx(Sfx.PowerUp);
                }

                if (GameManager.Instance != null) {
                    GameManager.Instance.AddScore(1000);
                }

                player.GetComponent<Player>().Starpower();
                break;
        }

        Destroy(gameObject);
    }

}
