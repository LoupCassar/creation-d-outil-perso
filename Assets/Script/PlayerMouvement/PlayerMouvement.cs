using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMouvement
{
    InputManager inputManager;
    bool FpsActive = true;
    float MouseSensitivity = 50f;
    public PlayerMouvement(InputManager inputManager)
    {
        this.inputManager = inputManager;
    }


    private Camera VisionFPS;


    private int GetAxisKey(KeyCode positive, KeyCode negative)
    {
        if (Input.GetKey(positive)) return 1;
        if (Input.GetKey(negative)) return -1;
        return 0;
    }
    public int MouvementJoueurAvantArierre() => GetAxisKey(KeyCode.W, KeyCode.S);
    public int MouvementJoueurGaucheDroite() => GetAxisKey(KeyCode.D, KeyCode.Q); 

    /*public int MouvementJoueurAvantArierre() => GetAxisKey(inputManager.Control.GetValueOrDefault(KeybindingAction.Forward), inputManager.Control.GetValueOrDefault(KeybindingAction.Backward));
    public int MouvementJoueurGaucheDroite() => GetAxisKey(inputManager.Control.GetValueOrDefault(KeybindingAction.Right), inputManager.Control.GetValueOrDefault(KeybindingAction.Left));*/

    public int PlayerMouvementJump() => Input.GetKey(inputManager.Control.GetValueOrDefault(KeybindingAction.Jump)) ? 1 : 0;
    public int PlayerMouvementFly() => Input.GetKey(inputManager.Control.GetValueOrDefault(KeybindingAction.Crouche)) ? 1 : -1;
    public float GetCameraVertical() => Mathf.Clamp(MouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime, -80, 80);
    public float GetCameraHorizontal() => -MouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

    #region Rigidbody
    private void PlayerRigidebodyMouvement(Transform playerMouvementt,Rigidbody playerrb,int vertical,int horizontal, float playerspeed)
    {
        playerrb.AddForce(playerMouvementt.forward.normalized * vertical * playerspeed, ForceMode.VelocityChange);
        playerrb.AddForce(playerMouvementt.right.normalized * horizontal * playerspeed, ForceMode.VelocityChange);
    }
    private void PlayerRigidebodyVitesseClamp(Rigidbody player,float maxmouvementt)
    {
        // limite la vitesse du joueur
        Vector3 velocityXZ = new Vector3(player.velocity.x, 0, player.velocity.z);
        velocityXZ = Vector3.ClampMagnitude(velocityXZ, maxmouvementt);
        player.velocity = new Vector3(velocityXZ.x, player.velocity.y, velocityXZ.z);

    }
    public bool RigidebodyGrounded(Transform playerT, CapsuleCollider playerc, Rigidbody playerrb)
    {
        if (playerrb != null)
        {
            //cree une distance maximale adaptative a la taille de l'entité
            Physics.Raycast(playerT.transform.position, Vector3.down, out RaycastHit hitInfo, playerc.height/2);
            return hitInfo.collider != null;
        }
        return false;
    }
    private void PlayerRigidbodyJump(Transform playerT, CapsuleCollider playerc, Rigidbody playerrb,float jumpspeed, float JumpDebuf)
    {
        JumpDebuf = Mathf.Clamp(JumpDebuf, -1, jumpspeed);
        if (JumpDebuf < 0)
        {
            playerrb.AddForce(playerT.up.normalized * PlayerMouvementFly() * jumpspeed, ForceMode.VelocityChange);

        }
        else if (RigidebodyGrounded(playerT, playerc, playerrb) == true)
        {
            playerrb.AddForce(playerT.up.normalized * PlayerMouvementJump() * (jumpspeed - JumpDebuf), ForceMode.VelocityChange);
        }
    }
    public void PlayerRigidebodyDeplacement(Transform cameraT, Transform playerT, CapsuleCollider playerc, Rigidbody playerrb, float playerspeed,float jumpspeed , float JumpDebuf)
    {
        //deplacement du joueur
        PlayerRigidebodyMouvement(playerT, playerrb, MouvementJoueurAvantArierre(),MouvementJoueurGaucheDroite(), playerspeed);

        //saut

        PlayerRigidbodyJump(playerT, playerc, playerrb, jumpspeed, JumpDebuf);

        // limite la vitesse du joueur
        PlayerRigidebodyVitesseClamp(playerrb, playerspeed);

    }
    #endregion Rigidbody

    #region CharacterController
    private void PlayerCharacterControllerMouvement(Transform playerMouvementt, CharacterController playercc, int vertical, int horizontal, float playerspeed)
    {
        Vector3 move = playerMouvementt.forward * vertical + playerMouvementt.right * horizontal;
        playercc.Move(move * Time.deltaTime * playerspeed);
    }
    private void PlayerCharacterControllerJump(Transform playerMouvementt, CapsuleCollider playerc, CharacterController playercc, float jumpspeed, float JumpDebuf)
    {
        JumpDebuf = Mathf.Clamp(JumpDebuf, 0, jumpspeed);
        if (JumpDebuf < 0)
        {
            //playercc.Move(playerMouvementt.transform.up.normalized * PlayerMouvementFly() * jumpspeed * Time.deltaTime);
            Vector3 move = playerMouvementt.up * PlayerMouvementFly();
            playercc.Move(move * Time.deltaTime * jumpspeed);
        }
        else if (playercc.isGrounded == true)
        {
            //playercc.Move(playerMouvementt.transform.up.normalized * PlayerMouvementJump() * jumpspeed * Time.deltaTime);
            Vector3 move = playerMouvementt.up * PlayerMouvementJump();
            playercc.Move(move * Time.deltaTime * jumpspeed);
        }
    }
    /*
    public void PlayerCharacterControllerVitesseClamp(CharacterController joueur, float maxmouvementt)
    {
        // limite la vitesse du joueur
        Vector3 velocityXZ = new Vector3(joueur.velocity.x, 0, joueur.velocity.z);
        velocityXZ = Vector3.ClampMagnitude(velocityXZ, maxmouvementt);
        joueur.Move(new Vector3(velocityXZ.x, joueur.velocity.y, velocityXZ.z) * Time.deltaTime);
    }*/
    public void PlayerCharacterControllerDeplacement(Transform playerMouvementt, CapsuleCollider playerc, CharacterController playercc, float playerspeed, float jumpspeed, float JumpDebuf)
    {
        //deplacement du joueur
        PlayerCharacterControllerMouvement(playerMouvementt, playercc, MouvementJoueurAvantArierre(), MouvementJoueurGaucheDroite(), playerspeed);

        //saut
        PlayerCharacterControllerJump(playerMouvementt, playerc, playercc, jumpspeed, JumpDebuf);
    }
    #endregion CharacterController

    #region Camera
    public void PlayerCameraFps(Transform playerT ,Camera Playercamera) 
    {
        //mouvement de la camera
        playerT.Rotate(0, GetCameraVertical(), 0);
        Playercamera.gameObject.transform.Rotate(GetCameraHorizontal(), 0, 0);
    }
    public void PlayerCameraThirdperson(Transform lookatpoint, Camera Playercamera,float distance,float height)
    {
        Vector3 offSet = lookatpoint.forward * (-1) * distance + lookatpoint.up * height;
        Vector3 desiredPosition = lookatpoint.position + offSet;

        //quality of life smooth camera movement
        Vector3 smoothedPosition = Vector3.Lerp(Playercamera.transform.position, desiredPosition, 10f * Time.deltaTime);
        Playercamera.transform.position = smoothedPosition;
        //Playercamera.transform.position = desiredPosition;

        Quaternion desiredRotation =  Quaternion.LookRotation(lookatpoint.position - Playercamera.transform.position);
        Quaternion smoothedRotation = Quaternion.Slerp(Playercamera.transform.rotation, desiredRotation, 10f * Time.deltaTime);
        Playercamera.transform.rotation = smoothedRotation;
        //Playercamera.transform.rotation = desiredRotation;

        lookatpoint.Rotate(GetCameraHorizontal(), GetCameraVertical(), 0);

    }
    #endregion Camera

    public RaycastHit PlayerCameraRaycastHit(Camera playerCamera,LayerMask playerLayerMask)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerLayerMask))

        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            return hit;
        }
        else
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return new RaycastHit();
        }
    }
    #region out Interaction
    public void Interact(Transform cameraTransform, float castDistance, LayerMask playerLayerMask)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CameraDoIteract(out IInteractable interactable, cameraTransform , castDistance, playerLayerMask))
            {
                interactable.OnInteract();
            }
        }
    }
    public bool CameraDoIteract(out IInteractable Interactable, Transform positionCamera, float castDistance ,LayerMask playerLayerMask)
    {
        Interactable = null;
        Ray ray = new Ray(positionCamera.position, positionCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, castDistance, ~playerLayerMask))
        {
            Debug.DrawLine(ray.origin, hitinfo.point, Color.green, castDistance);

            IInteractable interactable = hitinfo.collider.GetComponent<IInteractable>();

            if (interactable != null && interactable.CanInteract())
            {
                Interactable = interactable;
                return true;
            }
            return false;
        }
        return false;
    }
    /*
    public void Attack(Transform cameraTransform, float castDistance, LayerMask playerLayerMask)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (CameraDoAttack(out IInteractable interactable, cameraTransform, castDistance, playerLayerMask))
            {
                interactable.OnInteract(this);
            }
        }
    }
    public bool CameraDoAttack(out IInteractable Interactable, Transform positionCamera, float castDistance, LayerMask playerLayerMask)
    {
        Interactable = null;
        Ray ray = new Ray(positionCamera.position, positionCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, castDistance, playerLayerMask))
        {
            Debug.DrawLine(ray.origin, hitinfo.point, Color.red, castDistance);

            IInteractable interactable = hitinfo.collider.GetComponent<IInteractable>();

            if (interactable != null && interactable.CanInteract())
            {
                Interactable = interactable;
                return true;
            }
            return false;
        }
        return false;
    }
    */


    #endregion out Interaction
}
