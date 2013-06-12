using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

	public Texture2D normalCursor;       // The texture for when the cursor isn't near a screen edge
	public Texture2D leftCursor;	     // The texture for the cursor when it's at the left edge
	public Texture2D rightCursor;	     // Ditto, right edge
	public Texture2D upCursor;           // Top edge
	public Texture2D downCursor;         // ...And bottom edge
	public float nativeRatio = 1.3333333333333f;   // Aspect ratio of the monitor used to set up GUI elements
	private Vector3 lastPosition;  // Where the mouse position was last
	public float normalAlpha = .5f;              // Normal alpha value of the cursor ... .5 is full
	public float fadeTo = .2f;                     // The alpha value the cursor fades to if not moved
	public float fadeRate = .22f;                  // The rate at which the cursor fades
	bool cursorIsFading = true;   // Whether we should fade the cursor 
	private float fadeValue;
	
	GUITexture guiElement;
	
	
	// Use this for initialization
	void Start () 
	{
		guiElement = GetComponent<GUITexture>();
		
		// Slightly weird but necessary way of forcing float evaluation
    	float currentRatio = (float)(0.0 + Screen.width) / Screen.height;
		Vector3 currentTranformLocalScale = transform.localScale;
    	currentTranformLocalScale.x =  currentTranformLocalScale.x	 * (nativeRatio / currentRatio);
		transform.localScale = currentTranformLocalScale;
    	Screen.showCursor = false;
    	fadeValue = normalAlpha;
    	lastPosition = Input.mousePosition;	
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);	
		if ( Input.GetMouseButtonDown(0))
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if ( Physics.Raycast(ray, out hit, 5f) )
			{
				hit.rigidbody.AddForce(ray.direction * 1000);
				Debug.Log("It hit something!");
			}
		}
		
		Vector3 mousePos = Input.mousePosition;
	    // If the mouse has moved since the last update
	    if (mousePos != lastPosition) 
		{
	    	lastPosition = mousePos;
	        // Get mouse X and Y position as a percentage of screen width and height
	        MoveMouse(mousePos.x/Screen.width, mousePos.y/Screen.height);
	    }
	    // Fade the alpha of the cursor
	    if (cursorIsFading) 
		{
			Color newColor = guiElement.color;
	        newColor.a = fadeValue;
			guiElement.color = newColor;
	        fadeValue -= fadeRate * Time.deltaTime;
	        if (fadeValue < fadeTo) 
			{
	            fadeValue = fadeTo;
	            cursorIsFading = false;
	        }
	    }	
	}
	
	void MoveMouse(float mousePosX, float mousePosY) 
	{
	    // Make the cursor solid, and set fading to start in case mouse movement stops
		Color newColor = guiElement.color;
	    newColor.a = fadeValue = normalAlpha;
		guiElement.color = newColor;
	    guiElement.texture = normalCursor;
	    cursorIsFading = true;
	 
	    // If the mouse is on a screen edge, first make sure the cursor doesn't go off the screen, then give it the appropriate cursor
	    if (mousePosX < .005f) {
	        mousePosX = .005f;
	        guiElement.texture = leftCursor;
	    }
	    if (mousePosX > .995f) {
	        mousePosX = .995f;
	        guiElement.texture = rightCursor;
	    }
	    if (mousePosY < .005f) {
	        mousePosY = .005f;
	        guiElement.texture = downCursor;
	    }
	    if (mousePosY > .995f) {
	        mousePosY = .995f;
	        guiElement.texture = upCursor;
	    }
	 
		Vector3 newTranformPosition = transform.position;
    	newTranformPosition.x =  mousePosX;
		newTranformPosition.y =  mousePosY;
		transform.position = newTranformPosition;
		
	}	
}
