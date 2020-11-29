using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class DataTablesAjaxRequestModel
    {
        private HttpRequestBase _request;

        private int Start
        {
            get
            {
                return Convert.ToInt32(_request.QueryString["start"]);
            }
        }
        public int Length
        {
            get
            {
                return Convert.ToInt32(_request.QueryString["length"]);
            }
        }

        public string SearchText
        {
            get
            {
                return _request.QueryString["search[value]"];
            }
        }

        public int sortingCols;
        


        public DataTablesAjaxRequestModel(HttpRequestBase request)
        {
            _request = request;
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                    return (Start / Length) + 1;
                else
                    return 1;
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                    return 10;
                else
                    return Length;
            }
        }

        public static object EmptyResult
        {
            get
            {
                return new
                {
                    draw = 1,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = (new string[] { }).ToArray()
                };
            }
        }
    }
}