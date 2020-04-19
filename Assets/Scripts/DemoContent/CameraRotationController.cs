using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{

    [SerializeField] private Transform targetTransform;

    [SerializeField] private float interpolationCoef = 2f;

    [SerializeField] private float inputCoef = .01f;


    private Vector2 m_StartPos;

    private void Awake()
    {
        m_StartPos = Vector2.zero;
        m_prevPos = Vector2.zero;
    }

    private Vector2 m_prevPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, interpolationCoef * Time.deltaTime);
        
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    m_StartPos = touch.position;
                    break;
                
                case TouchPhase.Moved:
                    var rotation = transform.rotation;
                    rotation = Quaternion.Euler(rotation.eulerAngles.x -(touch.position - m_StartPos).y * inputCoef,
                        rotation.eulerAngles.y  -(touch.position - m_StartPos).x * inputCoef, 0);
                    transform.rotation = rotation;
                    m_prevPos = touch.position;
                    break;
                
                case TouchPhase.Stationary:
                    var rotatio = transform.rotation;
                    rotation = Quaternion.Euler(rotatio.eulerAngles.x -(touch.position - m_StartPos).y * inputCoef,
                        rotatio.eulerAngles.y  -(touch.position - m_StartPos).x * inputCoef, 0);
                    transform.rotation = rotation;
                    m_prevPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    m_prevPos = Vector2.zero;
                    break;
            }
        }
        
    }
}
