using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        // Get the x and y position of the parent object and divide by the unity editors snap settings
        // Round the results from a float to an int then store that in the x/y position of the vector2int
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        // Set the label's text to it's parents x and y coordinates.
        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectName()
    {
        // Updates the parent objects name to its coordinates retreived in DisplayCoordinates()
        transform.parent.name = coordinates.ToString();
    }
}
