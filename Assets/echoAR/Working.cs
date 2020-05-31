using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Working : MonoBehaviour
{
    public float speed;
    public GameObject variableJoystick;
    public VariableJoystick variableJoystickXD;
    //public GameObject paddleRef;
    public void Start()
    {
        //variableJoystick = (VariableJoystick)Resources.Load("Assets/Joystick Pack/Prefabs/Variable Joystick.prefab", typeof(VariableJoystick));
        //Object prefab = Resources.Load("Assets/Joystick Pack/Prefabs/Variable Joystick.prefab", typeof(GameObject));
        //paddleRef = (GameObject)prefab;
        //VariableJoystick = prefab;
        variableJoystick = (GameObject)GameObject.Find("reference1");
        reference referenceScript = variableJoystick.GetComponent<reference>();
        variableJoystickXD = referenceScript.variableJoy;
        //variableJoystick = (GameObject)GameObject.FindGameObjectWithTag("joystick1");

    }
    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        Debug.Log(variableJoystickXD.Horizontal);
        sendRequestX(variableJoystickXD.Horizontal);
        // temp = new Vector3(3 * variableJoystickXD.Horizontal, 0, 0);
        //this.gameObject.transform.position += temp;
    }
    public void sendRequestX(float position)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        //float newPosition = (float)this.transform.position.x + position*(float)0.1;
        float newPosition = (float)0.5 + position * (float)0.1;

        Debug.Log(newPosition);
        Mathf.Clamp(newPosition, (float)0.1, (float)1.2);
        string request = "https://console.echoAR.xyz/post?key=ancient-wind-4741&entry=c63a33d3-ede5-47de-b967-cadbe63592d6&data=x&value=" + position;
        UnityWebRequest www = UnityWebRequest.Post(request, formData);

        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
