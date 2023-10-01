using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Student_Master_Areas.BAL
{
    public static class CV 
    {
        private static IHttpContextAccessor _httpContextAccessor;

        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public static string? UserName()
        {
            string? UserName = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }
            return UserName;
        }

        public static int? UserID()
        {
            int? UserID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserID;
        }
        public static int? StudentID()
        {
            int? StudentID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("StudentID") != null)
            {
                StudentID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("StudentID"));
            }
            return StudentID;
        }

        public static string? ImageURL()
        {
            string? ImageURL = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("ImageURL") != null)
            {
                ImageURL = _httpContextAccessor.HttpContext.Session.GetString("ImageURL");
            }
            return ImageURL;
        }

    }
}
