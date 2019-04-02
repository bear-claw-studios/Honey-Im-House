using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TrackBallTouch : MonoBehaviour
{
    // Enumerator starts for when the game is being played as normal,
    // when a settings or quit menu is open, or when the house is 
    // snapping back to its original rotation
    enum GameState {Playable, MenuOpen, Returning};

    Rigidbody rb;

    //The force to add upon letting go
    public Vector3 lastTorque;

    //Position of previous touch
    public Vector2 lastPos;
    public Vector2 currentPos;

    public float TorqueDragCoefficient;
    //Force of torque when mouse is let up
    public float TorqueCoefficient;

    private DateTime freezeTime = DateTime.MinValue;

    Vector3 origin = Vector3.zero;

    //public GameState currentState = GameState.Playable;

    //for the UI button to rotate back
    public bool returnPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        TorqueCoefficient = TorqueDragCoefficient * 10;
        //currentState = GameState.Playable;
    }

    //Attempt at touch-based code
    void Update()
    {
        Touch myTouch;

        if (Input.touchCount > 0 /*&& currentState == GameState.Playable*/)
        {
            myTouch = Input.GetTouch(0);
            currentPos = myTouch.position;
            Vector2 direction = Vector2.zero;

            //If lastPos was only initialized
            if (lastPos == null)
                lastPos = Vector2.zero;
            else
            {
                direction = (currentPos - lastPos);
            }

            var newTorque = Vector3.up * -direction.x + Vector3.right * direction.y;

            if (myTouch.phase == TouchPhase.Began)
            {
                //Freeze the house 
                rb.freezeRotation = true;
            }
            else if (myTouch.phase == TouchPhase.Moved)
            {
                //Move house based on the direction from the last touch to the current
                rb.freezeRotation = false;
                rb.AddTorque(newTorque.normalized * TorqueDragCoefficient);
                lastPos = currentPos;
            }
            else if (myTouch.phase == TouchPhase.Stationary)
            {
                //House stays still
                rb.freezeRotation = true;
            }
            else if (myTouch.phase == TouchPhase.Ended)
            {
                //Add a small torque based on the last stored direction
                rb.freezeRotation = false;
                rb.AddTorque(lastTorque.normalized * TorqueCoefficient);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Return") || Input.GetMouseButton(1) || returnPressed)
        {
            if (!rb.freezeRotation)
            {
                ReturnToOriginalRotation();
            }
        }
        else if (rb.freezeRotation && freezeTime <= DateTime.Now.AddSeconds(-1))
        {
            rb.freezeRotation = false;
        }
    }

    public void ReturnToOriginalRotation()
    {
        float abs = Mathf.Abs(Quaternion.Dot(rb.rotation, Quaternion.Euler(origin)));
        if (abs >= 0.999f)
        {
            rb.angularVelocity = Vector3.zero;
            rb.freezeRotation = true;
            freezeTime = DateTime.Now;
            ReturnReleased();
        }
        else
        {
            var target = Quaternion.Euler(origin) * Quaternion.Inverse(rb.rotation);
            rb.AddTorque(target.x, target.y, target.z, ForceMode.VelocityChange);
        }
    }

    public void ReturnPressed()
    {
        returnPressed = true;
        //currentState = GameState.Returning;
    }

    public void ReturnReleased()
    {
        returnPressed = false;
        //currentState = GameState.Playable;
    }

    public void SetTorqueDragCoefficient(float value)
    {
        TorqueDragCoefficient = value;
        Debug.Log(value);
    }

    public void MenuSelected()
    {
        //currentState = GameState.MenuOpen;
        Debug.Log("Menu Opened");
    }

    public void ExitedMenu()
    {
        //currentState = GameState.Playable;
    }
}
