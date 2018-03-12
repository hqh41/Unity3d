using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour {
 public Color c;
 public static Color selectedColor;
 public bool selectable = false; 
 // Use this for initialization
 void Start () {
  
 }
 
 // Update is called once per frame
 void Update () {
  
 }

 void OnTriggerEnter(Collider c)
 {
  Debug.Log('1');
  if(c.gameObject.transform.parent.name.Equals("index"))
  {
   Debug.Log('2');
   if(this.selectable)
   {
    CubeInteraction.selectedColor = this.c;
    this.transform.Rotate(Vector3.up, 33);
    return;
   }
   transform.gameObject.GetComponent<Renderer>().material.color = CubeInteraction.selectedColor;
  }
 }
}