/*Copyright 2020 ENRIQUE SILVELA PEÑA

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR 
IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//DEPENDENCIAS: DG.Tweening

public class FreFlyCamera : MonoBehaviour
{
    //La cámara debe poder moverse con wasd y con el click derecho mover la cámara
    //Debe ser independiente a todo, si derepente la cámara gira por otra script
    //esta script debe seguir funcionando sin problemas

    Rigidbody rb;

    [SerializeField]
    //Velocidad de vuelo
    float speed = 10f;

    [SerializeField]
    //Sensibilidad de la cámara
    float sensitivity = 50f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xRotation = -Input.GetAxis("Mouse Y") * sensitivity;
        yRotation = Input.GetAxis("Mouse X") * sensitivity;

        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false; //Oculta el cursor
            Vector3 CameraRotation = transform.eulerAngles;
            CameraRotation.x += xRotation;
            CameraRotation.x = (CameraRotation.x > 180) ? CameraRotation.x - 360f : CameraRotation.x;
            CameraRotation.x = Mathf.Clamp(CameraRotation.x, -85, 85);
            CameraRotation.y += yRotation;
            transform.eulerAngles = CameraRotation;
        }
        else
        {
            Cursor.visible = true; //Reactiva el cursor
        }

        transform.DOBlendableMoveBy(transform.forward * Input.GetAxis("Vertical") * speed
                      + transform.right * Input.GetAxis("Horizontal") *  speed,0.1f);

        //Panning

        if (Input.GetMouseButton(2))
        {
            transform.DOBlendableMoveBy((-transform.right * yRotation
                      + transform.up * xRotation)*0.1f, 0.1f);
        }

    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if(angle < min)
        {
            return min;
        }
        else if(angle > max)
        {
            return max;
        }
        else
        {
            return angle;
        }
    }

}
