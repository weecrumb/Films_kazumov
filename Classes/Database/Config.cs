using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films_kazumov.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=127.0.0.1;port=3307;uid=root;pwd=;database=FilmsAndGenres;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
