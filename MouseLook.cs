using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY=0,MouseX=1,MouseY=2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true;
    }
    void Update()
    {
        if (axes == RotationAxes.MouseX) 
        { transform.Rotate(0, sensitivityHor*Input.GetAxis("Mouse X"), 0); }
        else if (axes == RotationAxes.MouseY) 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;//基于鼠标增加垂直角度
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            //将垂直角度限制在最小和最大之间
            float rotationY = transform.localEulerAngles.y;
            //保持Y的角度一样水平不会旋转
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

            //Debug.Log(Input.GetAxis("Mouse Y"));
            //Debug.Log(_rotationX);
        }
        else {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
