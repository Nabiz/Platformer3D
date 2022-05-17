using UnityEngine;

public abstract class OpenableAndCloseable : MonoBehaviour {
    public bool isOpen;
    [HideInInspector] public bool isMoving;
    
    public abstract void Open();
    public abstract void Close();
}
