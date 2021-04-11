using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.logic.Common
{
    public class DataTableResult<T> where T : class
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }
        public int draw { get; set; }

        public DataTableResult() { }

        public DataTableResult(bool success, string errorMessage)
        {
            this.Success = success;
            this.ErrorMessage = errorMessage;
        }

        public DataTableResult(bool success, string errorMessage, IEnumerable<T> stateList, int draw)
        {
            this.data = stateList;
            this.draw = draw;
        }

        public int recordsTotal
        {
            get
            {
                if (data == null)
                    return 0;
                return data.Count();
            }
        }

        public int recordsFiltered
        {
            get
            {
                if (data == null)
                    return 0;
                return data.Count();
            }
        }

        public IEnumerable<T> data { get; private set; }
    }
}
