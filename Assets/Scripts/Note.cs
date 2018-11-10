using UnityEngine;

public class Note
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Sprite Sprite { get; set; }

    public Note(string id, string name, Sprite sprite)
    {
        Id = id;
        Name = name;
        Sprite = sprite;
    }
}