using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Player
{

    public class FinishCheck : MonoBehaviour
    {
        public TMP_Text ChancesText;
        public UnityEvent OnZeroChance;

        public int InitialChances = 5;

        private int RemainingChances;

        public void DecreaseChance()
        {
            RemainingChances--;
            ChancesText.text = RemainingChances.ToString();
            if(RemainingChances < 0)
            {
                OnZeroChance.Invoke();
            }
        }

        public void IncreaseChance(int amount = 1)
        {
            RemainingChances += amount;
            ChancesText.text = RemainingChances.ToString();
        }

        public void Initialize()
        {
            RemainingChances = InitialChances;
            ChancesText.text = RemainingChances.ToString();
        }

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }
    }
}
