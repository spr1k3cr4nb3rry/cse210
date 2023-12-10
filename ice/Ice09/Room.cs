class Room {
    public string Name { get; set; }
    public List<SmartDevice> Devices { get; }

    public Room(string name) {
        Name = name;
        Devices = new List<SmartDevice>();
    }

    public void AddDevice(SmartDevice device) {
        Devices.Add(device);
    }
}