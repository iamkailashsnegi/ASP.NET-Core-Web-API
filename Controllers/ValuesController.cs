using CoreApi.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }

        [HttpGet("Country")]
        //[Route("GetCountryList")]
        public IList<string> GetSample()
        {
            IList<string> _strList;
            var _repo = new Repo.SampleRepo();
            _strList = _repo.Sample(_connectionString);


            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("GetCountryStateCity_Kailash", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(ds);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GetItems obj = new GetItems();
                    obj.State = ds.Tables[0].Rows[i]["State_Name"].ToString();
                    obj.City = ds.Tables[0].Rows[i]["City_Name"].ToString();
                    obj.Country = ds.Tables[0].Rows[i]["Country_Name"].ToString();
                    _strList.Add(obj);
                }
            }
            return _strList;
        }
    }
}
