using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleObject : MonoBehaviour
{
   public GameObject objectScreen;

   myControls inputActions;

   public UnityEvent myAction;

   private void Awake()
   {
        inputActions = new myControls();
   }
   
   private void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("Player"))
        {
            LeanTween.scale(objectScreen, Vector3.one, 2).setEaseInBounce();
        }
   }

   private void OnTriggerExit(Collider other)
   {
        if (other.gameObject.CompareTag("Player"))
        {
            LeanTween.scale(objectScreen, Vector3.zero, 2).setEaseInQuad();
        }
   }

   private void OnTriggerStay(Collider other)
   {
        if (other.gameObject.CompareTag("Player"))
        {
            if(inputActions.Player.ActionKey.WasPerformedThisFrame())
            {
               myAction.Invoke();
            }
        }
   }

   public void OnEnable()
   {
        inputActions.Player.Enable();
   }

   public void onDisable()
   {
        inputActions.Player.Disable();
   }

}
