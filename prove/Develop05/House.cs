class House {
    public List<Room> Rooms { get; }

    public House() {
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room) {
        Rooms.Add(room);
    }
}