using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WheelFortune.UI
{
    public class UIRestartButtons : MonoBehaviour
    {
        [SerializeField] private List<Button> claimButtons;
        
        private void Awake()
        {
            claimButtons.ForEach(x=>x.onClick.AddListener(Restart));
        }
        
        private void OnDestroy()
        {
            claimButtons.ForEach(x=>x.onClick.RemoveListener(Restart));
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}

