using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(LevelEndBehaviour))]
public class LevelEventsListener : MonoBehaviour
{
    [SerializeField] private LevelEvents _levelEvents;

    private PlayerMover _playerMover;
    private LevelEndBehaviour _levelEndBehavoiur;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _levelEndBehavoiur = GetComponent<LevelEndBehaviour>();
    }

    private void OnEnable()
    {
        _levelEvents.LevelBossDied += OnBossDie;
    }

    private void OnDisable()
    {
        _levelEvents.LevelBossDied -= OnBossDie;
    }

    private void OnBossDie()
    {
        _playerMover.enabled = false;
        _levelEndBehavoiur.enabled = true;
    }
}
