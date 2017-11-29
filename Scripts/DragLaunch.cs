using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    public float ballXPosition;

    private Vector3 startDrag, endDrag;
    private float startTime, endTime;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
        ballXPosition = transform.position.x;
	}

    void Update() {
        ballXPosition = (Mathf.Clamp(transform.position.x, -35f, 35f));
    }
	
	public void DragStart() {
        startDrag = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        endDrag = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (endDrag.x - startDrag.x) / dragDuration;
        float launchSpeedZ = (endDrag.y - startDrag.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        if (!ball.inPlay) {
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float xNudge) {
        if (!ball.inPlay) {
            ballXPosition += xNudge;
            transform.position = new Vector3(ballXPosition, transform.position.y, transform.position.z);
        }
        
    }
}
