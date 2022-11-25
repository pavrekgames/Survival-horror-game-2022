using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Item")]
[System.Serializable]
public class Item: ScriptableObject{

	public int id;
    public string type;
	public string name;
	public string description;
    public Sprite icon;
	public bool isUsed;
    public bool isTaken;
    public bool isRemoved;

	public Item(){
		
	}

	public Item(int id, string type, string name, string description, Sprite icon, bool isUsed, bool isTaken, bool isRemoved){

		this.id = id;
        this.type = type;
		this.name = name;
		this.description = description;
        this.icon = icon;
		this.isUsed = isUsed;
        this.isTaken = isTaken;
        this.isRemoved = isRemoved;

	}
}
