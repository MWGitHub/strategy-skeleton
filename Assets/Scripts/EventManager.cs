using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {
    private Dictionary<string, UnityEvent> events;

    private static EventManager eventManager;

    public static EventManager Instance {
        get {
            if (!eventManager) {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager) {
                    Debug.LogError("There needs to be one active EventManager script");
                } else {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    public static void AddListener(string name, UnityAction listener) {
        UnityEvent addedEvent = null;
        if (Instance.events.TryGetValue(name, out addedEvent)) {
            addedEvent.AddListener(listener);
        } else {
            addedEvent = new UnityEvent();
            addedEvent.AddListener(listener);
            Instance.events.Add(name, addedEvent);
        }
    }

    void Init() {
        if (events == null) {
            events = new Dictionary<string, UnityEvent>();
        }
    }
}
