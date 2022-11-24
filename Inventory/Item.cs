using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{

	public int id;
    public string type;
	public string name;
	public string description;
    public Sprite icon;
	public bool isUsed;

	public Item(){
		
	}

	public Item(int id, string type, string name, string description, Sprite icon, bool isUsed){

		this.id = id;
        this.type = type;
		this.name = name;
		this.description = description;
        this.icon = icon;
		this.isUsed = isUsed;

	}
}
