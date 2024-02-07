using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB; // Add this line to import the FileBrowser namespace

public class CameraController : MonoBehaviour
{
    WebCamTexture webcamTexture;
    public RawImage rawImage;
    public GameObject webCam;
    public Material imageMaterial;
    private void Awake()
    {
        webCam.SetActive(false);
    }
    public void CloseCamera()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            rawImage.texture = webcamTexture;
            webcamTexture.Stop();
        }
        else
        {
            Debug.LogError("No camera found on this device.");
        }
        webCam.SetActive(false);
    }
    public void OpenWebCamera()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            // Use the first available camera
            webcamTexture = new WebCamTexture();
            rawImage.texture = webcamTexture;
            webcamTexture.Play();
        }
        else
        {
            Debug.LogError("No camera found on this device.");
        }
        webCam.SetActive(true);
    }
    public void CapturePhoto()
    {
        // Check if the device has a camera

        // Create a Texture2D to hold the captured image
        Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        // Copy the pixels from the WebCamTexture to the Texture2D
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        // Encode the Texture2D to a PNG byte array
        byte[] bytes = photo.EncodeToPNG();

        // Save the image to the device's storage
        string filename = "photo_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Photo saved to: " + filePath);

        // Create a new texture from the saved image
        Texture2D savedTexture = new Texture2D(2, 2);
        savedTexture.LoadImage(bytes);

        // Update the material with the new texture
        imageMaterial.mainTexture = savedTexture;
    }

    public void ChooseImage()
    {
        // Open a file browser dialog to choose an image file
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg", "gif" ),
            new ExtensionFilter("All Files", "*" ),
        };
        var paths = StandaloneFileBrowser.OpenFilePanel("Choose Image", "", extensions, false);

        // If a file is chosen, display it on the RawImage component
        if (paths.Length > 0)
        {
            string imagePath = paths[0];
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);
            rawImage.texture = texture;
            imageMaterial.mainTexture = texture;
        }
    }
}


