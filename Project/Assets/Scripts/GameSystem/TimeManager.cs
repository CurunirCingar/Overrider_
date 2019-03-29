using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    private bool isTimeFreeze = false;
    [SerializeField] private float normalTimeValue = 1f;
    [SerializeField] private float freezeTimeValue = 0f;

    public Action<bool> OnTimeFreeze;

	public void SetTimeFreeze(bool state)
    {
        if (isTimeFreeze == state)
            return;

        isTimeFreeze = state;
        Time.timeScale = isTimeFreeze ? freezeTimeValue : normalTimeValue;
        if (OnTimeFreeze != null)
            OnTimeFreeze(isTimeFreeze);
    }
}
