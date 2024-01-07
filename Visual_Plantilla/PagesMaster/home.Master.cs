using System;
using Visual_Logica;
using System.Collections.Generic;
using System.Linq;
using Visual_Data;

namespace Visual_Plantilla
{
    public partial class home : System.Web.UI.MasterPage
    {
        private static DC_ClinicaDataContext dc = new DC_ClinicaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}