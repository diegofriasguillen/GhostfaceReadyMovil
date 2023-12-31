//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input Actions/EntradasMovimiento.inputactions
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

public partial class @EntradasMovimiento: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @EntradasMovimiento()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EntradasMovimiento"",
    ""maps"": [
        {
            ""name"": ""Movimiento"",
            ""id"": ""af74ff61-e41c-4e4e-be18-ab370b58b71c"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""55cefd2f-14fb-4f92-b620-029dda51dc34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Salto"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4306c53-c634-4b2a-b973-39acbd3860a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ataque"",
                    ""type"": ""Button"",
                    ""id"": ""b7903de7-bb3c-4214-af05-0db3d5cdd65d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dashing"",
                    ""type"": ""Button"",
                    ""id"": ""aeb7c3bf-bf73-4438-9e0b-5876fd32099c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Flechas"",
                    ""id"": ""ab8c103b-7451-4237-b4d8-7392d0c55a31"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""03a3aca2-8010-45da-b42e-3965b988891e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5b793f3b-5edf-4b00-9ebd-9a392db7243e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""227e4b29-b000-4391-8dae-33c1db25c2b5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b162c21e-1db6-4c6d-84fb-bc89059ae40d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""450aa05b-943d-405a-ab34-d2a1da79a8c4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7d526edd-b1cd-47be-8e3a-cfc5e8c7a0f9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Salto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f30c0a4e-244a-455d-b1c7-da791c3a8049"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ataque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da775d2-286a-471a-9e92-eda49793dc15"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dashing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Horizontal = m_Movimiento.FindAction("Horizontal", throwIfNotFound: true);
        m_Movimiento_Salto = m_Movimiento.FindAction("Salto", throwIfNotFound: true);
        m_Movimiento_Ataque = m_Movimiento.FindAction("Ataque", throwIfNotFound: true);
        m_Movimiento_Dashing = m_Movimiento.FindAction("Dashing", throwIfNotFound: true);
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

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private List<IMovimientoActions> m_MovimientoActionsCallbackInterfaces = new List<IMovimientoActions>();
    private readonly InputAction m_Movimiento_Horizontal;
    private readonly InputAction m_Movimiento_Salto;
    private readonly InputAction m_Movimiento_Ataque;
    private readonly InputAction m_Movimiento_Dashing;
    public struct MovimientoActions
    {
        private @EntradasMovimiento m_Wrapper;
        public MovimientoActions(@EntradasMovimiento wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Movimiento_Horizontal;
        public InputAction @Salto => m_Wrapper.m_Movimiento_Salto;
        public InputAction @Ataque => m_Wrapper.m_Movimiento_Ataque;
        public InputAction @Dashing => m_Wrapper.m_Movimiento_Dashing;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void AddCallbacks(IMovimientoActions instance)
        {
            if (instance == null || m_Wrapper.m_MovimientoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Add(instance);
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
            @Salto.started += instance.OnSalto;
            @Salto.performed += instance.OnSalto;
            @Salto.canceled += instance.OnSalto;
            @Ataque.started += instance.OnAtaque;
            @Ataque.performed += instance.OnAtaque;
            @Ataque.canceled += instance.OnAtaque;
            @Dashing.started += instance.OnDashing;
            @Dashing.performed += instance.OnDashing;
            @Dashing.canceled += instance.OnDashing;
        }

        private void UnregisterCallbacks(IMovimientoActions instance)
        {
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
            @Salto.started -= instance.OnSalto;
            @Salto.performed -= instance.OnSalto;
            @Salto.canceled -= instance.OnSalto;
            @Ataque.started -= instance.OnAtaque;
            @Ataque.performed -= instance.OnAtaque;
            @Ataque.canceled -= instance.OnAtaque;
            @Dashing.started -= instance.OnDashing;
            @Dashing.performed -= instance.OnDashing;
            @Dashing.canceled -= instance.OnDashing;
        }

        public void RemoveCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovimientoActions instance)
        {
            foreach (var item in m_Wrapper.m_MovimientoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);
    public interface IMovimientoActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnSalto(InputAction.CallbackContext context);
        void OnAtaque(InputAction.CallbackContext context);
        void OnDashing(InputAction.CallbackContext context);
    }
}
