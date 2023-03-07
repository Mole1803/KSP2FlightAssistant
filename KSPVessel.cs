using KSP.Game;
using KSP.Sim.impl;
using KSP.Sim.State;

namespace KSP2FlightAssistant;

public class KSPVessel
{

    public GameInstance Game;
    public VesselComponent VesselComponent;
    private TelemetryDataProvider telemetryDataProvider;

    
    public KSPVessel(GameInstance Game)
    {
        this.Game = Game;
        VesselComponent = GetActiveSimVessel();
        telemetryDataProvider = Game.ViewController.DataProvider.TelemetryDataProvider;

    }
    
    private VesselComponent GetActiveSimVessel()
    {
        return  Game.ViewController.GetActiveSimVessel();
    }

    public void SetYaw(float yaw)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.yaw = yaw;
        UpdateFlightState(fcs);
    }

    public void SetPitch(float pitch)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.pitch = pitch;
        UpdateFlightState(fcs);
        
    }
    
    public void SetRoll(float roll)
    {
        FlightCtrlState fcs = this.GetFlightCtrlState();
        fcs.roll = roll;
        UpdateFlightState(fcs);
    }
    
    public void SetThrottle(float throttle)
    {
        FlightCtrlState fcs = this.GetFlightCtrlState();
        fcs.mainThrottle = throttle;
        UpdateFlightState(fcs);
        
    }

    public void SetKillRot(bool killRot)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.killRot = killRot;
        UpdateFlightState(fcs);
    }
    
    public void SetYawTrim(float yawTrim)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.yawTrim = yawTrim;
        UpdateFlightState(fcs);
    }
    
    public void SetPitchTrim(float pitchTrim)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.pitchTrim = pitchTrim;
        UpdateFlightState(fcs);
    }
    
    public void SetRollTrim(float rollTrim)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.rollTrim = rollTrim;
        UpdateFlightState(fcs);
    }
    
    public void SetYawInput(float yawInput)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.inputYaw = yawInput;
        UpdateFlightState(fcs);
    }
    
    public void SetPitchInput(float pitchInput)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.inputPitch = pitchInput;
        UpdateFlightState(fcs);
    }
    
    public void SetRollInput(float rollInput)
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.inputRoll = rollInput;
        UpdateFlightState(fcs);
    }
    
    public void SetThrottleMin()
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.mainThrottle = 0f;
        UpdateFlightState(fcs);
    }
    
    public void SetThrottleMax()
    {
        FlightCtrlState fcs = GetFlightCtrlState();
        fcs.mainThrottle = 1f;
        UpdateFlightState(fcs);
    }
    
    
    /// <summary>
    /// Updates the internal flight state of the vessel.
    ///
    /// </summary>
    private void UpdateFlightState(FlightCtrlState flightCtrlState)
    {
        FlightCtrlStateIncremental FCSI = VesselComponent.flightCtrlState.MakeIncrementalDiff(flightCtrlState);

        VesselComponent.ApplyFlightCtrlState(FCSI);
    }
    
    private FlightCtrlState GetFlightCtrlState()
    {
        return VesselComponent.flightCtrlState;
    }
    
    public void SetSAS(bool sas)
    {
        Game.ViewController.DataProvider.TelemetryDataProvider.SASRetrograde.SetValueInternal(sas);
    }
    
    /// <summary>
    /// Returns the velocity of the vessel that is displayed HUD.
    ///
    /// </summary>
    public double GetDisplaySpeed()
    {
        
        KSP.Sim.SpeedDisplayMode speedDisplayMode = Game.ViewController.DataProvider.TelemetryDataProvider.SpeedDisplayMode.GetValue();
        return telemetryDataProvider.GetSpeedDisplayValue(speedDisplayMode);
    }




}