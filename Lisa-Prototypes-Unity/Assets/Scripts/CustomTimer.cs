using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomTimer : MonoBehaviour
{
    public Slider timerSlider; 
    public TextMeshProUGUI percentageText;  
    public TextMeshProUGUI downloadingText;   
    public float timerDuration = 10f;         

    private float elapsedTime = 0f;          

    void Start()
    {
        timerSlider.maxValue = timerDuration; 
        UpdateUI();                           
        downloadingText.gameObject.SetActive(true); 
    }

    void Update()
    {
        if (elapsedTime < timerDuration)
        {
            elapsedTime += Time.deltaTime; 
            UpdateUI();                   
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f; 
        downloadingText.gameObject.SetActive(true); 
    }

    private void UpdateUI()
    {
        timerSlider.value = elapsedTime; 
        percentageText.text = $"{(elapsedTime / timerDuration) * 100f:0}%"; 

        if (elapsedTime >= timerDuration) TimerComplete(); 
    }

    private void TimerComplete()
    {
        timerSlider.gameObject.SetActive(false); 
        percentageText.gameObject.SetActive(false);
        downloadingText.gameObject.SetActive(false);
}
}