/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization

    Boolean setUp = false;
    void Start()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        UnityWebRequest www = UnityWebRequest.Post("https://console.echoAR.xyz/post?key=ancient-wind-4741&entry=c63a33d3-ede5-47de-b967-cadbe63592d6&data=wolt&value=20", formData);

        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        //entry.addAdditionalData("XD", "LOL");
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {

            // Set name
            if (value.Equals("XDD"))
            {
                entry.addAdditionalData("XDD", "NO");
                Debug.Log("wewdwd");
            }
            this.gameObject.name = value;
            if(value.Equals("paddle1"))
            {
                string scriptName = "Working";
                System.Type MyScriptType = System.Type.GetType(scriptName + "Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
                //this.gameObject.AddComponent(MyScriptType);
                this.gameObject.AddComponent(System.Type.GetType("Working"));
                //Rigidbody gameObjectRigidBody = this.gameObject.AddComponent<Rigidbody>();
                //this.gameObject.AddComponentExt("Working");
               // var childOfChild = transform.Find("Scene/root/node_id3");
                //childOfChild.transform.position = new Vector3(0, 0, 0);
                Debug.Log(">>>");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var childOfChild = transform.Find("Scene/root/node_id3");
        if (childOfChild != null && !setUp)
        {
           // if(this.gameObject.name.Equals("paddle1"))
             //   childOfChild.transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("it detects it ");
            //childOfChild.transform.position = new Vector3(0, 0, 0);
            childOfChild.transform.eulerAngles = new Vector3(90, 0, 0);
            setUp = true;
        }
    }

}