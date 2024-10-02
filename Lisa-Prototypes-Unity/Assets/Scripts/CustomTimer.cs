using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomTimer : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI downloadingText;

    private float elapsedTime = 0f;

    void Awake()
    {
        timerSlider.gameObject.SetActive(false);
        percentageText.gameObject.SetActive(false);
        downloadingText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (elapsedTime < timerSlider.maxValue)
        {
            elapsedTime += Time.deltaTime;
            UpdateUI();
        }
    }

    public void StartTimer(float duration)
    {
        timerSlider.maxValue = duration;
        elapsedTime = 0f;


        timerSlider.gameObject.SetActive(true);
        percentageText.gameObject.SetActive(true);
        downloadingText.gameObject.SetActive(true);
    }

    private void UpdateUI()
    {
        timerSlider.value = elapsedTime;
        percentageText.text = $"{(elapsedTime / timerSlider.maxValue) * 100f:0}%";

        if (elapsedTime >= timerSlider.maxValue) TimerComplete();
    }

    private void TimerComplete()
    {

        timerSlider.gameObject.SetActive(false);
        percentageText.gameObject.SetActive(false);
        downloadingText.gameObject.SetActive(false);
    }
}
