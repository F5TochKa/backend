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
    public class Softwarerooms : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Softwarerooms(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select  SoftwareRoomId as ""SoftwareRoomId"",
                        RoomId as ""RoomId"",
                        SoftwareId as ""SoftwareId"",
                        UsageDuration as ""UsageDuration""
                        from softwarerooms
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
        public JsonResult Post(SoftwareRooms sof)
        {
            string query = @"
                insert into softwarerooms( RoomId, SoftwareId, UsageDuration )
                values ( @RoomId, @SoftwareId, @UsageDuration )   
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
                    myCommand.Parameters.AddWithValue("@SoftwareId", sof.SoftwareId);
                    myCommand.Parameters.AddWithValue("@UsageDuration", sof.UsageDuration);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(SoftwareRooms sof)
        {
            string query = @"
                update softwarerooms
                set RoomId = @RoomId
                set SoftwareId = @SoftwareId
                set UsageDuration = @UsageDuration
                where SoftwareRoomId=@SoftwareRoomId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SoftwareRoomId", sof.SoftwareRoomId);
                    myCommand.Parameters.AddWithValue("@RoomId", sof.RoomId);
                    myCommand.Parameters.AddWithValue("@SoftwareId", sof.SoftwareId);
                    myCommand.Parameters.AddWithValue("@UsageDuration", sof.UsageDuration);
                  
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
                delete from softwarerooms
                where SoftwareRoomId=@SoftwareRoomId  
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SoftwareRoomId", id);
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

