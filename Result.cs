using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class Result<T>
    {
        public int code = 1;
        public string msg = "";
        public T res = default(T);
        public static Result Ok(T result) 
        {
            return new Result() { res = result };
        }
        public static Result ok(string messgge,Result=result(T))
        {
            return new Result() { msg = messgge, res = Result };
        }
        public static Result Err(string messgge)
        {
            return new Result() { code = -1, msg = messgge };
        }
    }
    public class result : result<dynamic>
    {

    }
}
