using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Siteware.Infra.Data.Repositories.Base
{
    public class BaseRepository
    {
        public IDbConnection Connection { get; set; }

        public BaseRepository(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
