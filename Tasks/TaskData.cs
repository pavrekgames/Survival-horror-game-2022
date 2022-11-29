using UnityEngine;

[CreateAssetMenu(fileName ="Task", menuName ="Task")]
[System.Serializable]
public class TaskData : ScriptableObject {

    public string title;
    public string content;
    public bool isAdded;
    public bool isRemoved;

    public TaskData(string title, string content, bool isAdded, bool isRemoved)
    {

        this.title = title;
        this.content = content;
        this.isAdded = isAdded;
        this.isRemoved = isRemoved;

    }

}
