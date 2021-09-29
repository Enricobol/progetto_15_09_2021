using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using NodaTime;

namespace Scuola.Extensions
{
    public static class ReaderExtensions
    {
        public static int GetInt32(this SqlDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public static decimal GetDecimal(this SqlDataReader reader, string name)
        {
            return reader.GetDecimal(reader.GetOrdinal(name));
        }

        public static bool GetBoolean(this SqlDataReader reader, string name)
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }

        public static SqlDateTime GetSqlDateTime(this SqlDataReader reader, string name)
        {
            return reader.GetSqlDateTime(reader.GetOrdinal(name));
        }

        public static LocalDateTime GetLocalDateTime(this SqlDataReader reader, string name)
        {
            var dt = reader.GetDateTime(reader.GetOrdinal(name));
            LocalDateTime ldt = LocalDateTime.FromDateTime(dt);
            return ldt;
        }
        public static LocalDate GetLocalDate(this SqlDataReader reader, string name)
        {
            LocalDateTime ldt = reader.GetLocalDateTime(name);
            LocalDate ld = ldt.Date;
            return ld;
        }

        //METODI PER LEGGERE UN BOOLEAN ANNULLABILE
        public static bool? BADReadNullableBoolean(this SqlDataReader reader, string name)
        {
            if (reader.IsDBNull(name))
            {
                return null;
            }
            return reader.GetBoolean(name);
        }
        //VERSIONE MIGLIORE
        public static bool? ReadNullableBoolean(this SqlDataReader reader, string name)
        {
            return reader.IsDBNull(name) ? null : reader.GetBoolean(name);
        }

    }
}
