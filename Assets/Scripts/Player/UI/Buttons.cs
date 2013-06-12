using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	// Button texture and style
	public Texture2D buttonTexture;
	public GUIStyle buttonStyle;
	
	// Fetching the spellbook
	SpellBook theSpellBook = new SpellBook();
	
	public string ceva;

	void Awake ()
	{
		theSpellBook = gameObject.GetComponent<SpellBook>();
	}
	
	// Use this for initialization
	void Start () {
		
		buttonStyle = new GUIStyle();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ceva = "";
		if(theSpellBook is SpellBook)
		{
			ceva = theSpellBook.LeTest().ToString();	
		}
	}
	
	void OnGUI()
	{
		GUI.Button(new Rect(0,0,100,100), ceva);
		
		GUI.Button(new Rect( ((Screen.width / 2) - 50), (Screen.height - 100), 100, 100), "Test Skill");
	}
}
