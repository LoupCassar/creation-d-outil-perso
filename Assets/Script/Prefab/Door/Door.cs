using UnityEngine;

public class Door : MonoBehaviour , IInteractable
{
    public bool isOpen = false;

    [SerializeField] private bool openInOppositionToInteractor = false;
    public interface IInteractable
    {

        public bool CanInteract()
        {
            return true;
        }
        public void OnInteract()
        {
            switch (CanInteract())
                {
                case true:
                    
                    break;
                case false:
                    Debug.Log("Cannot interact with Door");
                    break;
            }
        }
    }
}
