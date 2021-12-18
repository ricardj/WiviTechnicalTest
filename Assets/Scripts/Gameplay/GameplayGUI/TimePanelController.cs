using System.Collections;
using TMPro;
using UnityEngine;

public class TimePanelController : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public float counter;
    bool timerActivated = false;
    public void StartTimer()
    {
        timerActivated = true;
        counter = 0;
        StartCoroutine(CountTime());
    }
    public IEnumerator CountTime()
    {
        while (timerActivated)
        {
            UpdateTimeText(Mathf.FloorToInt(counter));
            yield return null;
            counter += Time.deltaTime;
        }
    }
    public void StopTimer()
    {
        timerActivated = false;
    }


    public void UpdateTimeText(int time)
    {
        timeText.text = time.ToString();
    }
}
