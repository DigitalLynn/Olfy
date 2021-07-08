using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Choose if the controller or hand model is showing
    public bool showController = false;
    
    // This is the hand model prefab
    public GameObject handModelPrefab;
    // The hand model that will spawn in the game
    private GameObject spawnedHandModel;
    // The hand animator that manages the animation of the hand model
    private Animator handAnimator;

    // Makes the input device characteristics selectable from a public drop down menu
    public InputDeviceCharacteristics controllerCharacteristics;
    // Defines an input device in the XR input subsystem so information can be taken (buttons) and sent (haptic)
    private InputDevice targetDevice;

    // List of the controller prefabs of console devices, not hands
    public List<GameObject> controllerPrefabs;
    // Stores a local gameObject of the model
    private GameObject spawnedController;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialise();
    }

    /// <summary>
    /// This function is searching for and trying to find the controllers so that the models can be set and
    /// the target device can be defined so we can recieve input from the device
    /// </summary>
    void TryInitialise()
    {
        // Create a list for XR devices (hand controllers + headset)
        List<InputDevice> devices = new List<InputDevice>();

        // Populate the list with input devices
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        foreach (var item in devices)
        {
            // Show the name and characteristics of the devices
            Debug.Log(item.name + item.characteristics);
        }

        // Makes sure that there are devices present
        if (devices.Count > 0)
        {
            // Selects the target device as the first in the list
            targetDevice = devices[0];

            // Creates a gameobject called prefab and selects the controller prefab with the same name as the target device
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);

            // A game object in an if statement is essentially a null check
            if (prefab)
            {
                // Sets the spawned controller to the prefab model selected before
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                // If Unity couldn't find the correct controller then the spawnedController is set to the default
                spawnedController = Instantiate(controllerPrefabs[0], transform);
                Debug.LogError("Did not find correct controller model");
            }

            // Spawns the hand models and gives them the transfrom of their parent object
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            // Sets the animator to be the hand model's animator
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    /// <summary>
    /// This funtion is dedicated to the hand values, it gets the value of the target devices' buttons and 
    /// sets the hand animators parametres to that value or zero
    /// </summary>
    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If no target device is found then just keep looking
        if (!targetDevice.isValid)
        {
            TryInitialise();
        }
        else
        {
            if (showController)
            // Controller model shown
            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            // Hand models shown
            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                // This updates the hand animations
                UpdateHandAnimation();
            }
        }
    }
}
