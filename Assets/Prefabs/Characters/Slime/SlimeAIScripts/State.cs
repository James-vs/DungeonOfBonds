using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    // abstract class to be inherited
    // method to return a State 
    public abstract State RunCurrentState();

}
