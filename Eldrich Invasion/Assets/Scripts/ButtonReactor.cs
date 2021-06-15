using System.Collections;
using UnityEngine;

public class ButtonReactor : MonoBehaviour
{
    public ButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        gameObject.GetComponent<UnitBehaviour>().TakeDamage(999);
    }


}
