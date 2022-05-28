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
    public class Os : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Os(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select  OSId as ""OSId"",
                        OSName as ""OSName"",
                        DictCategoryId as ""DictCategoryId"",
                        InventoryNumber as ""InventoryNumber""
                        OSCount as ""OSCount""
                        UsedFrom as ""UsedFrom""
                        Cost as ""Cost""
                        Purchased as ""Purchased""
                        Charged as ""Charged""
                        DictBudgetId as ""DictBudgetId""  
                        DictTypeId as ""DictTypeId""
                        OSSerial as ""OSSerial""
                        DictBillId as ""DictBillId""
                        DictOsUsageId as ""DictOsUsageId""
                        Visible as ""Visible""
                        LastUpdate as ""LastUpdate""
                        from os
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
        public JsonResult Post(OS sof)
        {
            string query = @"
                insert into softwarerooms( OSName, DictCategoryId, InventoryNumber, OSCount, UsedFrom, Cost, Purchased, Charged, DictBudgetId, DictTypeId, OSSerial, DictBillId, DictOsUsageId, Visible, LastUpdate )
                values ( @OSName, @DictCategoryId, @InventoryNumber, @OSCount, @UsedFrom, @Cost, @Purchased, @Charged, @DictBudgetId, @DictTypeId, @OSSerial, @DictBillId, @DictOsUsageId, @Visible, @LastUpdate )
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@OSName", sof.OSName);
                    myCommand.Parameters.AddWithValue("@DictCategoryId", sof.DictCategoryId);
                    myCommand.Parameters.AddWithValue("@InventoryNumber", sof.InventoryNumber);
                    myCommand.Parameters.AddWithValue("@OSCount", sof.OSCount);
                    myCommand.Parameters.AddWithValue("@UsedFrom", sof.UsedFrom);
                    myCommand.Parameters.AddWithValue("@Cost", sof.Cost);
                    myCommand.Parameters.AddWithValue("@Purchased", sof.Purchased);
                    myCommand.Parameters.AddWithValue("@Charged", sof.Charged);
                    myCommand.Parameters.AddWithValue("@DictBudgetId", sof.DictBudgetId);
                    myCommand.Parameters.AddWithValue("@DictTypeId", sof.DictTypeId);
                    myCommand.Parameters.AddWithValue("@OSSerial", sof.OSSerial);
                    myCommand.Parameters.AddWithValue("@DictBillId", sof.DictBillId);
                    myCommand.Parameters.AddWithValue("@DictOsUsageId", sof.DictOsUsageId);
                    myCommand.Parameters.AddWithValue("@Visible", sof.Visible);
                    myCommand.Parameters.AddWithValue("@LastUpdate", sof.LastUpdate);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(OS sof)
        {
            string query = @"
                update os
                set OsId = @OsId
                set OSName = @OSName
                set InventoryNumber = @InventoryNumber
                set OSCount = @OSCount
                set UsedFrom = @UsedFrom
                set Cost = @Cost
                set Purchased = @Purchased
                set Charged = @Charged
                set DictBudgetId = @DictBudgetId
                set DictTypeId = @DictTypeId
                set OSSerial = @OSSerial
                set DictBillId = @DictBillId
                set DictOsUsageId =@DictOsUsageId
                set Visible = @Visible
                set LastUpdate = @LastUpdate
                where OSId=@OSId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@OsId", sof.OSId);
                    myCommand.Parameters.AddWithValue("@OSName", sof.OSName);
                    myCommand.Parameters.AddWithValue("@DictCategoryId", sof.DictCategoryId);
                    myCommand.Parameters.AddWithValue("@InventoryNumber", sof.InventoryNumber);
                    myCommand.Parameters.AddWithValue("@OSCount", sof.OSCount);
                    myCommand.Parameters.AddWithValue("@UsedFrom", sof.UsedFrom);
                    myCommand.Parameters.AddWithValue("@Cost", sof.Cost);
                    myCommand.Parameters.AddWithValue("@Purchased", sof.Purchased);
                    myCommand.Parameters.AddWithValue("@Charged", sof.Charged);
                    myCommand.Parameters.AddWithValue("@DictBudgetId", sof.DictBudgetId);
                    myCommand.Parameters.AddWithValue("@DictTypeId", sof.DictTypeId);
                    myCommand.Parameters.AddWithValue("@OSSerial", sof.OSSerial);
                    myCommand.Parameters.AddWithValue("@DictBillId", sof.DictBillId);
                    myCommand.Parameters.AddWithValue("@DictOsUsageId", sof.DictOsUsageId);
                    myCommand.Parameters.AddWithValue("@Visible", sof.Visible);
                    myCommand.Parameters.AddWithValue("@LastUpdate", sof.LastUpdate);

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
                delete from os
                where OSId=@OSId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@OSId", id);
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

