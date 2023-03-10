//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Data/CharacterInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CharacterInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInputAction"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""acaf8787-20b1-48c4-89bd-3ce99bdc2cc4"",
            ""actions"": [
                {
                    ""name"": ""WalkLeft"",
                    ""type"": ""Value"",
                    ""id"": ""835bbfd0-aaa2-487a-85c9-1f55448f5acb"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""WalkRight"",
                    ""type"": ""Value"",
                    ""id"": ""492660e8-89d5-41ca-a243-7402fc142169"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e45354b0-5cb5-4459-b6bb-c5b2dd8be9c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d2dccaf-c786-4413-8e48-5c425af55019"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""756996ab-8e50-4485-a166-80a7c706c053"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d38c278-d528-4aec-ae22-6d2b6b226e37"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_WalkLeft = m_Movement.FindAction("WalkLeft", throwIfNotFound: true);
        m_Movement_WalkRight = m_Movement.FindAction("WalkRight", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_WalkLeft;
    private readonly InputAction m_Movement_WalkRight;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @CharacterInputAction m_Wrapper;
        public MovementActions(@CharacterInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @WalkLeft => m_Wrapper.m_Movement_WalkLeft;
        public InputAction @WalkRight => m_Wrapper.m_Movement_WalkRight;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @WalkLeft.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkLeft;
                @WalkLeft.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkLeft;
                @WalkLeft.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkLeft;
                @WalkRight.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkRight;
                @WalkRight.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkRight;
                @WalkRight.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalkRight;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WalkLeft.started += instance.OnWalkLeft;
                @WalkLeft.performed += instance.OnWalkLeft;
                @WalkLeft.canceled += instance.OnWalkLeft;
                @WalkRight.started += instance.OnWalkRight;
                @WalkRight.performed += instance.OnWalkRight;
                @WalkRight.canceled += instance.OnWalkRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnWalkLeft(InputAction.CallbackContext context);
        void OnWalkRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
