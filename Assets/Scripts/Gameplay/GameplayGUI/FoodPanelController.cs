using TMPro;
using UnityEngine;

public class FoodPanelController : MonoBehaviour
{
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI scoreText;

    public void SetFoodAndScore(int food, int score)
    {
        foodText.text = "FOOD x" + food.ToString();
        scoreText.text = score.ToString();
    }

}
