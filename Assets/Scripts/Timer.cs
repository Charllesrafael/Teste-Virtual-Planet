using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CharllesDev
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private int secondsMax = 120;
        [SerializeField] private TextMeshProUGUI timerUI;
        [SerializeField] private UnityEvent OnFimContagem;


        private WaitForSeconds wait = new WaitForSeconds(1);
        private bool gameOn;

        private void Start()
        {
            timerUI.text = FormatTime(secondsMax);
        }

        public void StartTimerGame()
        {
            if (gameOn)
                return;

            gameOn = true;
            timerUI.text = FormatTime(secondsMax);
            StartCoroutine(StartTimer());
        }

        IEnumerator StartTimer()
        {
            int seconds = secondsMax;
            while (seconds > 0)
            {
                yield return wait;
                seconds--;
                timerUI.text = FormatTime(seconds);
            }
            timerUI.text = FormatTime(0);
            gameOn = false;
            OnFimContagem?.Invoke();
        }

        private string FormatTime(int _seconds)
        {
            return (_seconds / 60).ToString("00") + ":" + (_seconds % 60).ToString("00");
        }
    }
}
