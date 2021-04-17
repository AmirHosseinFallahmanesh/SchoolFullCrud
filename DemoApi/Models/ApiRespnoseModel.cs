using System;

namespace DemoApi.Models
{
    public class ApiRespnoseModel<Tdata>
        {
            public Tdata Data { get; set; }
            public DateTime Time { get { return DateTime.Now; } }

            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }


        }
   
}
