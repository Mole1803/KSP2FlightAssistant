using KSP.Sim;
using KSP.Sim.impl;

namespace KSP2FlightAssistant;

public class Vesselnformation
{
    private VesselComponent vesselComponent;

    public Vesselnformation(VesselComponent _vesselComponent)
    {
        this.vesselComponent = _vesselComponent;
    }

    public Velocity GetVelocity()
    {
        return vesselComponent.Velocity;
    }

    public double GetVelocityMagnitude()
    {
        return vesselComponent.Velocity.relativeVelocity.magnitude;
    }

    public double GetVelocitySqrMagnitude()
    {
        return vesselComponent.Velocity.relativeVelocity.sqrMagnitude;
    }
    
    
    /// <summary>
    /// Returns the velocity of the vessel in the direction of the velocity vector. 
    /// </summary>
    public Vector3d GetVelocityVector()
    {

        
        return vesselComponent.Velocity.relativeVelocity.vector;
    }
    
    public double GetVelocityX()
    {
        return vesselComponent.Velocity.relativeVelocity.vector.x;
    }
    
    public double GetVelocityY()
    {
        return vesselComponent.Velocity.relativeVelocity.vector.y;
    }
    
    public double GetVelocityZ()
    {
        return vesselComponent.Velocity.relativeVelocity.vector.z;
    }
    
    
}