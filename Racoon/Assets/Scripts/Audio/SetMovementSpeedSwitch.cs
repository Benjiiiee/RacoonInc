using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovementSpeedSwitch : MonoBehaviour
{
    // Name the switches
    public AK.Wwise.Switch MovementTypeJump;
    public AK.Wwise.Switch MovementTypeRun;
    public AK.Wwise.Switch MovementTypeLand;

    // This gets voided when the Function SetJumpSwitch() is called in an animation event, it sets the switch value in Wwise
    public void SetJumpSwitch()
    {
        MovementTypeJump.SetValue(gameObject);
    }

    // This gets voided when the Function SetRunSwitch() is called in an animation event, it sets the switch value in Wwise
    public void SetRunSwitch()
    {
        MovementTypeRun.SetValue(gameObject);
    }

    // This gets voided when the Function SetLandSwitch() is called in an animation event, it sets the switch value in Wwise
    public void SetLandSwitch()
    {
        MovementTypeLand.SetValue(gameObject);
    }

}