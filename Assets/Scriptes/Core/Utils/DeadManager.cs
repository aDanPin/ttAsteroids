using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadManager : MonoBehaviour
{
    public static DeadManager current;

    private GameObject deadPanel;
    private UnityEngine.UI.Text deadText;

    private void Awake() {
        current = this;
    }

    private void Start() {
        deadPanel = GameObject.FindWithTag("DeadPanel");
        deadText = GameObject.FindWithTag("PointsText")
                       .GetComponent<UnityEngine.UI.Text>();

        deadPanel.SetActive(false);
    }

    public void OnPlayerDead() {
        Time.timeScale = 0;

        deadPanel.SetActive(true);

        int points = ShowingMetrics.current.Points;
        deadText.text = "Points: " + points;        
    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }
}
