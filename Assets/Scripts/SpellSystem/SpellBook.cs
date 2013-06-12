using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook : MonoBehaviour 
{
	
	public List<GameObject> spells = new List<GameObject>();
	
	public int ceva = 1245;
	
	// Use this for initialization
	void Start () 
	{
		// declaration
		// List<Type> myList = new List<Type>();        
		
		// a real-world example of declaring a List of 'ints'
		// List<int> someNumbers = new List<int>();   
		
		// a real-world example of declaring a List of 'GameObjects'
		// List<GameObject> enemies = new List<GameObject>();       
		
		// add an item to the end of the List
		// myList.Add(theItem);             
		
		// change the value in the List at position i
		// myList[i] = newItem;             
		
		// retrieve the item at position i
		// Type thisItem = List[i];         
		
		// remove the item from position i
		// myList.RemoveAt(i);		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int LeTest()
	{
		return ceva;
	}
}
