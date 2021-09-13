using CoreApi.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Repo
{
    public class SampleRepo
    {
        //data get method
        public IList<LocationGroup> Sample(string conn)
        {
            //List<LocationGroup> lm = new List<LocationGroup>();
            return new List<LocationGroup>();
        }
    }
}
