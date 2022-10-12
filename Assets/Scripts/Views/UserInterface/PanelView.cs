using UnityEngine;

namespace Snake.Scripts.Views.UserInterface
{
    public class PanelView : MonoBehaviour
    {
        protected GameObject _panel;

        public void ShowPanel()
        {
            if (gameObject != null)
            {
                gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Panel is null");
            }
        }

        public void HidePanel()
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Panel is null");
            }
        }
    }
}