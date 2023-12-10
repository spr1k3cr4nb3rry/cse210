using System.Dynamic;

abstract class SmartDevice {
    public string Name { get; set; }
    public bool IsOn { get; set; }
    public TimeSpan TimeOn { get; set; }

    // Getter
    public SmartDevice(string name) {
        Name = name;
        IsOn = false;
        TimeOn = TimeSpan.Zero;
    }
    
    public void TurnOn() {
        if (!IsOn) {
            IsOn = true;
            TimeOn = TimeSpan.Zero;
        }
    }

    public void TurnOff() {
        if (IsOn) {
            IsOn = false;
        }
    }

    public void UpdateTimeOn() {
        if (IsOn) {
            TimeOn = TimeOn.Add(TimeSpan.FromMinutes(1));
        }
    }

    public abstract string GetDeviceType();
}