using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Transform stageTransform; // 주변을 기준으로 회전할 Stage의 Transform
    public float rotateSpeed = 500.0f;
    public float perspectiveZoomSpeed = 500.0f;
    public float orthoZoomSpeed = 500.0f;
    public float minYCoordinate = 2.33f; // 카메라가 내려갈 수 있는 최소 y 좌표
    public bool isPanelActive = false;
    private bool isRotating = false;
    float minFieldOfView = 15;
    float maxFieldOfView = 130;
    float minOrthoSize = 15;
    float maxOrthoSize = 130;

    private Vector2 lastTouchPosition;
    public AndroidToast androidToast;

    void Update()
    {
        if(!isPanelActive)
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        isRotating = true;
                        lastTouchPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        if (isRotating)
                        {
                            Vector2 touchDelta = touch.position - lastTouchPosition;
                            float xRotateMove = -touchDelta.y * Time.deltaTime * rotateSpeed;
                            float yRotateMove = touchDelta.x * Time.deltaTime * rotateSpeed;

                            Vector3 stagePosition = stageTransform.position;

                            transform.RotateAround(stagePosition, Vector3.right, xRotateMove);
                            transform.RotateAround(stagePosition, Vector3.up, yRotateMove);

                            transform.LookAt(stagePosition);

                            lastTouchPosition = touch.position;

                            // 회전 중에도 y 좌표를 체크하여 설정한 값에 도달하면 회전 멈춤
                            Vector3 cameraPosition = transform.position;
                            if (cameraPosition.y <= minYCoordinate)
                            {
                                isRotating = false;
                            }
                        }
                        break;
                    case TouchPhase.Ended:
                        isRotating = false;
                        break;
                }
            }
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                if (Camera.main.orthographic)
                {
                    Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + deltaMagnitudeDiff * orthoZoomSpeed, minOrthoSize, maxOrthoSize);
                    androidToast.ShowToastMessage("orthographicSize"+Camera.main.orthographicSize);
                }
                else
                {
                    Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
                    Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView + deltaMagnitudeDiff * perspectiveZoomSpeed, minFieldOfView, maxFieldOfView);
                    androidToast.ShowToastMessage("Camera.main.fieldOfView"+Camera.main.fieldOfView);
                    
                }
            }

            // 회전 중이 아닐 때만 y 좌표를 제한
            if (!isRotating)
            {
                Vector3 cameraPosition = transform.position;
                cameraPosition.y = Mathf.Max(cameraPosition.y, minYCoordinate);
                transform.position = cameraPosition;
            }
        }
}
