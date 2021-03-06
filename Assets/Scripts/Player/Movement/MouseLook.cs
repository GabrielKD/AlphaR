using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	
	// Mouse Look Style
	// 0 - MMO style 0 - default no mouse look; mouse look on right click
	// 1 - MMO style 1 - default mouse look; interrupt/resume mouse look on certain keys (default: Left Alt & Escape)
	// Will be read from PlayerPrefs
	private int mouseLookStyle = 0;
	
	// Mouse view flag - false if enabled;
	private bool mouseViewActive = false;

	void Update ()
	{
		//Screen.lockCursor = true;
		
		establishMouseView();
		
		// Debug.Log (mouseViewActive);
		if( mouseViewActive == true )
		{
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}
	}
	
	void Start ()
	{
		// Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
		
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	private void establishMouseView()
	{
		switch(mouseLookStyle)
		{
			case 0:
				// Mouse look via right click
				if( Input.GetMouseButtonDown(1) )
				{
					mouseViewActive = true;
				}
				
				if( Input.GetMouseButtonUp(1) )
				{
					mouseViewActive = false;
				}
			break;
			
			case 1:
				// Mouse look always on, disabled by specific keys
				// TO DO: make keys custamisable
				if( Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Escape) )
				{
					if( mouseViewActive == true )
					{
						mouseViewActive = false;
					}
					else
					{
						mouseViewActive = true;
					}
				}
			break;
		}
	}
}