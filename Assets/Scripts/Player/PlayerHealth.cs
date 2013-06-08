using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	// Player maximum health
	public int maxHealth = 100;
	
	// Player's current health - will modify according to damage/heals/buffs
	public int currentHealth = 100;
	
	// Default Length of the player's health bar
	public float maxHealthBarLength;
	
	// Current Length of the player's health bar
	public float currentHealthBarLength;
	
	// Healthbar Texture & Style
	public Texture2D healthTexture = new Texture2D(512, 512);
	public GUIStyle healthStyle = new GUIStyle();
	
	// Healthbar text overlay texture
	public Texture2D healthOverlayTexture = new Texture2D(128, 128);
	public GUIStyle healthOverlayStyle = new GUIStyle();
	public GUIStyle healthOverlayStyleOutline = new GUIStyle();
	
	// Use this for initialization
	void Start () 
	{
		// Setting default health bar length
		currentHealthBarLength = maxHealthBarLength = Screen.width / 3;
		
		// Setting texture for the health bar style (its backgroun)
		healthStyle.normal.background = healthTexture;
		
		// Setting texture and alignment for the text overlay
		healthOverlayStyle.normal.background = healthOverlayTexture;
		healthOverlayStyle.alignment = TextAnchor.MiddleCenter;
		healthOverlayStyle.normal.textColor = Color.white;
		
		healthOverlayStyleOutline.normal.textColor = Color.black;
		healthOverlayStyleOutline.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
		// Calling health adjustment with 0 for now, no interaction from any damage yet
		adjustCurrentHealth(0);
	}
	
	// Interface draw
	void OnGUI(){
		// Drawing the healathbar "placeholder"
		GUI.Box (new Rect(10, 10, maxHealthBarLength, 20), "");	
		
		// Drawing the health bar itself
		GUI.Box (new Rect(10, 10, currentHealthBarLength, 20), "", healthStyle);
		
		Rect position = new Rect(10, 10, maxHealthBarLength, 20);
		position.x--;
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyleOutline);
		position.x+=2;
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyleOutline);
		position.x--;
		position.y--;
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyleOutline);
		position.y+=2;
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyleOutline);
		position.y--;
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyleOutline);
		
		GUI.Label(position, currentHealth + "/" + maxHealth, healthOverlayStyle);
		
		// Drawing the health bar text overlay
		//GUI.Box (new Rect(10, 10, maxHealthBarLength, 20), currentHealth + "/" + maxHealth, healthOverlayStyle);	
	}
	
	// Adjusts current health based on received amount
	public void adjustCurrentHealth(int amount)
	{
		// Adding requested amount (if negative, it will be substracted)
		currentHealth += amount;
		
		// Do not allow current health to drop below 0
		if(currentHealth < 0)
		{
			currentHealth = 0;
		}
		
		// Do not allow current health to go over 0
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		
		// Maximum health can't be lower than 1
		if(maxHealth < 1)
		{
			maxHealth = 1;
		}
		
		// Adjusting the current bar health (just the number used in Update to actually draw it)
		currentHealthBarLength = maxHealthBarLength * (currentHealth / (float)maxHealth);
		
		// Do not allow current health bar to go over the maximum bar health
		if(currentHealthBarLength > maxHealthBarLength)
		{
			currentHealthBarLength = maxHealthBarLength;
		}
	}
}
