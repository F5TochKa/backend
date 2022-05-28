namespace Final.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public string Number { get; set; }

        public int BuildingId { get; set; }

        public int IsActive { get; set; }

        public int DictTypeRoomId { get; set; }

        public int OwnerId { get; set; }

        public decimal Square { get; set; }

        public int PlaceCount { get; set; }

        public int DictRoomCategoryId { get; set; }


    }
}
