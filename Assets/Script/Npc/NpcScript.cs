using System.Collections;
using UnityEngine;

public class NpcScript : MonoBehaviour, IInteractable
{
    [SerializeField]Transform workStation;
    [SerializeField] Transform home;
    [SerializeField] float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void WalkTo(Transform destination,float walkSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * walkSpeed);
    }
    public void DayRoutine(float Time, float walkSpeed)
    {
        if (Time >= 8f && Time < 17f)
        {
            WalkTo(workStation, walkSpeed);
        }
        else
        {
            WalkTo(home, walkSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {

        DayRoutine(currentTime,1);
    }

}

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
                Debug.Log("Interacted with NPC");
                break;
            case false:
                Debug.Log("Cannot interacte with NPC");
                break;
        }
    }


}