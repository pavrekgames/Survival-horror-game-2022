using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour {

    public static Canvas[] inventoryUIArray;
    public static Canvas[] notesCanvasArray;
    public static Canvas[] collectionCanvasArray;
 
	void Start () {
		
	}
	
    public static void ResetUI()
    {

        InventoryUI.isInventoryActive = false;
        TasksUI.isTasksActive = false;
        NotesUI.isNotesActive = false;
        TreatmentUI.isTreatmentActive = false;
        CollectionBadgesUI.isCollectionActive = false;

        foreach (var inventoryUI in inventoryUIArray)
        {
            inventoryUI.enabled = false;
        }

        foreach (var notesCanvas in notesCanvasArray)
        {
            notesCanvas.enabled = false;
        }

        foreach (var collectionCanvas in collectionCanvasArray)
        {
            collectionCanvas.enabled = false;
        }

    }

}
