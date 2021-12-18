using TMPro;
using UnityEngine;

public class LivesPanelController : MonoBehaviour
{
    public TextMeshProUGUI livesCounterText;

    public void SetLives(int lives)
    {
        livesCounterText.text = "x " + lives.ToString();
    }
}
