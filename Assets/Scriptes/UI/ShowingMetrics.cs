using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingMetrics : MonoBehaviour
{
    private int points;
    private Vector2 position;
    private float rotation;
    private float speed;
    private float laserCooldown;

    private UnityEngine.UI.Text text;

    public static ShowingMetrics current;

    private void Awake() {
        current = this;

        text = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update() {
        Show();
    }

    private void Show() {
        text.text = 
            "points         " + points + "\n" +
            "position       " + position + "\n" +
            "rotation       " + rotation + "\n" +
            "speed          " + speed + "\n" +
            "Laser cooldown " + laserCooldown + "\n";
    }

    public void AddPoint() {
        points++;
    }

    public void UpdateMetrisc(Vector2 pos, float rot, float spd, float cd) {
        position = pos;
        rotation = rot;
        speed = spd;
        laserCooldown = cd;
    }

    public int Points{get {return points;}}
}
