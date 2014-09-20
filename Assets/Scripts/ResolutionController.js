#pragma strict
var native_width : float = 480;
var native_height : float = 640;
 
function OnGUI ()
{
    //set up scaling
    var rx : float = Screen.width / native_width;
    var ry : float = Screen.height / native_height;
    GUI.matrix = Matrix4x4.TRS (Vector3(0, 0, 0), Quaternion.identity, Vector3 (rx, ry, 1)); 
 
    //now create your GUI normally, as if you were in your native resolution
    //The GUI.matrix will scale everything automatically.
 
    //example
    //GUI.Box(  Rect(810, 490, 300, 100)  , "Hello World!");
 
}

function Start () {

}

function Update () {

}