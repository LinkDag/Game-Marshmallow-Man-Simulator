using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float initialTime = 60f;
    private float currentTime = 0f;
    private Playing player;

    void Start()
    {
        player = FindObjectOfType<Playing>();
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*player.IsPlaying == true &&*/  currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(currentTime);
            timerText.text = span.ToString(@"mm\:ss");

            return;
        }
    }
    // TODO: Kill all players that have not crossed the finish line


}
