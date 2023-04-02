using UnityEngine;
using System.IO;

public class FpsDataExporter : MonoBehaviour
{
    private float fps;
    private string filePath;
    private StreamWriter fileWriter;
    private bool isWritingToSecondColumn;

    void Start()
    {
        // Set up file path
        filePath = Application.dataPath + "/fps_data.csv";

        // Open the file for writing
        fileWriter = new StreamWriter(filePath, true);
        fileWriter.WriteLine("Time,FPS");

        // Start recording FPS data
        InvokeRepeating("RecordFpsData", 0.0f, 1.0f);
    }

    void Update()
    {
        // Toggle writing to the second column when the "r" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            isWritingToSecondColumn = !isWritingToSecondColumn;
        }
    }

    void RecordFpsData()
    {
        // Calculate FPS
        fps = 1.0f / Time.deltaTime;

        // Write data to file
        if (isWritingToSecondColumn)
        {
            fileWriter.WriteLine(Time.time + ",," + fps);
        }
        else
        {
            fileWriter.WriteLine(Time.time + "," + fps);
        }
    }

    void OnApplicationQuit()
    {
        // Close the file when the application is quit
        fileWriter.Close();
    }
}