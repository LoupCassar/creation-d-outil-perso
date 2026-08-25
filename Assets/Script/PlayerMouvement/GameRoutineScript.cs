using UnityEngine;

public class GameRoutineScript : MonoBehaviour
{
    PlayerMouvement playerMouvement;
    InputManager inputManager;

    [SerializeField] private bool isFpsActive = true;
    [SerializeField] public GameObject JoueurGO;
    [SerializeField] public GameObject JoueurRenderGO;
    [SerializeField] public Transform LookAtPoint;
    [SerializeField] public Rigidbody JoueurRb;
    [SerializeField] public CapsuleCollider JoueurC;
    [SerializeField] public CharacterController JoueurCC;
    [SerializeField] public Camera VisionFPS;
    [SerializeField] int MouseSensitivity = 20;
    [SerializeField] int DistanceCamera = 2;
    [SerializeField] int heightCamera = 2;
    [SerializeField] int DistanceInteract = 2;

    void Awake()
    {
        inputManager = new InputManager();
        inputManager.Control = inputManager.ControlAzertyDictionary();
        playerMouvement = new PlayerMouvement(inputManager);
        Debug.Log(inputManager.Control.Keys);
    }
    void Start()
    {
        inputManager.Control = inputManager.ControlAzertyDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFpsActive)
        {
            VisionFPS.gameObject.transform.position = JoueurGO.transform.position + new Vector3(0, 0.5f, 0);
            playerMouvement.PlayerCameraFps(JoueurGO.transform, VisionFPS);

        }
        else
        {
            playerMouvement.PlayerCameraThirdperson(LookAtPoint, VisionFPS, DistanceCamera, heightCamera);
        }
        playerMouvement.Interact(VisionFPS.transform, DistanceInteract,JoueurGO.layer);
    }

    private void FixedUpdate()
    {
        if (JoueurCC != null)
        {
            playerMouvement.PlayerCharacterControllerDeplacement(JoueurGO.transform, JoueurC, JoueurCC, 1, 3, 0);
        }
        if(JoueurRb != null)
        {
            playerMouvement.PlayerRigidebodyDeplacement(VisionFPS.gameObject.transform, JoueurGO.transform, JoueurC, JoueurRb, 1f, 3, 0f);
        }
    }
}
