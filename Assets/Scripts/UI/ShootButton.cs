using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private Button _shootButton;
    [SerializeField] private PlayerInput _playerInput;

    private bool continuousShoot = false;

    private void Awake()
    {
        EventTrigger eventTrigger = _shootButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { EnableContinuousShoot(); });
        eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { DisableContinuousShoot(); });
        eventTrigger.triggers.Add(pointerUpEntry);
    }

    private void Update()
    {
        if (continuousShoot)
        {
            _playerInput.UIKeyFirePressed();
        }
    }

    private void EnableContinuousShoot()
    {
        continuousShoot = true;
    }

    private void DisableContinuousShoot()
    {
        continuousShoot = false;
    }
}
