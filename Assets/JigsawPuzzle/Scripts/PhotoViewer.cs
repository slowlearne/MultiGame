using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoViewer : MonoBehaviour
{
    public RawImage photoDisplay;

    void Start()
    {
        // Load the most recent photo
        LoadRecentPhoto();
    }

    void LoadRecentPhoto()
    {
        // Get all the photo file paths in the persistent data path
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "photo_*.png");

        // Find the most recent photo
        string mostRecentPhotoPath = "";
        System.DateTime mostRecentDate = System.DateTime.MinValue;
        foreach (string filePath in filePaths)
        {
            System.DateTime creationTime = File.GetCreationTime(filePath);
            if (creationTime > mostRecentDate)
            {
                mostRecentDate = creationTime;
                mostRecentPhotoPath = filePath;
            }
        }

        // Load the most recent photo into a Texture2D
        if (!string.IsNullOrEmpty(mostRecentPhotoPath))
        {
            byte[] fileData = File.ReadAllBytes(mostRecentPhotoPath);
            Texture2D photoTexture = new Texture2D(2, 2); // Texture size is not important here
            photoTexture.LoadImage(fileData);

            // Display the photo in the RawImage component
            photoDisplay.texture = photoTexture;
        }
        else
        {
            Debug.Log("No photo found.");
        }
    }
}
