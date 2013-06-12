using UnityEngine;
using System.Collections;

public class General : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		//Screen.lockCursor = true;
		
		/*Input.mousePosition =
		
    	mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
    	mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);*/
 
    	/*GUI.DrawTexture( Rect( mousePos.x - (crosshairTexture.width/2),
        	                   mousePos.y - (crosshairTexture.height/2),
            	               crosshairTexture.width,
                	           crosshairTexture.height), crosshairTexture);	*/	
	}
}
