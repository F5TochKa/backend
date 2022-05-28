using Final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class room : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public room(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select  RoomId as ""RoomId"",
                        RoomName as ""RoomName"",
                        Number as ""Number"",
                        BuildingId as ""BuildingId""
                        IsActive as ""IsActive"",
                        DictTypeRoomId as ""DictTypeRoomId"",
                        OwnerId as ""OwnerId"",
                        Square as ""Square"",
                        PlaceCount as ""PlaceCount""
                        DictRoomCategoryId as ""DictRoomCategoryId""
                        from room
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Room sof)
        {
            string query = @"
                insert into room( RoomName, Number, BuildingId, IsActive, DictTypeRoomId, OwnerId, Square, PlaceCount, DictRoomCategoryId)
                values ( @RoomName, @Number, @BuildingId, @IsActive, @DictTypeRoomId, @OwnerId, @Square, @PlaceCount, @DictRoomCategoryId)     
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@RoomName", sof.RoomName);
                    myCommand.Parameters.AddWithValue("@Number", sof.Number);
                    myCommand.Parameters.AddWithValue("@BuildingId", sof.BuildingId);
                    myCommand.Parameters.AddWithValue("@IsActive", sof.IsActive);
                    myCommand.Parameters.AddWithValue("@DictTypeRoomId", sof.DictTypeRoomId);
                    myCommand.Parameters.AddWithValue("@OwnerId", sof.OwnerId);
                    myCommand.Parameters.AddWithValue("@Square", sof.Square);
                    myCommand.Parameters.AddWithValue("@PlaceCount", sof.PlaceCount);
                    myCommand.Parameters.AddWithValue("@DictRoomCategoryId", sof.DictRoomCategoryId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Room sof)
        {
            string query = @"
                update room
                set RoomName = @RoomName
                set Number = @Number
                set BuildingId = @BuildingId
                set IsActive = @IsActive
                set DictTypeRoomId = @DictTypeRoomId
                set OwnerId = @OwnerId
                set Square = @Square
                set PlaceCount = @PlaceCount
                set DictRoomCategoryId = @DictRoomCategoryId
                where RoomId=@RoomId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@RoomId", sof.RoomId);
                    myCommand.Parameters.AddWithValue("@RoomName", sof.RoomName);
                    myCommand.Parameters.AddWithValue("@Number", sof.Number);
                    myCommand.Parameters.AddWithValue("@BuildingId", sof.BuildingId);
                    myCommand.Parameters.AddWithValue("@IsActive", sof.IsActive);
                    myCommand.Parameters.AddWithValue("@DictTypeRoomId", sof.DictTypeRoomId);
                    myCommand.Parameters.AddWithValue("@OwnerId", sof.OwnerId);
                    myCommand.Parameters.AddWithValue("@Square", sof.Square);
                    myCommand.Parameters.AddWithValue("@PlaceCount", sof.PlaceCount);
                    myCommand.Parameters.AddWithValue("@DictRoomCategoryId", sof.DictRoomCategoryId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from Room
                where RoomId=@RoomId  
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@RoomBuildingId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}

