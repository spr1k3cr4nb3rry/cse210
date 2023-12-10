using System;

class Program
{
    static void Main(string[] args) {
        // Create a house with rooms and smart devices
        House myHouse = new House();

        Room livingRoom = new Room("Living Room");
        livingRoom.AddDevice(new SmartLight("Living Room Light 1"));
        livingRoom.AddDevice(new SmartLight("Living Room Light 2"));
        livingRoom.AddDevice(new SmartTV("Living Room TV"));

        Room bedroom = new Room("Bedroom");
        bedroom.AddDevice(new SmartLight("Bedroom Light"));
        bedroom.AddDevice(new SmartHeater("Bedroom Heater"));

        myHouse.AddRoom(livingRoom);
        myHouse.AddRoom(bedroom);

        // Sample Room Commands
        foreach (Room room in myHouse.Rooms) {
            Console.WriteLine($"Room: {room.Name}");
            Console.WriteLine("Devices in the room:");

            foreach (SmartDevice device in room.Devices) {
                Console.WriteLine($"- {device.Name} ({device.GetDeviceType()}) is {(device.IsOn ? "On" : "Off")} for {device.TimeOn.TotalMinutes} minutes");
            }

            Console.WriteLine($"Total devices in the room: {room.Devices.Count}");
            Console.WriteLine($"Total devices that are on: {room.Devices.Count(device => device.IsOn)}");

            var longestOnDevice = room.Devices
                .OrderByDescending(device => device.TimeOn)
                .FirstOrDefault();

            if (longestOnDevice != null) {
                Console.WriteLine($"Device that has been on the longest: {longestOnDevice.Name} ({longestOnDevice.TimeOn.TotalMinutes} minutes)");
            }

            Console.WriteLine();
        }

        // Test turning on and off a device
        SmartDevice livingRoomLight = livingRoom.Devices.Find(device => device.Name == "Living Room Light 1");
        livingRoomLight.TurnOn();
        Console.WriteLine($"Turned on {livingRoomLight.Name} in the {livingRoom.Name}");

        // Wait for a minute to update time
        System.Threading.Thread.Sleep(60000);
        livingRoomLight.UpdateTimeOn();

        // Print updated status
        Console.WriteLine($"{livingRoomLight.Name} is {(livingRoomLight.IsOn ? "On" : "Off")} for {livingRoomLight.TimeOn.TotalMinutes} minutes");

        // Turn it off
        livingRoomLight.TurnOff();
        Console.WriteLine($"Turned off {livingRoomLight.Name} in the {livingRoom.Name}");
    }
}