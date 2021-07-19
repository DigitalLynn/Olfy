using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Channel1 : MonoBehaviour
{
    public string adress = "10.1.1.163"; // Priscilla's home IP address

    private void Start()
    {
        //ActiveSmell(); // Exemple d'appel du délenchement de l'odeur
    }

    public void ActiveSmell(int intensity, int duration, int channel)
    {
        Debug.Log($"activated, Intensity: {intensity}, Channel: {channel}, Duration: {duration}");

        IEnumerator coroutine;

        coroutine = SmellCoroutine(duration, channel, intensity);
        StartCoroutine(coroutine); // Launch of the request to the prototype
    }

    private IEnumerator SmellCoroutine(int duration, int channel, int intensity)
    {
        var request = new UnityWebRequest("http://" + adress + "/olfy/diffuse", "POST"); // URL configuration (IP address and type of request)
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes("{\"duration\": " + duration + ", \"channel\": " + channel + ",\"intensity\": " + intensity + ",\"booster\": false}"); // Concatination of the rar body written in JSON
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json"); // Configuration of the header to indicate that the content of the body is in json

        yield return request.SendWebRequest(); // Send the request and wait for a request

        Debug.Log("Status Code: " + request.responseCode); // Display of the status of the request
    }
}