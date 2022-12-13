using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{

    public Canvas[] inventoryUIArray;
    public Canvas[] notesCanvasArray;
    public Canvas[] collectionCanvasArray;

    public void ResetUI()
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
