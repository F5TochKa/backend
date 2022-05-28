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
    public class Dictroomproperty : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Dictroomproperty(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select  DictRoomPropertyId as ""DictRoomPropertyId"",
                        PropertyName as ""PropertyName"",
                        PropertyGroup as ""PropertyGroup"",
                        DisplayName as ""DisplayName""
                        from DictRoomProperty
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
        public JsonResult Post(DictRoomProperty sof)
        {
            string query = @"
                insert into room( PropertyName, PropertyGroup, DisplayName)
                values ( @PropertyName, @PropertyGroup, @DisplayName)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PropertyName", sof.PropertyName);
                    myCommand.Parameters.AddWithValue("@PropertyGroup", sof.PropertyGroup);
                    myCommand.Parameters.AddWithValue("@DisplayName", sof.DisplayName);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(DictRoomProperty sof)
        {
            string query = @"
                update dictroomproperty
                set PropertyName = @PropertyName
                set PropertyGroup = @PropertyGroup
                set DisplayName = @DisplayName
                where DictRoomPropertyId=@DictRoomPropertyId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DictRoomPropertyId", sof.DictRoomPropertyId);
                    myCommand.Parameters.AddWithValue("@PropertyName", sof.PropertyName);
                    myCommand.Parameters.AddWithValue("@PropertyGroup", sof.PropertyGroup);
                    myCommand.Parameters.AddWithValue("@DisplayName", sof.DisplayName);
                 
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
                delete from dictroomproperty
                where DictRoomPropertyId=@DictRoomPropertyId  
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DictRoomPropertyId", id);
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

