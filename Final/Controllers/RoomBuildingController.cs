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
    public class roombuilding : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public roombuilding(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select  BuildingId as ""BuildingId"",
                        BuildingName as ""BuildingName"",
                        BuildingSName as ""BuildingSName"",
                        Address as ""Address""
                        NameFormatted as ""NameFormatted""
                        from RoomBuilding
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
        public JsonResult Post(RoomBuilding sof)
        {
            string query = @"
                insert into roombuilding( BuildingName, BuildingSName, Address, NameFormatted )
                values (@BuildingName, @BuildingSName, @Address, @NameFormatted )      
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BuildingName", sof.BuildingName);
                    myCommand.Parameters.AddWithValue("@BuildingSName", sof.BuildingSName);
                    myCommand.Parameters.AddWithValue("@Address", sof.Address);
                    myCommand.Parameters.AddWithValue("@NameFormatted", sof.NameFormatted);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(RoomBuilding sof)
        {
            string query = @"
                update roombuilding
                set BuildingName = @BuildingName
                set BuildingSName = @BuildingSName
                set Address = @Address
                set NameFormatted = @NameFormatted
                where BuildingId=@BuildingId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BuildingId", sof.BuildingId);
                    myCommand.Parameters.AddWithValue("@BuildingName", sof.BuildingName);
                    myCommand.Parameters.AddWithValue("@BuildingSName", sof.BuildingSName);
                    myCommand.Parameters.AddWithValue("@Address", sof.Address);
                    myCommand.Parameters.AddWithValue("@NameFormatted", sof.NameFormatted);
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
                delete from RoomBuilding
                where RoomBuildingId=@RoomBuildingId  
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

