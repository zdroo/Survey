using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class Response
    {
        private string q_id;
        private string responseText = string.Empty;

        public string Q_id { get { return q_id; } set { q_id = value; } }
        public string ResponseText { get { return responseText; } set { responseText = value; } }

    }
}
